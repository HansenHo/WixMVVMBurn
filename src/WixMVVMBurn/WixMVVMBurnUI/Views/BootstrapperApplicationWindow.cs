namespace WixMVVMBurnUI.Views
{
    using System;
    using System.Windows.Interop;
    using Catel.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for BootstrapperApplicationWindow.xaml.
    /// </summary>
    public class BootstrapperApplicationWindow : DataWindow
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
        public BootstrapperApplicationWindow(MainWindowViewModel viewModel)
            : base(viewModel)
        {
            this.Closed += (sender, e) => this.Dispatcher.InvokeShutdown(); // shutdown dispatcher when the window is closed.

            viewModel.ViewWindowHandle = new WindowInteropHelper(this).EnsureHandle();
        }


    }
}