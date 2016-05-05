using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WixMVVMBurnUI.ViewModels;

namespace WixMVVMBurnUI.Pages
{
    public interface IBootstrapperPage
    {
        void Initialize(MainWindowViewModel mainViewModel);
    }
}
