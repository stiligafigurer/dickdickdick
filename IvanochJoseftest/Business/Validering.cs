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
        public static bool IsFilled(string input)
        {
           if (input != "")
            {
                return true;
            } else
            {
                MessageBox.Show("Fältet får inte lämnas tomt!");
                return false;
            }
        }


    }
}
