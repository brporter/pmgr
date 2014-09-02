using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using BryanPorter.PasswordManager.Data;

namespace BryanPorter.PasswordManager.WpfUi.Data
{
    internal class DataContext
        : StorageContext, IDataContext
    {
        private GroupContainer _groupContainer;
        private const string DataFileName = "pmgr.dat";

        public DataContext()
        {
            Initialize();
        }

        public ICollection<Group> Groups
        {
            get { return _groupContainer.Groups; }
        }

        public void Commit()
        {
            using (var store = GetStore())
            {
                using (var storageFile = store.OpenFile(DataFileName, FileMode.Create, FileAccess.Write))
                {
                    var serializer = new DataContractSerializer(typeof(GroupContainer));

                    serializer.WriteObject(storageFile, _groupContainer);   

                    storageFile.Close();
                }
            }
        }

        public void Initialize()
        {
            using (var store = GetStore())
            {
                if (store.FileExists(DataFileName))
                {
                    using (var storageFile = store.OpenFile(DataFileName, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        var serializer = new DataContractSerializer(typeof (GroupContainer));

                        _groupContainer = serializer.ReadObject(storageFile) as GroupContainer ?? new GroupContainer();
                    }
                }
                else
                {
                    _groupContainer = new GroupContainer();
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
