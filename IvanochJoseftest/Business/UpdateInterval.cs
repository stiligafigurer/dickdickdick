using IvanochJoseftest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace IvanochJoseftest.Business
{
    class UpdateInterval : Form1
    {
        
        

        public void SetInt(int newTime)
        {
            var timer = new System.Timers.Timer(newTime); 
            timer.Elapsed += HandleTimerElapsed;
            timer.Start();

        }

        public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show("Satana perkele");
        }

        
    }
}
