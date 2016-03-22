namespace WixMVVMBurnUI.ViewModels
{
    using System;
    using Catel.MVVM;
    using Models;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public partial class BootstrapperApplicationViewModelBase : ViewModelBase
    {
        public BootstrapperApplicationModel BootstrapperApplicationModel { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapperApplicationViewModelBase"/> class.
        /// </summary>
        public BootstrapperApplicationViewModelBase(BootstrapperApplicationModel bootstrapperApplicationModel)
        {
            this.BootstrapperApplicationModel = bootstrapperApplicationModel;
        }
    }
}