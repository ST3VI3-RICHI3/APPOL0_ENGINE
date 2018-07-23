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
                Text.print(true, "Hello World");
                Console.Beep();
                Text.print(true, "Ok!");
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("!!!FAILSAFE!!!");
                Console.WriteLine("Error in displayng text. Exiting in 5000ms");
                time.sleep(5000);
                Environment.Exit(-1);
            }
            time.sleep(500);
            Text.newline();
            Text.print(true,  "Argument check");
            for (var i = 0; i < args.Length; i++)
            {
                if (dev == false)
                {
                    if (args[i] == "-dev")
                    {
                        dev = true;
                        Text.print(true, "Dev argument found!");
                        Console.Write("Open Developer menu? Y/N ");
                        try
                        {
                            if (Console.ReadKey().Key == ConsoleKey.Y)
                            {
                                var devthread = new Thread(() =>
                                {
                                    Application.Run(new DevMenu());
                                });
                                Text.print(true, " ");
                                Text.print(true, "Start dev process ...");
                                devthread.Start();
                                Text.print(true, " ");
                            }
                        }
                        catch
                        {
                            if (Console.ReadKey().Key == ConsoleKey.N)
                            {
                                Text.print(true, " ");
                                Text.print(true, "DevMenu not loaded.");
                                Text.print(true, " ");
                            }
                        }
                    }
                    if (args[i] == "-nosplash")
                    {
                        nosplash = true;
                        Text.print(true, "nosplash argument found!");
                    }
                }
            }
            if (args.Length == 0)
            {
                Text.print(true, "No arguments found.");
            }
            time.sleep(500);
            Text.print(true, " ");
            Text.print(true, "Initialise window");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Text.print(true, "Done!");
            Text.print(true, "Start splash screen...");
            if (nosplash == false)
            {
                var thread = new Thread(() =>
                {
                    Application.Run(new SplashScreen());
                });
                thread.Start();
                Text.print(true, "Done!");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Text.print(true, "Failiure: Disabled for session.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Text.print(true, " ");
            Text.print(true, "Load Core...");
            //Load files here
            Text.print(true, "Done!"); //after this the main app will load and run.

        }
    }
    internal static class DevCommands
    {
        public static void Beep()
        {
            Console.Beep();
            Text.print(true, "Dev command: Beep");
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
                Text.print(true, "!!!WARNING!!!");
                Text.print(true, "An error will occur if the path or file is incorrect, are you shure? Y/N ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("Note: A invalid key will cancel this without notification.");
                try
                {
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Text.print(true, " ");
                        Packfiles.Load(Path);
                    }
                }
                catch
                {
                    if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        Text.print(true, " ");
                        Text.print(true, "Load Cancled!");
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