using System;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixMVVMBurnUI.Models
{
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

        /// <summary>
        /// Gets the bootstrapper command-line.
        /// </summary>
        public Command Command { get { return this.Bootstrapper.Command; } }

        /// <summary>
        /// Gets the bootstrapper engine.
        /// </summary>
        public Engine Engine { get { return this.Bootstrapper.Engine; } }

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

        public void ApplyAction(IntPtr handle)
        {
            this.Engine.Apply(handle);
        }

        public void LogMessage(string message)
        {
            this.Engine.Log(LogLevel.Standard, message);
        }

        public void PlanAction(LaunchAction action)
        {
            this.Engine.Plan(action);
        }

        public void SetBurnVariable(string variableName, string value)
        {
            this.Engine.StringVariables[variableName] = value;
        }
    }
}