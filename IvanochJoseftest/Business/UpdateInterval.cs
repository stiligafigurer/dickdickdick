﻿using IvanochJoseftest.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace IvanochJoseftest.Business
{
    class UpdateInterval : TimerVirtual
    {
        public string PodName { get; set; }
        public string Url { get; set; }
        private string Kategori = "";
        private int Timer = 0;

        public UpdateInterval(string name, int time, string Url, string Kategori)
        {
            this.Url = Url;
            this.Kategori = Kategori;
            this.Timer = TimerConverter(time);
            this.PodName = name;
            SetInt(Timer);
        }

        public override int TimerConverter(int timer)
        {
            if (timer < 60)
            {
                int MsTimer = (timer * 60) * 1000;
                return MsTimer;
            }
            else return timer;
        }
        
        public event EventHandler myEvent;
        
        public void SetInt(int newTime)
        {
            var timer = new System.Timers.Timer(newTime);
            timer.Elapsed += HandleTimerElapsed;
            timer.Start();

        }

        public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            FireEvent(sender, e);
        }

        public void FireEvent(object sender, EventArgs e)
        {
            myEvent.Invoke(sender, e);
        }
    }

}

