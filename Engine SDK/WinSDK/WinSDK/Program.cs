using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSDK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.Title = "Debug output | APOLL0 SDK";
            Console.WriteLine("System output check");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Hello World");
            Console.Beep();
            Console.WriteLine("Ok!");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine("Initalise window");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Done!");
            Console.WriteLine(" ");
            Console.WriteLine("Starting process...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Done!");
            Application.Run(new Form1());
            
        }
    }
}
