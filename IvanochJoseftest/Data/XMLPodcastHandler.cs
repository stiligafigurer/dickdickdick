﻿using System;
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
                return feed;
            }
            else
            {
                throw new Exception();
            }
        }

        public static bool WriteToXML(SyndicationFeed feed)
        {
            var PoddNamn = feed.Title.Text;
            var path = @"Database//" + PoddNamn + ".xml";
            XmlWriter writer = XmlWriter.Create(path);
            feed.SaveAsRss20(writer);
            writer.Close();
            return true;
        }
    }
}
