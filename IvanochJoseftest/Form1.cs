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
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lvPodcast_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvPodcast.SelectedItems.Count > 0)
            {
                var nameAndEpisode = XMLHandler.GetEpisodes(lvPodcast.SelectedItems[0].ToString());
                lvEpisodes.Items.Clear();
                for (int i = 0; i < nameAndEpisode.Count; i++)
                {
                    string episodeNumber = i.ToString();
                    nameAndEpisode.TryGetValue(episodeNumber, out string name);
                    lvEpisodes.Items.Add(episodeNumber).SubItems.Add(name);
                }

            }
        }

        private void UpdateList()
        {
           
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
            var nameAndNumOfEps = XMLHandler.GetPodcast(tbURL.Text);

            string episodeCount = nameAndNumOfEps[0];
            string name = nameAndNumOfEps[1];
            lvPodcast.Items.Add(episodeCount).SubItems.Add(name);
            //saveStuff();


            FillCB();

        }

        private void tbKategori_TextChanged(object sender, EventArgs e)
        {

        }

        //private void btnTaBortKategori_Click(object sender, EventArgs e)
        //{
        //    var kategori = lbKategori.SelectedItems.ToString();
        //    tbKategori.Clear();
        //    XMLCategoryHandler.RemoveCategoryFromXML(kategori);
        //    FillCB();
        //    ListBoxOnLoad();

        //}
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
                var nameAndEpisode = XMLHandler.GetEpisodes(lvPodcast.SelectedItems[0].ToString());
                lvEpisodes.Items.Clear();
                for (int i = 0; i < nameAndEpisode.Count; i++)
                {
                    string episodeNumber = i.ToString();
                    string name;
                    nameAndEpisode.TryGetValue(episodeNumber, out name);
                    lvEpisodes.Items.Add(episodeNumber).SubItems.Add(name);
                }

            }
            //Denna blir lurig. M�ste h�mta namnet p� podden samt avsnittsnamnet och f� ut beskrivningen.
            //NEVERMIND! Vi sparar en variabel med namnet p� podden i Form1 och anv�nder den f�r info. 
        }
    }
}
