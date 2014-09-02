using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BryanPorter.PasswordManager.WpfUi.Data;

namespace BryanPorter.PasswordManager.Data
{
    internal class SettingsContext 
        : StorageContext, ISettingsContext
    {
        private const string SettingsFileName = "settings.dat";

        public SettingsContext()
        {
            Initialize();
        }

        public Settings Settings { get; private set; }

        public void Commit()
        {
            using (var store = GetStore())
            {
                using (var settingsStream = store.OpenFile(SettingsFileName, FileMode.Create, FileAccess.Write))
                {
                    var serializer = new DataContractSerializer(typeof(Settings));

                    serializer.WriteObject(settingsStream, Settings);

                    settingsStream.Close();
                }
            }
        }

        public void Initialize()
        {
            using (var store = GetStore())
            {
                if (store.FileExists(SettingsFileName))
                {
                    using (var settingsStream = store.OpenFile(SettingsFileName, FileMode.OpenOrCreate, FileAccess.Read)
                        )
                    {
                        var serializer = new DataContractSerializer(typeof (Settings));

                        Settings = serializer.ReadObject(settingsStream) as Settings ?? new Settings();
                    }
                }
                else
                {
                    Settings = new Settings();
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
