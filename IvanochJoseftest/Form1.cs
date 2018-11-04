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
using System.IO;
using IvanochJoseftest.Data;
using IvanochJoseftest.Business;

namespace IvanochJoseftest
{
    public partial class Form1 : Form
    {

        List<string> kategorier = new List<string>();
        string SelectedPodcast = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "B=======D";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBoxOnLoad();
            ComboBoxOnLoad();
            FetchAllPodcastOnLoad();
        }
        
        private void lvPodcast_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvPodcast.SelectedItems.Count > 0)
            {
                string podcastName = lvPodcast.SelectedItems[0].ToString();
                SelectedPodcast = podcastName;
                var nameAndEpisode = XMLHandler.GetEpisodes(podcastName);
                lvEpisodes.Items.Clear();
                for (int i = 0; i < nameAndEpisode.Count; i++)
                {
                    string episodeNumber = i.ToString();
                    nameAndEpisode.TryGetValue(episodeNumber, out string name);
                    lvEpisodes.Items.Add(episodeNumber).SubItems.Add(name);
                }

            }
        }

        private void FillCB()
        {
            cbKategori.Items.Clear();
            var listOfCategories = XMLCategoryHandler.ReadAllCategoriesFromXML();

            foreach (var item in listOfCategories)
            {
                cbKategori.Items.Add(item);
            }
        }

        private void btnNyKategori_Click_1(object sender, EventArgs e)
        {
            if (Validering.IsFilled(tbKategori.Text))
            {
                if(XMLCategoryHandler.WriteToXML(tbKategori.Text))
                {
                   lbKategori.Items.Add(tbKategori.Text);
                }
                FillCB();

                lbKategori.Sorted = true;
                tbKategori.Clear();
            
            }
        }
        
        private void btnNyPodcast_Click(object sender, EventArgs e)
        {
            
            if (Validering.IsFilled(tbURL.Text) && Validering.TrueURL(tbURL.Text) && Validering.KategoriCheck(cbKategori.Text) && Validering.UppFrekCheck(cbUppFrek.Text)) {
                var Kategori = cbKategori.SelectedItem.ToString();
                int TimerIndex = 0; 
                switch (cbUppFrek.SelectedIndex)
                {
                    case 0:
                        TimerIndex = 5;
                        break;
                    case 1:
                        TimerIndex = 10;
                        break;
                    case 2:
                        TimerIndex = 15;
                        break;
                    case 3:
                        TimerIndex = 30;
                        break;
                }
                var nameAndNumOfEps = XMLHandler.GetPodcast(tbURL.Text, Kategori, TimerIndex);
                UpdateInterval NewTmer = new UpdateInterval(TimerIndex, tbURL.Text, Kategori);
                string episodeCount = nameAndNumOfEps[0];
                string name = nameAndNumOfEps[1];
                lvPodcast.Items.Add(episodeCount).SubItems.Add(name);
                FillCB();
                tbURL.Clear();

            }

        }

        public void ListBoxOnLoad()
        {

            lbKategori.Items.Clear();
            var ArrOfCategories = XMLCategoryHandler.ReadAllCategoriesFromXML();
            foreach(string item in ArrOfCategories)
            {
                lbKategori.Items.Add(item);
            }
            lbKategori.Sorted = true;
        }

        public void ComboBoxOnLoad()
        {

            string[] lineOfContents = File.ReadAllLines("Kategorier.xml");
            foreach (var line in lineOfContents)
            {
                var SplitOn = new string[] { "\r\n" };
                var ArrOfTokens = line.Split(SplitOn, StringSplitOptions.None);
                cbKategori.Items.Add(ArrOfTokens[0]);
            }
            cbKategori.Sorted = true;
        }

        private void btnTaBortKategori_Click_1(object sender, EventArgs e)
        {
            var kategori = lbKategori.SelectedItem.ToString();
            tbKategori.Clear();
            if (XMLCategoryHandler.RemoveCategoryFromXML(kategori))
            {
                FillCB();
                ListBoxOnLoad();
            }
        }

        private void lvEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEpisodes.SelectedItems.Count > 0)
            {
                var EpisodeName = lvEpisodes.SelectedItems[0].SubItems[1].ToString();
                var PodDesciption = XMLHandler.GetEpisodeInfo(SelectedPodcast, EpisodeName);
                int length = EpisodeName.Length - 19;
                EpisodeName = EpisodeName.Substring(18, length);

                var avsnitt = lvEpisodes.FocusedItem.Index;
                
                tbDescription.Clear();
                tbDescription.AppendText(PodDesciption);
                
;
                label5.Text = "";
                label5.Text += avsnitt + ":" + EpisodeName;
            }
        }
        
        private void btnSparaKategori_Click(object sender, EventArgs e)
        {

            //tbKategori.Clear();
            string nyttNamn = tbKategori.Text;
            
            if (Validering.BytKatNamn(nyttNamn) && File.Exists("kategorier.xml"))
            {

                var gammaltNamn = lbKategori.SelectedItem.ToString();
                XMLHandler.ChangeKategoryName(gammaltNamn, nyttNamn);
                XMLCategoryHandler.RemoveCategoryFromXML(gammaltNamn);
                XMLCategoryHandler.WriteToXML(nyttNamn);
                ListBoxOnLoad();
                FillCB();
             }

        }
 
        private void FetchAllPodcastOnLoad()
        {
            DirectoryInfo d = new DirectoryInfo(@"Database//");
            FileInfo[] Files = d.GetFiles("*.xml");
            List<string> listOfPodName = new List<string>();
            Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
            foreach (var file in Files)
            {
                int length = file.Name.Length - 4;
                string namn = file.Name.Substring(0, length);
                listOfPodName.Add(namn);
            }
            foreach(var item in listOfPodName)
            {
                dict.Add(item, XMLHandler.GetPodcast(item));
            }
            foreach (var thing in dict.Values)
            {
                ListViewItem item = new ListViewItem();
                item.Text = thing[0];
                item.SubItems.Add(thing[1]);
                item.SubItems.Add(thing[2]);
                item.SubItems.Add(thing[3]);
                lvPodcast.Items.Add(item);
            }
            SetPodcastTimersOnLoad(listOfPodName.ToArray());
        }

        private void DisplayPodcastByCategory(string Category)
        {
            List<string[]> listOfPodds = XMLHandler.GetPodcastsByCategory(Category);
            foreach(var Array in listOfPodds)
            {
                ListViewItem item = new ListViewItem();
                item.Text = Array[0];
                item.SubItems.Add(Array[1]);
                item.SubItems.Add(Array[2]);
                item.SubItems.Add(Array[3]);
                lvPodcast.Items.Clear();
                lvPodcast.Items.Add(item);
            }
        }

        private void SetPodcastTimersOnLoad(string[] PoddNames)
        {
            foreach(var podd in PoddNames)
            {
                int Timer = XMLHandler.GetPodcastTimer(podd);
                string Category = XMLHandler.GetPodcastCategory(podd);
                string Url = XMLHandler.GetPodcastUrl(podd);
                new UpdateInterval(Timer, Url, Category);
                
            }
        }
        
        private void btnTaBortPodcast_Click(object sender, EventArgs e)
        {
            if(lvPodcast.SelectedItems.Count > 0 && lvPodcast.SelectedItems.Count < 2)
            {
                var Namn = lvPodcast.SelectedItems[0].Text;
                XMLPodcastHandler.RemoveXML(Namn);
                lvPodcast.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("FEL!");
            }
        }

        private void lbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbKategori.SelectedItems.Count < 2)
            {
                DisplayPodcastByCategory(lbKategori.SelectedItem.ToString());
            }
            
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {
            if(lvPodcast.SelectedItems.Count > 0 && lvPodcast.SelectedItems.Count < 1)
            {
                if(cbKategori.SelectedIndex != 0 && cbUppFrek.SelectedIndex != 0)
                {
                    string Namn = lvPodcast.SelectedItems[0].Text;
                    string Kategori = cbKategori.SelectedItem.ToString();
                    string UppFrek = cbUppFrek.SelectedItem.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Välj en ny kategori och uppdateringsfrekvens för podcasten");
                }
            }
            else
            {
                MessageBox.Show("Välj en podcast du vill redigera");
            }
        }
    }
}
