using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IvanochJoseftest.Data
{
    public static class XMLHandler
    {
        public static Dictionary<string, string> GetEpisodes(string name)
        {
            int length = name.Length - 16;
            name = name.Substring(15, length);
            //Substring vill veta vart den ska börja samt hur många tecken minus sista måsen. 
            string Url = @"http://dellaq.libsyn.com/rss";
            Dictionary<string, string> myList = new Dictionary<string, string>();
            SyndicationFeed feed = XMLPodcastHandler.ReadFromXML(name);
            foreach (SyndicationItem item in feed.Items)
            {
                string[] PodContent = item.Title.Text.Split('.');
                myList.Add(PodContent[0], PodContent[1]);
            }
            return myList;
        }

        public static string[] GetPodcast(string url)
        {
            
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            XMLPodcastHandler.WriteToXML(feed);
            string[] arrOfPodInfo = new string[2];
            arrOfPodInfo[0] = feed.Title.Text;
            arrOfPodInfo[1] = feed.Items.Count().ToString();
            
            return arrOfPodInfo;
        }
    }
}
