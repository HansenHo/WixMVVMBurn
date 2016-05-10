namespace WixMVVMBurnUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using Core;
    using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public partial class BootstrapperApplicationModel
    {
        private const string BurnBundleInstallLevelVariable = "INSTALLLEVEL";
        private const string BurnBundleInstallDirectoryVariable = "INSTALLFOLDER";
        private const string BurnBundleLayoutDirectoryVariable = "WixBundleLayoutDirectory";
        private const string BurnBundleVersionVariable = "WixBundleVersion";
        private Version version;

        public BootstrapperApplicationModel(WPFBootstrapper bootstrapperApplication)
        {
            this.Bootstrapper = bootstrapperApplication;
        }

        public WPFBootstrapper Bootstrapper { get; private set; }

        public List<BundlePackage> BundlePackages { get { return this.Bootstrapper.BundlePackages; } }

        public string DisplayName { get { return this.Bootstrapper.DisplayName; } }

        /// <summary>
        /// Gets the bootstrapper command-line.
        /// </summary>
        public Wix.Command Command { get { return this.Bootstrapper.Command; } }

        ///
        /// Full application command line
        ///
        public string[] CommandLineArgs { get { return this.Command.GetCommandLineArgs(); } }

        /// <summary>
        /// Gets the bootstrapper engine.
        /// </summary>
        public Wix.Engine Engine { get { return this.Bootstrapper.Engine; } }

        /// <summary>
        /// Gets or sets the final result of this bootstrapper.
        /// </summary>
        /// <value>The final result.</value>
        public int FinalResult { get; set; }

        /// <summary>
        /// Get or set the path where the bundle is installed.
        /// </summary>
        public string InstallDirectory
        {
            get
            {
                if (!this.Engine.StringVariables.Contains(BurnBundleInstallDirectoryVariable))
                {
                    return null;
                }

                return this.Engine.StringVariables[BurnBundleInstallDirectoryVariable];
            }

            set
            {
                this.Engine.StringVariables[BurnBundleInstallDirectoryVariable] = value;
            }
        }

        /// <summary>
        /// Get or set the install level.
        /// </summary>
        public long InstallLevel
        {
            get
            {
                if (!this.Engine.NumericVariables.Contains(BurnBundleInstallLevelVariable))
                {
                    return 1;
                }

                return this.Engine.NumericVariables[BurnBundleInstallLevelVariable];
            }

            set
            {
                this.Engine.NumericVariables[BurnBundleInstallLevelVariable] = value;
            }
        }

        /// <summary>
        /// Get or set the path for the layout to be created.
        /// </summary>
        public string LayoutDirectory
        {
            get
            {
                if (!this.Engine.StringVariables.Contains(BurnBundleLayoutDirectoryVariable))
                {
                    return null;
                }

                return this.Engine.StringVariables[BurnBundleLayoutDirectoryVariable];
            }

            set
            {
                this.Engine.StringVariables[BurnBundleLayoutDirectoryVariable] = value;
            }
        }

        /// <summary>
        /// Get the version of the install.
        /// </summary>
        public Version Version
        {
            get
            {
                if (null == this.version)
                {
                    this.version = this.Engine.VersionVariables[BurnBundleVersionVariable];
                }

                return this.version;
            }
        }

        public ProductInstallationState ProductInstallationState { get; private set; }

        public Version NewerProductInstalledVersion { get; private set; }

        ///
        /// Requested action from the commandline
        ///
        public Wix.LaunchAction RunMode { get { return this.Command.Action; } }

        ///
        /// Requested display mode from the commandline
        /// (Full, Passive/Silent, Embedded)
        ///
        public Wix.Display DisplayMode { get { return this.Command.Display; } }

        public Wix.LaunchAction PlannedAction { get; set; }

        public void SetBurnVariable(string variableName, string value)
        {
            this.Engine.StringVariables[variableName] = value;
        }

        internal void PlanAction(Wix.LaunchAction action)
        {
            this.Bootstrapper.LogStandard("Plan Action: " + action);
            this.PlannedAction = action;
            this.Engine.Plan(action);
        }

        internal void PlanLayout()
        {
            PlanAction(Wix.LaunchAction.Layout);
        }

        internal void Apply(IntPtr hWnd)
        {
            this.Bootstrapper.LogStandard("Apply: " + this.PlannedAction);
            this.Engine.Apply(hWnd);
        }

        public void SetBurnSecuredVariable(string variableName, string value)
        {
            SecureString secString = new SecureString();
            foreach (char c in value)
            {
                secString.AppendChar(c);
            }
            secString.MakeReadOnly();
            this.Engine.SecureStringVariables[variableName] = secString;
        }

        #region Bundle and Feature Information detecting

        private void SetInstallationStateOnDetectBegin(Wix.DetectBeginEventArgs args)
        {
            if (args.Installed)
            {
                this.ProductInstallationState = ProductInstallationState.SameVersionInstalled;
            }
            else
            {
                this.ProductInstallationState = ProductInstallationState.NotInstalled;
            }
        }

        private void SetRelatedBundleDetectedState(Wix.DetectRelatedBundleEventArgs args)
        {
            if (this.PlannedAction == Wix.LaunchAction.Install)
            {
                ProductInstallationState stateForCurrentBundleDetection = ProductInstallationState.Unknown;
                if (args.Operation == Wix.RelatedOperation.Downgrade)
                {
                    this.LogStandard("A higher version the bundle is already installed");
                    stateForCurrentBundleDetection = ProductInstallationState.NewerVersionInstalled;
                    this.NewerProductInstalledVersion = args.Version;
                }
                else if (args.Operation == Wix.RelatedOperation.MajorUpgrade)
                {
                    stateForCurrentBundleDetection = ProductInstallationState.OlderVersionInstalled;
                }
                else if (args.Operation == Wix.RelatedOperation.MinorUpdate)
                {
                    stateForCurrentBundleDetection = ProductInstallationState.OlderVersionInstalled;
                }

                if (this.ProductInstallationState < stateForCurrentBundleDetection)
                {
                    this.LogVerbose("Updating ProductInstallationState to: " + stateForCurrentBundleDetection);
                    this.ProductInstallationState = stateForCurrentBundleDetection;
                }
            }
        }

        /// <summary>
        /// when engine detects a package, populate the appropriate local objects,
        /// including current installed state of the package on the system
        /// </summary>
        private void SetPackageDetectedState(Wix.DetectPackageCompleteEventArgs args)
        {
            var package = this.BundlePackages.FirstOrDefault(pkg => pkg.Package == args.PackageId);
            if (package != null)
            {
                Wix.PackageState currentState = args.State;
                package.CurrentInstallState = currentState;
            }
        }

        /// <summary>
        /// when engine detects a feature, populate the appropriate local objects,
        /// including current installed state of the package on the system
        /// </summary>
        private void SetFeatureDetectedState(Wix.DetectMsiFeatureEventArgs args)
        {
            var package = this.BundlePackages.FirstOrDefault(pkg => pkg.Package == args.PackageId);
            if (package != null)
            {
                var feature = package.AllFeatures.FirstOrDefault(feat => feat.Feature == args.FeatureId);
                if (feature != null)
                {
                    Wix.FeatureState currentState = args.State;

                    feature.CurrentInstallState = args.State;
                }
            }
        }

        ///
        /// when engine plans action for a package, set the requested future state of
        /// the package based on what the user requested
        ///
        private void SetPackagePlannedState(Wix.PlanPackageBeginEventArgs planPackageBeginEventArgs)
        {
            var pkgId = planPackageBeginEventArgs.PackageId;
            var pkg = BundlePackages.FirstOrDefault(p => p.Package == pkgId);

            if (pkg != null)
            {
                if (pkg.RequestedInstallState.HasValue)
                {
                    //override default value set by bootstrapper engine
                    planPackageBeginEventArgs.State = pkg.RequestedInstallState.Value;
                }
                else if (pkg.CurrentInstallState == Wix.PackageState.Present)
                {
                    if (this.PlannedAction == Wix.LaunchAction.Uninstall)
                    {
                        planPackageBeginEventArgs.State = Wix.RequestState.Absent;
                    }
                    else if (this.PlannedAction == Wix.LaunchAction.Repair)
                    {
                        planPackageBeginEventArgs.State = Wix.RequestState.Repair;
                    }
                    else
                    {
                        planPackageBeginEventArgs.State = Wix.RequestState.Present;
                    }
                }
            }
        }

        ///
        /// when engine plans action for a feature, set the requested future state of
        /// the package based on what the user requested
        ///
        private void SetFeaturePlannedState(Wix.PlanMsiFeatureEventArgs planMsiFeatureEventArgs)
        {
            var pkg = BundlePackages.First(p => p.Package == planMsiFeatureEventArgs.PackageId);
            if (pkg != null)
            {
                var feature = pkg.AllFeatures.First(feat => feat.Feature == planMsiFeatureEventArgs.FeatureId);
                if (feature != null)
                {
                    if (feature.RequestedState.HasValue)
                    {
                        planMsiFeatureEventArgs.State = feature.RequestedState.Value;
                    }
                    else if (this.PlannedAction == Wix.LaunchAction.Uninstall)
                    {
                        planMsiFeatureEventArgs.State = Wix.FeatureState.Absent;
                    }
                    else if (feature.CurrentInstallState == Wix.FeatureState.Local || (feature.Level > 0 && feature.Level <= this.InstallLevel))
                    {
                        planMsiFeatureEventArgs.State = Wix.FeatureState.Local;
                    }
                }
            }
        }

        #endregion Bundle and Feature Information detecting

        #region Logging

        public void LogVerbose(string message)
        {
            this.Bootstrapper.LogVerbose(message);
        }

        public void LogDebug(string message)
        {
            this.Bootstrapper.LogDebug(message);
        }

        public void LogStandard(string message)
        {
            this.Bootstrapper.LogStandard(message);
        }

        public void LogError(string message)
        {
            this.Bootstrapper.LogError(message);
        }

        #endregion Logging
    }
}