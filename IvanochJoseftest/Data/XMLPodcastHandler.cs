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
    class XMLPodcastHandler
    {
        public SyndicationFeed ReadFromXML(string PoddNamn)
        {
            var path = @"Database//" + PoddNamn + ".xml";
            if (File.Exists(path))
            {
                XmlReader reader = XmlReader.Create(path);
                SyndicationFeed feed = SyndicationFeed.Load((reader));
                return feed;
            }
            else
            {
                throw new Exception();
            }
        }

        public bool WriteToXML(string walla)
        {
            throw new NotImplementedException();
        }

        public bool WriteToXML(SyndicationFeed feed)
        {
            var PoddNamn = feed.Title.Text;
            var path = @"Database//" + PoddNamn + ".xml";
            if (!File.Exists(path))
            {
                XmlWriter writer = XmlWriter.Create(path);
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
