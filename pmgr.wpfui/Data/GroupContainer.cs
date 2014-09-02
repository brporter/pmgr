using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BryanPorter.PasswordManager.Data
{
    [DataContract]
    internal class GroupContainer
    {
        public GroupContainer()
        {
            Groups = new List<Group>();
        }

        [DataMember]
        public ICollection<Group> Groups { get; set; }
    }
}
