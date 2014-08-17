using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BryanPorter.PasswordManager.Data
{
    public sealed class DataContext
        : IDataContext
    {
        private readonly GroupContainer _groupContainer;

        public DataContext(Stream storageStream)
        {
            var serializer = new DataContractSerializer(typeof (GroupContainer));

            if (storageStream != null)
            {
                _groupContainer = serializer.ReadObject(storageStream) as GroupContainer;
            }
            else
            {
                _groupContainer = new GroupContainer()
                {
                    Groups = new List<Group>()
                };
            }
        }

        public ICollection<Group> Groups
        {
            get { return _groupContainer.Groups; }
        }

        public void Commit(Stream storageStream)
        {
            var serializer = new DataContractSerializer(typeof (GroupContainer));

            

            serializer.WriteObject(storageStream, _groupContainer);
        }
    }
}
