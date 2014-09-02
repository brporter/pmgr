using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryanPorter.PasswordManager.WpfUi.Data
{
    internal abstract class StorageContext
    {
        protected virtual IsolatedStorageFile GetStore()
        {
            return IsolatedStorageFile.GetStore(
                IsolatedStorageScope.User | IsolatedStorageScope.Assembly,
                (Type)null,
                (Type)null);
        }
    }
}
