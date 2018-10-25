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
        var nameAndNumOfEps = XMLHandler.GetPodcast(tbURL.Text);

        string episodeCount = nameAndNumOfEps[1];
        string name = nameAndNumOfEps[0];
        lvPodcast.Items.Add(episodeCount).SubItems.Add(name);
        saveStuff();

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Console.WriteLine("Jävla github");
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

    private void btnNyKategori_Click_1(object sender, EventArgs e)
    {
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
    }
}
