using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;

namespace IvanochJoseftest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hej();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "B=======D";
        }

        public void hej()
        {
            string url = @"https://cdn.radioplay.se/data/rss/490.xml";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach(SyndicationItem item in feed.Items)
            {
                string namn = item.Title.Text;
                ListView1.Items.Add(namn);
            }
        }

    }
}
