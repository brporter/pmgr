using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BryanPorter.PasswordManager.WpfUi.ViewModels;
using Ninject;

namespace BryanPorter.PasswordManager.WpfUi
{
    public class ViewModelLocator
    {
        private static readonly IKernel _kernel;

        static ViewModelLocator()
        {
            _kernel = new StandardKernel(new Modules.PmgrModule());
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return _kernel.Get<MainWindowViewModel>();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get { return _kernel.Get<SettingsViewModel>(); }
        }
    }
}
