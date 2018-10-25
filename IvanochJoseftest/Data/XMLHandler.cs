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
        public static Dictionary<string, string> GetEpisodes(string url)
        {
            url = @"http://dellaq.libsyn.com/rss";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            Dictionary<string, string> myList = new Dictionary<string, string>();
            foreach (SyndicationItem item in feed.Items)
            {
                string[] PodContent = item.Title.Text.Split('.');
                myList.Add(PodContent[0], PodContent[1]);
            }
            return myList;
        }

        public static string[] GetPodcast(string url)
        {
            url = @"http://dellaq.libsyn.com/rss";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            XmlDocument xmlDoc = new XmlDocument();
            string[] arrOfPodInfo = new string[2];
            arrOfPodInfo[0] = feed.Title.Text;
            arrOfPodInfo[1] = feed.Items.Count().ToString();
            
            return arrOfPodInfo;
        }
    }
}
