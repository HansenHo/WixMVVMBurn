namespace WixMVVMBurnUI.Views
{
    using System.Windows;
    using ViewModels;

    public interface IBootstrapperMainWindow
    {
        IMainWindowViewModel ViewModel
        {
            get;
        }

        Window Window
        {
            get;
        }
    }
}