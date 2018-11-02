using IvanochJoseftest.Data;
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
           // MessageBox.Show("Satana perkele");
            //MessageFileWatcher(@"C:\Users\josef\source\repos\stiligafigurer\dickdickdick\IvanochJoseftest\Business", "hej.xml");
        }
        //string Path, string FileName
        public bool MessageFileWatcher()
        {
            FileSystemWatcher Watcher = new FileSystemWatcher();
            Watcher.Path = @"C:\Users\josef\source\repos\stiligafigurer\dickdickdick\IvanochJoseftest\Business";
            Watcher.Filter = "hej.xml";
            Watcher.NotifyFilter = NotifyFilters.LastWrite;
            Watcher.Changed += new FileSystemEventHandler(OnChanged);
            Watcher.EnableRaisingEvents = true;
            return true;
        }

        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Do something here based on the change to the file
            MessageBox.Show("HEj hej hej!");
        }
    }

}

