using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using BryanPorter.PasswordManager.Data;
using BryanPorter.PasswordManager.WpfUi.Data;
using BryanPorter.PasswordManager.WpfUi.ViewModels;
using Ninject;
using Ninject.Modules;

namespace BryanPorter.PasswordManager.WpfUi.Modules
{
    public class PmgrModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<ISettingsContext>().To<SettingsContext>();

            Bind<IDataContext>().To<DataContext>();

            Bind<MainWindowViewModel>().ToSelf();

            Bind<SettingsViewModel>().ToSelf();
        }
    }
}
