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
            if (!(input == ""))
            {
                
            } else
            {
                MessageBox.Show("Skriv in nåt daaaaa!!");   
            }
            
        }

        internal static void TomtFalt()
        {
            throw new NotImplementedException();
        }
    }
}
