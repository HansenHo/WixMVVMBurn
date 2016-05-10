namespace WixMVVMBurnUI.ViewModels
{
    using System;
    using System.IO;
    using Core;
    using Models;
    using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class SilentViewModel : ViewModelBase, IMainWindowViewModel
    {
        public BootstrapperApplicationModel Model { get; private set; }

        private InstallationState installState;

        /// <summary>
        /// Initializes a new instance of the <see cref="SilentViewModel"/> class.
        /// </summary>
        public SilentViewModel()
        {
            this.ViewWindowHandle = IntPtr.Zero;
            this.InstallState = InstallationState.Initializing;
        }

        public void Initialize(BootstrapperApplicationModel bootstrapperApplicationModel)
        {
            this.Model = bootstrapperApplicationModel;
            this.Model.DetectBegin += Model_DetectBegin;
            this.Model.DetectComplete += Model_DetectComplete;

            this.Model.PlanBegin += Model_PlanBegin;
            this.Model.PlanComplete += Model_PlanComplete;
            this.Model.CommandLineParsing += Model_CommandLineParsing;
            this.Model.ApplyComplete += Model_ApplyComplete;
        }

        public IntPtr ViewWindowHandle { get; set; }

        /// <summary>
        /// Gets and sets the state of the view's model before apply begins in order to return to that state if cancel or rollback occurs.
        /// </summary>
        public InstallationState PreApplyState { get; set; }

        /// <summary>
        /// Gets and sets the installation state of the view's model.
        /// </summary>
        public InstallationState InstallState
        {
            get
            {
                return this.installState;
            }

            set
            {
                if (this.installState != value)
                {
                    this.installState = value;

                    // Notify all the properties derived from the state that the state changed.
                    base.OnPropertyChanged(nameof(InstallState));
                }
            }
        }

        /// <summary>
        /// Gets and sets the path where the bundle is currently installed or will be installed.
        /// </summary>
        public string InstallDirectory
        {
            get
            {
                return this.Model.InstallDirectory;
            }

            set
            {
                if (this.Model.InstallDirectory != value)
                {
                    this.Model.InstallDirectory = value;
                    base.OnPropertyChanged(nameof(InstallDirectory));
                }
            }
        }

        /// <summary>
        /// Gets and sets the path where the bundle is currently extracted.
        /// </summary>
        public string LayoutDirectory
        {
            get
            {
                return this.Model.LayoutDirectory;
            }

            set
            {
                if (this.Model.LayoutDirectory != value)
                {
                    this.Model.LayoutDirectory = value;
                    base.OnPropertyChanged(nameof(LayoutDirectory));
                }
            }
        }

        public void PlanAction(Wix.LaunchAction action)
        {
            this.Model.PlanAction(action);
        }

        #region Events

        private void Model_CommandLineParsing(object sender, CommandLineParseEventArgs e)
        {
            if (e.Type == CommandLineArgumentType.Parameter)
            {
                if (e.Name.Equals("InstallFolder", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrWhiteSpace(e.Value))
                {
                    // Allow relative directory paths. Also validates.
                    this.InstallDirectory = Path.Combine(Environment.CurrentDirectory, e.Value);
                    e.Handled = true;
                }
                else if (e.Name.Equals("LayoutFolder", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrWhiteSpace(e.Value))
                {
                    // Allow relative directory paths. Also validates.
                    this.LayoutDirectory = Path.Combine(Environment.CurrentDirectory, e.Value);
                    e.Handled = true;
                }
            }
        }

        private void Model_DetectBegin(object sender, WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> e)
        {
            this.InstallState = InstallationState.Detecting;
        }

        private void Model_DetectComplete(object sender, WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> e)
        {
            this.InstallState = InstallationState.Detected;

            if (Wix.LaunchAction.Uninstall == this.Model.Command.Action)
            {
                this.Model.LogVerbose("Invoking automatic plan for uninstall");
                this.PlanAction(Wix.LaunchAction.Uninstall);
            }
            else if (Hresult.Succeeded(e.Arguments.Status))
            {
                if (Wix.LaunchAction.Layout == this.Model.Command.Action)
                {
                    this.Model.PlanLayout();
                }
                else
                {
                    // If we're not waiting for the user to click install, dispatch plan with the default action.
                    this.Model.LogVerbose("Invoking automatic plan for non-interactive mode.");
                    this.PlanAction(this.Model.Command.Action);
                }
            }
            else
            {
                this.InstallState = InstallationState.Failed;
            }
        }

        private void Model_PlanBegin(object sender, WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> e)
        {
            this.InstallState = InstallationState.Planning;
        }

        private void Model_PlanComplete(object sender, WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> e)
        {
            if (Hresult.Succeeded(e.Arguments.Status))
            {
                this.PreApplyState = this.InstallState;
                this.InstallState = InstallationState.Applying;

                this.Model.Apply(this.ViewWindowHandle);
            }
            else
            {
                this.InstallState = InstallationState.Failed;
            }
        }

        private void Model_ApplyComplete(object sender, WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> e)
        {
            if (Hresult.Succeeded(e.Arguments.Status))
            {
                this.InstallState = InstallationState.Applied;
            }
            else
            {
                this.InstallState = InstallationState.Failed;
            }
        }

        #endregion Events
    }
}