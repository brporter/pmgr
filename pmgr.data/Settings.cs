using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BryanPorter.PasswordManager.Data
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public string FilePath { get; set; }
    }
}
