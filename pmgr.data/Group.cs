using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace BryanPorter.PasswordManager.Data
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public ObservableCollection<Entry> Entries { get; set; }
    }
}
