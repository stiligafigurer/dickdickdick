using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
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

        public static string GetEpisodeInfo(string PodName, string EpisodeName)
        {
            try
            {
                int EpisodeLength = EpisodeName.Length - 19;
                EpisodeName = EpisodeName.Substring(18, EpisodeLength);
                int PodLength = PodName.Length - 16;
                PodName = PodName.Substring(15, PodLength);
                SyndicationFeed feed = XMLPodcastHandler.ReadFromXML(PodName);
                foreach (var item in feed.Items)
                {
                    string[] PodContent = item.Title.Text.Split('.');
                    if (PodContent[1] == EpisodeName)
                    {
                        var input = item.Summary.Text.ToString();
                        var output = Regex.Replace(input, "<.*?>", String.Empty);
                        return output;
                    }
                }
                return "Ingen information finns";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
