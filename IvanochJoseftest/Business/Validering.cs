using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IvanochJoseftest.Business
{
    class Validering
    {
        public static bool IsFilled(string input)
        {
            if (input != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Fältet får inte lämnas tomt!");
                return false;
            }
        }

        public static bool TrueURL(string url)
        {
            try
            {
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Skriv in en korrekt URL till en RSS-feed.");
                return false;
            }
        }

        public static bool KategoriCheck(string kategori)
        {

            if (kategori != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Välj en kategori som podden ska tillhöra.");
                return false;
            }
        }
    }
}
