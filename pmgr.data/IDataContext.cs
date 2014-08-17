using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BryanPorter.PasswordManager.Data
{
    public interface IDataContext
    {
        ICollection<Group> Groups { get; }

        void Commit(Stream storageStream);
    }
}
