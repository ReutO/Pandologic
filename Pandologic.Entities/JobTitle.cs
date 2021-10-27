using System.Runtime.Serialization;

namespace Pandologic.Entities
{
    [DataContract]
    public class JobTitle
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public int CategoryID { get; set; }
    }
}
