using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;
using Apollo;

namespace WinSDK
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            bool nosplash = false;
            bool dev = false;
            try
            {
                Console.Title = "Debug output | APOLL0 SDK";
            }
            catch
            {

            }
            Console.WriteLine("System output check");
            Thread.Sleep(500);
            try
            {
                Text.Print("Hello World");
                Console.Beep();
                Text.Print("Ok!");
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("!!!FAILSAFE!!!");
                Console.WriteLine("Error in displayng text. Exiting in 5000ms");
                Time.Sleep(5000);
                Environment.Exit(-1);
            }
            Time.Sleep(500);
            Text.Newline();
            Text.Print("Argument check");
            for (var i = 0; i < args.Length; i++)
            {
                if (dev == false)
                {
                    if (args[i] == "-dev")
                    {
                        dev = true;
                        Text.Print("Dev argument found!");
                        Console.Write("Open Developer menu? Y/N ");
                        try
                        {
                            if (Console.ReadKey().Key == ConsoleKey.Y)
                            {
                                var devthread = new Thread(() =>
                                {
                                    Application.Run(new DevMenu());
                                });
                                Text.Print(" ");
                                Text.Print("Start dev process ...");
                                devthread.Start();
                                Text.Print(" ");
                            }
                        }
                        catch
                        {
                            if (Console.ReadKey().Key == ConsoleKey.N)
                            {
                                Text.Print(" ");
                                Text.Print("DevMenu not loaded.");
                                Text.Print(" ");
                            }
                        }
                    }
                    if (args[i] == "-nosplash")
                    {
                        nosplash = true;
                        Text.Print("nosplash argument found!");
                    }
                }
            }
            if (args.Length == 0)
            {
                Text.Print("No arguments found.");
            }
            Time.Sleep(500);
            Text.Print(" ");
            Text.Print("Initialise window");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Text.Print("Done!");
            Text.Print("Start splash screen...");
            var thread = new Thread(() =>
            {
                Application.Run(new SplashScreen());
            });
            if (nosplash == false)
            {
                thread.Start();
                Text.Print("Done!");
            }
            else
            {
                Text.Print("Splash screen disabled, aborting current operation.");
            }
            Text.Print(" ");
            Text.Print("Load Core...");
            Packfiles.Load("testfile");
            Text.Print("Done!"); //after this the main app will load and run.
            Text.Newline();
            SSWait:
            if (thread.IsAlive != true)
            {
                Text.Print("Start main window...");
                Text.Print("Done!");

                Thread MainWinThread = new Thread(() =>
                {
                    Application.Run(new MainWindow.MainWindow());
                });

#pragma warning disable CS0618 // Type or member is obsolete
                MainWinThread.ApartmentState = ApartmentState.STA;
#pragma warning restore CS0618 // Type or member is obsolete
                MainWinThread.Start();
            }
            else
            {
                goto SSWait;
            }
        }
    }
    internal static class DevCommands
    {
        public static void Beep()
        {
            Console.Beep();
            Text.Print("Dev command: Beep");
        }
        public static void Splash_screen()
        {
            var thread = new Thread(() =>
            {
                Application.Run(new SplashScreen());
            });
            thread.Start();
        }
        public class packFile
        {
            public static void load(string Path)
            {
                
                Console.BackgroundColor = ConsoleColor.Red;
                Text.Print("!!!WARNING!!!");
                Text.Print("An error will occur if the path or file is incorrect, are you shure? Y/N ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("Note: A invalid key will cancel this without notification.");
                try
                {
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Text.Print(" ");
                        Packfiles.Load(Path);
                    }
                }
                catch
                {
                    if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        Text.Print(" ");
                        Text.Print("Load Cancled!");
                    }

                }
                finally
                {
                    if (Console.ReadKey().Key != ConsoleKey.Y && Console.ReadKey().Key != ConsoleKey.N)
                    {
                        Text.Newline();
                        Text.Print("No valid input was detected, assuming no.");
                    }
                }
            }
            public static void Create(string name)
            {
                packFile.Create(name);
            }
        }
    }
}