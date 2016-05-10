

namespace WixMVVMBurnUI.ViewModels
{

    using WixMVVMBurnUI.Models;
    /// <summary>
    /// Interface IMainWindowViewModel
    /// </summary>
    public interface IMainWindowViewModel
    {
        /// <summary>
        /// Initializes the view model with the specified bootstrapper application model.
        /// </summary>
        /// <param name="bootstrapperApplicationModel">The bootstrapper application model.</param>
        void Initialize(BootstrapperApplicationModel bootstrapperApplicationModel);
    }
}