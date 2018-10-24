using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IvanochJoseftest.Data
{
    class XMLHandler
    {
        public SortedList<string, string> GetXML(string url)
        {
            url = @"https://cdn.radioplay.se/data/rss/490.xml";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            SortedList<string, string> myList = new SortedList<string, string>();
            foreach (SyndicationItem item in feed.Items)
            {
                string[] PodContent = item.Title.Text.Split('.');
                myList.Add(PodContent[0], PodContent[1]);
            }
            return myList;
            
        }
    }
}
