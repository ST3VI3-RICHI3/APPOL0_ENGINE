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
        private static void Main(string[] args)
        {
            bool dev = false;
            Console.Title = "Debug output | APOLL0 SDK";
            Console.WriteLine("System output check");
            Thread.Sleep(500);
            Console.WriteLine("Hello World");
            Console.WriteLine("Ok!");
            Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine("Arguement check");
            for (var i = 0; i < args.Length; i++)
            {
                if (dev == false)
                {
                    if (args[i] == "-dev")
                    {
                        dev = true;
                        Console.WriteLine("Dev arg found!");
                        Console.WriteLine("Start dev process ...");
                        var devthread = new Thread(() =>
                        {
                            Application.Run(new DevMenu());
                        });
                        devthread.Start();
                    }
                }
            }
            if (args.Length == 0)
            {
                Console.WriteLine("No args found.");
            }
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
            Thread.Sleep(2500);
            Console.WriteLine(" ");
            Console.WriteLine("Load Core...");
            //Load files here
            Console.WriteLine("Done!"); //after this the main app will load and run.  
        }
    }
    internal static class DevCommands
    {
        public static void Beep()
        {
            Console.Beep();
            Console.WriteLine("Dev command: Beep");
        }
    }
}