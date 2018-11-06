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
    public partial class Form1 : Form, ICountable
    {

        List<string> kategorier = new List<string>();
        List<UpdateInterval> ListOfTimers = new List<UpdateInterval>();
        string SelectedPodcast = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBoxOnLoad();
            ComboBoxOnLoad();
            FetchAllPodcastOnLoad();
            CountPods();
        }

        private void lvPodcast_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvPodcast.SelectedItems.Count > 0)
            {
                string podcastName = lvPodcast.SelectedItems[0].Text;
                SelectedPodcast = podcastName;
                var nameAndEpisode = XMLHandler.GetEpisodes(podcastName);
                lvEpisodes.Items.Clear();
                for (int i = 0; i < nameAndEpisode.Count; i++)
                {
                    lvEpisodes.Items.Add(nameAndEpisode[i]);
                }
                CountPods();
            }
        }

        private void FillCB()
        {
            cbKategori.Items.Clear();
            var listOfCategories = XMLCategoryHandler.ReadAllCategoriesFromXML();

            foreach (var item in listOfCategories)
            {
                if (item != "")
                {
                    cbKategori.Items.Add(item);
                }
            }
        }

        private void btnNyKategori_Click_1(object sender, EventArgs e)
        {
            try {
                Validering.IsFilled("Kategori", tbKategori.Text);
            
                if (XMLCategoryHandler.WriteToXML(tbKategori.Text))
                {
                    lbKategori.Items.Add(tbKategori.Text);
                }
                FillCB();

                lbKategori.Sorted = true;
                tbKategori.Clear();

            }
            catch(ArgumentException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private async void btnNyPodcast_Click(object sender, EventArgs e)
        {
            try
            {
                Validering.IsFilled("Url:en", tbURL.Text);
                Validering.TrueURL("Url:en", tbURL.Text);
                Validering.KategoriCheck("Kategorin", cbKategori.Text);
                Validering.UppFrekCheck("Uppdateringsfrekvensen", cbUppFrek.Text);
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
                    ListOfTimers.Add(new UpdateInterval(nameAndNumOfEps[0], TimerIndex, tbURL.Text, Kategori));
                    string episodeCount = nameAndNumOfEps[0];
                    string name = nameAndNumOfEps[1];
                    ListViewItem item = new ListViewItem();
                    item.Text = episodeCount;
                    item.SubItems.Add(name);
                    item.SubItems.Add(TimerIndex.ToString());
                    item.SubItems.Add(Kategori);
                    lvPodcast.Items.Add(item);
                    FillCB();
                    tbURL.Clear();
                    Task<bool> longRunningTask = LblFetching();
                    await longRunningTask;
                    lblFetching.Text = "";
                    CountPods();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ListBoxOnLoad()
        {

            lbKategori.Items.Clear();
            var ArrOfCategories = XMLCategoryHandler.ReadAllCategoriesFromXML();
            foreach (string item in ArrOfCategories)
            {
                if (item != "") {
                    lbKategori.Items.Add(item);
                }
            }
            lbKategori.Sorted = true;
        }

        public void ComboBoxOnLoad()
        {

            string[] lineOfContents = XMLCategoryHandler.ReadAllCategoriesFromXML();
            foreach (var line in lineOfContents)
            {
                if (line != "")
                {
                    cbKategori.Items.Add(line);
                }
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
                var EpisodeName = lvEpisodes.SelectedItems[0].Text;
                var PodDesciption = XMLHandler.GetEpisodeInfo(SelectedPodcast, EpisodeName);

                tbDescription.Clear();
                tbDescription.AppendText(PodDesciption);
                tbDescription.Clear();
                tbDescription.AppendText(PodDesciption);
                label5.Text = "";
                label5.Text += EpisodeName;
            }
        }

        private void btnSparaKategori_Click(object sender, EventArgs e)
        {
            string nyttNamn = tbKategori.Text;
            try{
                Validering.BytKatNamn("Kategorin", nyttNamn);
                if(File.Exists("kategorier.xml"))
                {
                    var gammaltNamn = lbKategori.SelectedItem.ToString();
                    XMLHandler.ChangeKategoryName(gammaltNamn, nyttNamn);
                    XMLCategoryHandler.RemoveCategoryFromXML(gammaltNamn);
                    XMLCategoryHandler.WriteToXML(nyttNamn);
                    ListBoxOnLoad();
                    FillCB();

                }
                
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FetchAllPodcastOnLoad()

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
            foreach (var item in listOfPodName)
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

        public void FetchAllPodcasts(object obj, EventArgs e)
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
            foreach (var item in listOfPodName)
            {
                var PodArr = XMLHandler.GetPodcast(item);
                dict.Add(item, PodArr);
            }
            this.UIThread(() => this.lvPodcast.Items.Clear());
            foreach (var thing in dict.Values)
            {
                ListViewItem item = new ListViewItem();
                item.Text = thing[0];
                item.SubItems.Add(thing[1]);
                item.SubItems.Add(thing[2]);
                item.SubItems.Add(thing[3]);
                this.UIThread(() => this.lvPodcast.Items.Add(item));
            }
            SetPodcastTimersOnLoad(listOfPodName.ToArray());
        }

        private void DisplayPodcastByCategory(string Category)
        {
            if (Category != "Alla")
            {
                List<string[]> listOfPodds = XMLHandler.GetPodcastsByCategory(Category);
                lvPodcast.Items.Clear();
                foreach (var Array in listOfPodds)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Array[0];
                    item.SubItems.Add(Array[1]);
                    item.SubItems.Add(Array[2]);
                    item.SubItems.Add(Array[3]);
                    lvPodcast.Items.Add(item);
                }
            }
            else
            {
                FetchAllPodcastOnLoad();
            }
        }

        private void SetPodcastTimersOnLoad(string[] PoddNames)
        {
            foreach (var podd in PoddNames)
            {
                int Timer = XMLHandler.GetPodcastTimer(podd);
                string Category = XMLHandler.GetPodcastCategory(podd);
                string Url = XMLHandler.GetPodcastUrl(podd);
                ListOfTimers.Add(new UpdateInterval(podd, Timer, Url, Category));
                for(int i = 0; i < ListOfTimers.Count(); i++)
                {
                    ListOfTimers[i].myEvent += FetchAllPodcasts;
                }

            }
        }

        private void btnTaBortPodcast_Click(object sender, EventArgs e)
        {
            if (lvPodcast.SelectedItems.Count > 0 && lvPodcast.SelectedItems.Count < 2)
            {
                var Namn = lvPodcast.SelectedItems[0].Text;
                XMLPodcastHandler.RemoveXML(Namn);
                lvPodcast.SelectedItems[0].Remove();
                int index = 0;
                for(var i = 0; i < ListOfTimers.Count(); i++)
                {
                    if(ListOfTimers.ElementAt(i).PodName == Namn)
                    {
                        index = i;
                    }
                }
                ListOfTimers.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Du måste välja en podcast att ta bort");
            }
            CountPods();
        }

        private void lbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbKategori.SelectedItems.Count > 0 && lbKategori.SelectedItems.Count < 2)
            {
                DisplayPodcastByCategory(lbKategori.SelectedItem.ToString());
            }
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {
            if (lvPodcast.SelectedItems.Count > 0 && lvPodcast.SelectedItems.Count < 2)
            {
                if(cbKategori.SelectedItem != null && cbUppFrek.SelectedItem != null)
                {
                    string Namn = lvPodcast.SelectedItems[0].Text;
                    string Kategori = cbKategori.SelectedItem.ToString();
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
                    string Url = "";
                    XMLHandler.ChangeSinglePodCategory(Namn, Kategori);
                    XMLHandler.ChangeSinglePodTimer(Namn, TimerIndex);
                    foreach (var item in ListOfTimers)
                    {
                        if (item.PodName == Namn)
                        {
                            Url = item.Url;
                            ListOfTimers.Remove(item);
                            break;
                        }
                    }
                    ListOfTimers.Add(new UpdateInterval(Namn, TimerIndex, Url, Kategori));
                    lvPodcast.Items.Clear();
                    FetchAllPodcastOnLoad();
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

        public void CountPods()
        {

            for (int i = 0; i < lvPodcast.Items.Count; i++)
            {
                label6.Text = "";
                label6.Text = "Antal podcasts i listan: " + (i + 1).ToString();
            }
        }

        public async Task<bool> LblFetching()
        {
            lblFetching.Text = "Hämtar Podcast";
            await Task.Delay(1000);
            return true;
        }
    }
}
