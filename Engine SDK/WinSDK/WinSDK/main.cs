using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Xml;

namespace Apollo
{
    public class Tesesest : Form
    {

        public Tesesest()
        {
            // Initialize the window...
            InitializeComponent();
            //
            // Code goes here...
            //
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Tesesest
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Name = "Tesesest";
            this.Text = "Apoll0 Test";
            this.ResumeLayout(false);

        }
        [STAThread]
        public static void Main()
        {
            // Beep and start engine...
            Console.Beep();
            Console.WriteLine("APPOL0 Engine Loading...");
            // Load game files...
            string[] gamedata = Packfiles.Load("testfile");
            // Dump packed data to console (Debug, Temporary)...
            Console.WriteLine("Tesesest");
            for (int i=0; i<gamedata.Length; i++)
            {
                Console.WriteLine(gamedata[i]);
            }
            // ( ͡° ͜ʖ ͡°)
            Console.WriteLine("Tesesesting SUCCeeded!!!!!!");
            // Open a window...
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Tesesest());
        }
    }
}
