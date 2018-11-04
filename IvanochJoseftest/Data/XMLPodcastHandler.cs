using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IvanochJoseftest.Data
{
    public static class XMLPodcastHandler
    {
        public static SyndicationFeed ReadFromXML(string PoddNamn)
        {
            var path = @"Database//" + PoddNamn + ".xml";
            if (File.Exists(path))
            {
                XmlReader reader = XmlReader.Create(path);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                return feed;
            }
            else
            {
                throw new Exception();
            }
        }

        public static bool WriteToXML(SyndicationFeed feed, string Kategori, int TimerIndex, string url)
        {
            var PoddNamn = feed.Title.Text;
            var Path = @"Database//" + PoddNamn + ".xml";
            XmlWriter writer = XmlWriter.Create(Path);
            if(File.Exists(@"Database//" + "KoT$" + PoddNamn + ".txt"))
            {
                File.Delete(@"Database//" + "KoT$" + PoddNamn + ".txt");
            }
            StreamWriter sr = File.AppendText(@"Database//" + "KoT$" + PoddNamn + ".txt");
            sr.WriteLine(Kategori);
            sr.WriteLine(TimerIndex);
            sr.WriteLine(url);
            feed.SaveAsRss20(writer);
            writer.Close();
            sr.Close();
        
            return true;
        }

        public static bool RemoveXML(string PoddNamn)
        {
            if(File.Exists(@"Database//" + PoddNamn + ".xml"))
            {
               File.Delete(@"Database//" + PoddNamn + ".xml");
                if(File.Exists(@"Database//KoT$" + PoddNamn + ".txt"))
                {
                    File.Delete(@"Database//KoT$" + PoddNamn + ".txt");
                    return true;
                }
                return true;
            }
            return false;
        }
    }
}
