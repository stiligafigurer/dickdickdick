using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IvanochJoseftest.Business
{
    class UpdateInterval
    {
        
        //Nytt objekt för varje podd

        public void SetInterval5Min()
        {
            Timer t = new Timer();


            t.Interval = 5000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

        }

        public void timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Satana perkele");
        }

        
    }
}
