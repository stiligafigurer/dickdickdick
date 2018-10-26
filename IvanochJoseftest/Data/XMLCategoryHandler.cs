using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanochJoseftest.Data
{
    class XMLCategoryHandler : IXMLReadWriteAble
    {
        public string ReadFromXML(string keyword)
        {
            if (File.Exists("Kategorier.xml"))
            {
                StreamReader reader = new StreamReader("Kategorier.xml");
                var hej = reader.ReadToEnd();
                return "hej";

            }
            else
            {
                StreamWriter Writer = new StreamWriter("Kategorier.xml");
                return "hej";
            }
        }

        public bool WriteToXML(string text)
        {
            throw new NotImplementedException();
        }
    }
}
