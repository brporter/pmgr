using System;
using System.IO;

namespace BryanPorter.PasswordManager.Data
{
    public interface ISettingsContext
        : ICommit, IInitialize, IDisposable
    {
        Settings Settings { get; }
    }
}