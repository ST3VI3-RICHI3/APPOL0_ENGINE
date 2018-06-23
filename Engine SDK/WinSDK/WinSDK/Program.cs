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
            Splash();
            Console.WriteLine("Done!");
            Console.WriteLine(" ");
            Console.WriteLine("Load Core...");
            //Load files here
            Console.WriteLine("Done!");
            Console.Write("press any key to continue");
            Console.ReadKey(); 
            Environment.Exit(0);
        }
        static void Splash()
        {
            var thread = new Thread(() =>
            {
                Application.Run(new SplashScreen());
            });
            thread.Start();
        }
    }
}
