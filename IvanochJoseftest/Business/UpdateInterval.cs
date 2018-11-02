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
        private string Url = "";
        private string Kategori = "";
        private int Timer = 0;

        public UpdateInterval(int time, string Url, string Kategori)
        {
            this.Url = Url;
            this.Kategori = Kategori;
            this.Timer = TimerConverter(time);
            SetInt(Timer);
        }

        private int TimerConverter(int timer)
        {
            int MsTimer = (timer * 60) * 1000;
            return MsTimer;
        }
        public void SetInt(int newTime)
        {
            var timer = new System.Timers.Timer(newTime); 
            timer.Elapsed += HandleTimerElapsed;
            timer.Start();

        }

        public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            XMLHandler.GetPodcast(Url, Kategori, Timer);
            MessageBox.Show("Hej, det funkar");
        }

        
    }
}
