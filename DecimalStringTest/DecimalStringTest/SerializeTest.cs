using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DecimalStringTest
{
    public class SerializeTest
    {
        public static void ToJsonString()
        {
            //TaxDoc doc = new TaxDoc();
            //doc.Field1 = 1;
            //doc.Field2 = "Hello";
            //doc.Field3 = new List<string>();
            //doc.Field3.Add("List-String1");
            //doc.Field4 = new Dictionary<string, string>();
            //doc.Field4["dicKey1"] = "dicValue1";
            //doc.Field5 = new Dictionary<string, object>();
            //doc.Field5["dicKey1"] = 1;
            ////doc.Field5["dicKey1"] = new List<string>(); // error
            //doc.Field6 = new System.Collections.Hashtable();
            //doc.Field6.Add("txt", "notepad.exe");
            //doc.Field6.Add("dd", "notepad.exe");
            ////doc.Field6.Add("abc", new List<string>()); // error


            //MemoryStream stream1 = new MemoryStream();
            //DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            //settings.UseSimpleDictionaryFormat = true;
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TaxDoc), settings);

            //ser.WriteObject(stream1, doc);

            //stream1.Position = 0;
            //StreamReader sr = new StreamReader(stream1);
            //Console.WriteLine("JSON form of TaxDoc object: ");
            //Console.WriteLine(sr.ReadToEnd());
        }
    }
}
