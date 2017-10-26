using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RTTProjectWCF
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int empId { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string surname { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string resAddress { get; set; }
        [DataMember]
        public string workAddress { get; set; }
        [DataMember]
        public string postAddress { get; set; }
        [DataMember]
        public string cellNum { get; set; }

        [DataMember]
        public string workNum { get; set; }
    }
}
