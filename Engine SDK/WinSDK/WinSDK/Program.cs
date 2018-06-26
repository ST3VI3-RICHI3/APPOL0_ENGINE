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
            bool nosplash = false;
            bool dev = false;
            Console.Title = "Debug output | APOLL0 SDK";
            Console.WriteLine("System output check");
            Thread.Sleep(500);
            Console.WriteLine("Hello World");
            System.Media.SystemSounds.Beep.Play();
            Console.WriteLine("Ok!");
            Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine("Argument check");
            for (var i = 0; i < args.Length; i++)
            {
                if (dev == false)
                {
                    if (args[i] == "-dev")
                    {
                        dev = true;
                        Console.WriteLine("Dev argument found!");
                        Console.Write("Open Developer menu? Y/N ");
                        try
                        {
                            if (Console.ReadKey().Key == ConsoleKey.Y)
                            {
                                var devthread = new Thread(() =>
                                {
                                    Application.Run(new DevMenu());
                                });
                                Console.WriteLine(" ");
                                Console.WriteLine("Start dev process ...");
                                devthread.Start();
                                Console.WriteLine(" ");
                            }
                        }
                        catch
                        {
                            if (Console.ReadKey().Key == ConsoleKey.N)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("DevMenu not loaded.");
                                Console.WriteLine(" ");
                            }
                        }
                    }
                    if (args[i] == "-nosplash")
                    {
                        nosplash = true;
                        Console.WriteLine("nosplash argument found!");
                    }
                }
            }
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments found.");
            }
            Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine("Initialise window");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Done!");
            Console.WriteLine("Start splash screen...");
            if (nosplash == false)
            {
                var thread = new Thread(() =>
                {
                    Application.Run(new SplashScreen());
                });
                thread.Start();
                Console.WriteLine("Done!");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Failiure: Disabled for session.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
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
        public static void Splash_screen()
        {
            var thread = new Thread(() =>
            {
                Application.Run(new SplashScreen());
            });
            thread.Start();
        }
    }
}