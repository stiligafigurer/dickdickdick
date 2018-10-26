using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IvanochJoseftest.Data
{
    class XMLPodcastHandler : IXMLReadWriteAble
    {
        public string ReadFromXML(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool WriteToXML(string walla)
        {
            throw new NotImplementedException();
        }

        public bool WriteToXML(SyndicationFeed feed)
        {
            var PoddNamn = feed.Title.Text;
            if (!File.Exists(PoddNamn + ".xml"))
            {
                XmlWriter writer = XmlWriter.Create(PoddNamn + ".xml");
                feed.SaveAsRss20(writer);
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
