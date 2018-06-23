using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSDK
{
    static class Program
    {
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
            Console.WriteLine("Start process...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Done!");
            Application.Run(new Form1());
            Console.WriteLine(" ");
            Console.WriteLine("Application Exit");
            Console.Write("press any key to continue");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
