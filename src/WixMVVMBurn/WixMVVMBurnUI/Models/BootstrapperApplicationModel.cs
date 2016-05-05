namespace WixMVVMBurnUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public partial class BootstrapperApplicationModel
    {
        private const string BurnBundleInstallDirectoryVariable = "InstallFolder";
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

        #region Bundle and Feature Information detecting

        private void HandleExistingPackageDetected(Wix.DetectRelatedMsiPackageEventArgs e)
        {
            string existingPackageProductCode = e.ProductCode;

            Wix.RelatedOperation actionToBeApplicedToExistingPackage = e.Operation;
            string existingPackageId = e.PackageId;
            Version existingPackageVersion = e.Version;

            //update your model objects here (search models by PackageId)
        }

        private void HandleExistingBundleDetected(Wix.DetectRelatedBundleEventArgs e)
        {
            Version existingBundleVersion = e.Version;
            string existingBundleProductCode = e.ProductCode;
            Wix.RelatedOperation actionToBeAppliedToExistingBundle = e.Operation;

            //update your model object here
        }

        /// <summary>
        /// when engine detects a package, populate the appropriate local objects,
        /// including current installed state of the package on the system
        /// </summary>
        private void SetPackageDetectedState(Wix.DetectPackageCompleteEventArgs args)
        {
            var package = this.BundlePackages.FirstOrDefault(pkg => pkg.Package == args.PackageId);
            Wix.PackageState currentState = args.State;
            package.CurrentInstallState = currentState;
        }

        /// <summary>
        /// when engine detects a feature, populate the appropriate local objects,
        /// including current installed state of the package on the system
        /// </summary>
        private void SetFeatureDetectedState(Wix.DetectMsiFeatureEventArgs args)
        {
            var package = this.BundlePackages.FirstOrDefault(pkg => pkg.Package == args.PackageId);
            var feature = package.AllFeatures.FirstOrDefault(feat => feat.Feature == args.FeatureId);
            Wix.FeatureState currentState = args.State;

            feature.CurrentInstallState = args.State;
        }

        #endregion Bundle and Feature Information detecting

    }
}