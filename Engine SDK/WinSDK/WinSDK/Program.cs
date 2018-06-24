using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;

namespace WinSDK
{
    internal static class Program
    {
        static void Main()
        {
            Console.Title = "Debug output | APOLL0 SDK";
            Console.WriteLine("System output check");
            Thread.Sleep(500);
            Console.WriteLine("Hello World");
            Console.Beep();
            Console.WriteLine("Ok!");
            Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine("Initalise window");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Done!");
            Console.WriteLine("Start process...");
            var thread = new Thread(() =>
            {

                Application.Run(new SplashScreen());
            });
            thread.Start();
            Console.WriteLine("Done!");
            Console.WriteLine(" ");
            Console.WriteLine("Waiting 2500 to show multithread...");
            Thread.Sleep(2500);
            Console.WriteLine(" ");
            Console.WriteLine("Load Core...");
            //Load files here
            Console.WriteLine("Done!"); //after this the main app will load and run.
        }
    }
}
