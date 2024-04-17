using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;

namespace DecimalStringTest
{
    [DataContract]
    public class TaxDoc
    {
        [DataMember]
        public int Field1 { get; set; }

        [DataMember]
        public string Field2 { get; set; }

        [DataMember]
        public List<string> Field3 { get; set; }

        [DataMember]
        public Dictionary<string, string> Field4 { get; set; }

        [DataMember]
        public Dictionary<string, object> Field5 { get; set; }

        [DataMember]
        public Hashtable Field6 { get; set; }
    }
}
