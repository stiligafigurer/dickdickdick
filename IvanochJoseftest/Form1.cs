using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;

namespace IvanochJoseftest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "B=======D";
            
                string url = @"https://cdn.radioplay.se/data/rss/490.xml";
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    string namn = item.Title.Text;
                    listView1.Items.Add(namn);
                }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Jävla github");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
