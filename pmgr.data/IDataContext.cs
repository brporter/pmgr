using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BryanPorter.PasswordManager.Data
{
    public interface IDataContext
        : ICommit, IInitialize, IDisposable
    {
        ICollection<Group> Groups { get; }
    }
}
