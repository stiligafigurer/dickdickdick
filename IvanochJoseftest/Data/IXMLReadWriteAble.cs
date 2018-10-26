using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanochJoseftest.Data
{
    interface IXMLReadWriteAble
    {
        string ReadFromXML(string keyword);
        bool WriteToXML(string text);
    }
}
