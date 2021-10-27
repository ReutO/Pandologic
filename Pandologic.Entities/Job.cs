using System.Runtime.Serialization;

namespace Pandologic.Entities
{
    [DataContract]
    public class Job
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int JobTitleID { get; set; }

        public int CategoryID { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int DescriptionLength { get; set; }

        [DataMember]
        public int EducationLevel { get; set; }

        [DataMember]
        public int Clicks { get; set; }

        [DataMember]
        public int Applicants { get; set; }

        public string JobTitleName { get; set; }
        
        [DataMember]
        public string JobTitleDescription { get; set; }
    }
}
