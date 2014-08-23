using System.Runtime.Serialization;

namespace BryanPorter.PasswordManager.Data
{
    [DataContract]
    public class Entry
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public EntryType Type { get; set; }

        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public byte[] ImageBytes { get; set; }
    }

    public enum EntryType
    {
        Generic,
        UsernamePassword,
        WindowsUsernamePassword
    }
}
