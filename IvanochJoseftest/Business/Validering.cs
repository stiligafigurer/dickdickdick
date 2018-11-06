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
        public static void IsFilled(string type, string input)
        {
            if (input == "")
            {
                Exception e = new ArgumentException(type + " är inte ifylld.");
                throw e;
            }
        }

        public static void TrueURL(string type, string url)
        {
            try
            {
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
            }
            catch
            {
                Exception e = new ArgumentException(type, " är inte en fungerande url.");
                throw e;
            }
        }

        public static void KategoriCheck(string type, string kategori)
        {

            if (kategori == "")
            {
                Exception e = new ArgumentException(type, " är inte vald");
                throw e; 
            }
        }

        public static void UppFrekCheck(string type, string UppFrek)
        {
            if (UppFrek == "")
            {
                Exception e = new ArgumentException(type, " är inte vald");
                throw e;
            }
        }
        public static void BytKatNamn(string type, string kategori)
        {

            if (kategori == "")
            {
                Exception e = new ArgumentException(type, " har inget värde. Skriv in ett kategorinamn");
                throw e;
            }
        }
    }
}
