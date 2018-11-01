using IvanochJoseftest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IvanochJoseftest.Business
{
    class UpdateInterval : Form1
    {
        
        

        public void SetInt5Min()
        {
            Timer t = new Timer();
            
            t.Interval = 5000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

        }
        public void SetInt10Min()
        {
            Timer t = new Timer();

            t.Interval = 10000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

        }
        public void SetInt15Min()
        {
            Timer t = new Timer();

            t.Interval = 15000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

        }

        public void SetInt30Min()
        {
            Timer t = new Timer();

            t.Interval = 30000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

        }

        public void timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Satana perkele");
        }

        
    }
}
