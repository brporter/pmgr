using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BryanPorter.PasswordManager.Data.Tests
{
    [TestClass]
    public class DataContextTest
    {
        [TestMethod]
        public void TestCommit()
        {
            var ctx = new DataContext(null);

            var g = new Group()
            {
                Name = "Name",
                Description = "Description",
                Entries = new ObservableCollection<Entry>()
                    {
                        new Entry()
                        {
                            Name = "Name",
                            Key = "Key",
                            Username = "Username",
                            Password = "Password",
                            Type = EntryType.Generic
                        },
                        new Entry()
                        {
                            Name = "Name",
                            Key = "Key",
                            Username = "Username",
                            Password = "Password",
                            Type = EntryType.UsernamePassword
                        },
                        new Entry()
                        {
                            Name = "Name",
                            Key = "Key",
                            Username = "Username",
                            Password = "Password",
                            Type = EntryType.WindowsUsernamePassword
                        }
                    }
            };

            ctx.Groups.Add(g);

            using (
                var isoStore =
                    IsolatedStorageFile.GetStore(
                        IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null,
                        null))
            {
                using (var strm = isoStore.OpenFile("password.dat", FileMode.OpenOrCreate))
                {
                    ctx.Commit(strm);
                }
            }

            using (
                var isoStore =
                    IsolatedStorageFile.GetStore(
                        IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null,
                        null))
            {
                using (var strm = isoStore.OpenFile("password.dat", FileMode.Open))
                {
                    ctx = new DataContext(strm);
                }
            }

        }
    }
}
