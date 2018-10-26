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
            //hej

    }

    private void button2_Click(object sender, EventArgs e)
    {
        button2.Text = "B=======D";
        

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void saveStuff() {
        var fs = new FileStream(@"text.xml", FileMode.Create, FileAccess.Write);
        var sw = new StreamWriter(fs);
        for (var i = 1; i < lvEpisodes.Items.Count; i++)
        {
            sw.WriteLine(lvEpisodes.Items[i].Text);

        }
        sw.Close();

    }

    private void lvPodcast_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        var nameAndEpisode = XMLHandler.GetEpisodes(tbURL.Text);
        for (int i = 0; i < nameAndEpisode.Count; i++)
        {
            string episodeNumber = i.ToString();
            string name;
            nameAndEpisode.TryGetValue(episodeNumber, out name);
            lvEpisodes.Items.Add(episodeNumber).SubItems.Add(name);
        }

        saveStuff();

    }
        
        private void UpdateList()
        {
            lbKategori.Items.Clear();

            foreach (var kategori in kategorier)
            {
                lbKategori.Items.Add(
                kategori
                );
            }
        }

        private void FillCB()
        {
            cbKategori.Items.Clear();

            foreach (var kategori in kategorier)
            {
                cbKategori.Items.Add(kategori);
            }
        }

    private void btnNyKategori_Click_1(object sender, EventArgs e)
    {
            //Validering.TomtFalt();
            var kategorinamn = tbKategori.Text;

            kategorier.Add(kategorinamn);

            foreach (string item in kategorier)
            {
                lbKategori.Items.Add(item);
            }
            kategorier.Sort();
            UpdateList();
            tbKategori.Clear();
        }



        private void btnNyPodcast_Click(object sender, EventArgs e)
        {
            var nameAndNumOfEps = XMLHandler.GetPodcast(tbURL.Text);

            string episodeCount = nameAndNumOfEps[1];
            string name = nameAndNumOfEps[0];
            lvPodcast.Items.Add(episodeCount).SubItems.Add(name);
            saveStuff();
        

            FillCB();

        }

        private void tbKategori_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            var kategori = lbKategori.SelectedItems.ToString();

            

            //foreach (string item in kategorier)
            //{
            //    if (item == kategori)
            //    {
                    lbKategori.Items.Remove(lbKategori.SelectedItem);
                    kategorier.Remove(kategori);
            //    }
            //}


            //kategorier.Sort();

            //UpdateList();

            tbKategori.Clear();

            FillCB();

        }
    }
}
