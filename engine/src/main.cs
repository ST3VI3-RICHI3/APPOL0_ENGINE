using System;
using System.Drawing;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Apollo
{
    public class Tesesest : Form
    {
        private TextBox textBox1;
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
            // Initialize the window...
            this.SuspendLayout();
            this.ClientSize = new Size(1280, 720);
            this.Text = "Apoll0 Test";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        [STAThread]
        public static void Main()
        {
            // Beep and start engine...
            Console.Beep();
            Console.WriteLine("APPOL0 Engine Loading...");
            // Load game files...
            Pakgram paker = new Pakgram();
            string[] gamedata = paker.Pak("-L", "testfile");
            // Dump packed data to console (Debug, Temporary)...
            Console.WriteLine("Tesesest");
            for (int i=0; i<gamedata.Length; i++)
            {
                Console.WriteLine(gamedata[i]);
            }
            // ( ͡° ͜ʖ ͡°)
            Console.WriteLine("Tesesesting SUCCeeded!!!!!!");
            // Open a window...
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tesesest());
        }
    }
}
