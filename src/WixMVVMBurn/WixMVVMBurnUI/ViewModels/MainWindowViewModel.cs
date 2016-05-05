namespace WixMVVMBurnUI.ViewModels
{
    using System;
    using Catel.MVVM;
    using Core;
    using Models;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public partial class MainWindowViewModel : ViewModelBase
    {
        public BootstrapperApplicationModel Model { get; private set; }

        private InstallationState installState;
        private DetectionState detectState;

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
    }
}