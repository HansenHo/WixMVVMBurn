namespace WixMVVMBurnUI.Views
{
    using System;
    using Catel.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for BootstrapperApplicationWindow.xaml.
    /// </summary>
    public partial class BootstrapperApplicationWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapperApplicationWindow"/> class.
        /// </summary>
        public BootstrapperApplicationWindow()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapperApplicationWindow"/> class.
        /// </summary>
        /// <param name="viewModel">The view model to inject.</param>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public BootstrapperApplicationWindow(BootstrapperApplicationViewModelBase viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }

        
    }
}