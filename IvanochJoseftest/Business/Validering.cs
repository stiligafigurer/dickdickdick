using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IvanochJoseftest.Business
{
    class Validering
    {


        public void TomtFalt(string input)
        {
            if ((input == ""))
            {
                MessageBox.Show("Skriv in nåt!!");
            }
            
        }

        internal static void TomtFalt()
        {
            throw new NotImplementedException();
        }
    }
}
