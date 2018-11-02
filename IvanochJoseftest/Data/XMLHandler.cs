using System;
using System.Collections.Generic;
using System.IO;
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
            double LastEpisodeNumber = 0;
            foreach (SyndicationItem item in feed.Items)
            {
                try
                {
                    string[] PodContent = item.Title.Text.Split('.');
                    myList.Add(PodContent[0], PodContent[1]);
                    LastEpisodeNumber = Int32.Parse(PodContent[0]);
                }
                catch(Exception)
                {
                    string PodContent = item.Title.Text;
                    myList.Add((LastEpisodeNumber + 0.5).ToString(), PodContent.ToString());
                }
            }
            return myList;
        }

        public static string[] GetPodcast(string url, string Kategori, int TimerIndex)
        {
            
            
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            XMLPodcastHandler.WriteToXML(feed, Kategori, TimerIndex);
            string[] arrOfPodInfo = new string[2];
            arrOfPodInfo[0] = feed.Title.Text;
            arrOfPodInfo[1] = feed.Items.Count().ToString();
            return arrOfPodInfo;
            

        }

        public static string[] GetPodcast(string Name)
        {
            SyndicationFeed feed = XMLPodcastHandler.ReadFromXML(Name);
            StreamReader reader = new StreamReader(@"Database//" +"KoT$" + Name + ".txt");
            string Content = reader.ReadToEnd();
            reader.Close();
            var SplitOn = new string[] { "\r\n" };
            string[] KategoriOchTimer = Content.Split(SplitOn, StringSplitOptions.None);
            string[] arrOfPodInfo = new string[4];
            arrOfPodInfo[0] = feed.Title.Text;
            arrOfPodInfo[1] = feed.Items.Count().ToString();
            arrOfPodInfo[2] = KategoriOchTimer[1];
            arrOfPodInfo[3] = KategoriOchTimer[0];
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
