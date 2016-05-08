namespace WixMVVMBurnUI.ViewModels
{
    using System;
    using System.IO;
    using Catel.MVVM;
    using Core;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
    using Models;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        public BootstrapperApplicationModel Model { get; private set; }

        private InstallationState installState;
        private DetectionState detectState;
        private bool downgrade;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.ViewWindowHandle = IntPtr.Zero;
        }

        public void Initialize(BootstrapperApplicationModel bootstrapperApplicationModel)
        {
            this.Model = bootstrapperApplicationModel;
            this.Model.DetectBegin += Model_DetectBegin;

            // This is called when the bundle is detected
            this.Model.DetectRelatedBundle += Model_DetectRelatedBundle;

            // This is called when a dectedtion is completed
            this.Model.DetectComplete += Model_DetectComplete;
            this.Model.PlanComplete += Model_PlanComplete;
            this.Model.CommandLineParsing += Model_CommandLineParsing;
        }

        public IntPtr ViewWindowHandle { get; set; }

        /// <summary>
        /// Gets and sets the detect state of the view's model.
        /// </summary>
        public DetectionState DetectState
        {
            get
            {
                return this.detectState;
            }

            set
            {
                if (this.detectState != value)
                {
                    this.detectState = value;

                    // Notify all the properties derived from the state that the state changed.
                    base.OnPropertyChanged(new Catel.Data.AdvancedPropertyChangedEventArgs(this, nameof(DetectState)));
                }
            }
        }

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
                    base.OnPropertyChanged(new Catel.Data.AdvancedPropertyChangedEventArgs(this, nameof(InstallState)));
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
                    base.OnPropertyChanged(new Catel.Data.AdvancedPropertyChangedEventArgs(this, nameof(InstallDirectory)));
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
                    base.OnPropertyChanged(new Catel.Data.AdvancedPropertyChangedEventArgs(this, nameof(LayoutDirectory)));
                }
            }
        }

        /// <summary>
        /// Gets and sets whether the view model considers this install to be a downgrade.
        /// </summary>
        public bool Downgrade
        {
            get
            {
                return this.downgrade;
            }

            set
            {
                if (this.downgrade != value)
                {
                    this.downgrade = value;
                    base.OnPropertyChanged(new Catel.Data.AdvancedPropertyChangedEventArgs(this, nameof(Downgrade)));
                }
            }
        }

        public void PlanAction(LaunchAction action)
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

        private void Model_DetectBegin(object sender, WPFBootstrapperEventArgs<DetectBeginEventArgs> e)
        {
            this.DetectState = e.Arguments.Installed ? DetectionState.Present : DetectionState.Absent;
            this.Model.PlannedAction = LaunchAction.Unknown;
        }

        private void Model_DetectComplete(object sender, WPFBootstrapperEventArgs<DetectCompleteEventArgs> e)
        {
            this.InstallState = InstallationState.Waiting;

            if (LaunchAction.Uninstall == this.Model.Command.Action)
            {
                this.Model.LogVerbose("Invoking automatic plan for uninstall");
                this.PlanAction(LaunchAction.Uninstall);
            }
            else if (Hresult.Succeeded(e.Arguments.Status))
            {
                if (this.Downgrade)
                {
                    // TODO: What behavior do we want for downgrade?
                    this.DetectState = DetectionState.Newer;
                }

                if (LaunchAction.Layout == this.Model.Command.Action)
                {
                    //this.PlanLayout();
                }
                else if (this.Model.Command.Display != Display.Full)
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

        private void Model_DetectRelatedBundle(object sender, WPFBootstrapperEventArgs<DetectRelatedBundleEventArgs> e)
        {
            if (e.Arguments.Operation == RelatedOperation.Downgrade)
            {
                this.Downgrade = true;
            }
        }

        private void Model_PlanComplete(object sender, WPFBootstrapperEventArgs<PlanCompleteEventArgs> e)
        {
            if (Hresult.Succeeded(e.Arguments.Status))
            {
                this.PreApplyState = this.InstallState;
                this.InstallState = InstallationState.Applying;

                //this.PlanAction(LaunchAction.Unknown);

                this.Model.Apply(this.ViewWindowHandle);
            }
            else
            {
                this.InstallState = InstallationState.Failed;
            }
        }

        #endregion Events
    }
}