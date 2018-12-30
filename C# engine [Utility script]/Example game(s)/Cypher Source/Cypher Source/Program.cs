//8\"\"\"\"8                               8\"\"\"\"8
//8    \" e  eeeee e   e eeee eeeee     8      eeeee e   e eeeee  eeee eeee
//8e     8  8   8 8   8 8    8   8     8eeeee 8  88 8   8 8   8  8  8 8
//88     8e 8eee8 8eee8 8eee 8eee8e        88 8   8 8e  8 8eee8e 8e   8eee
//88   e 88 88    88  8 88   88   8    e   88 8   8 88  8 88   8 88   88
//88eee8 88 88    88  8 88ee 88   8    8eee88 8eee8 88ee8 88   8 88e8 88ee

//----------------------Credits----------------------
//Lead Programmer(s): ST3VI3 RICHI3 (Alex Stephenson)
//                    Soldier_engie-demo
//---------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Apollo;
using AutoUpdaterDotNET;

namespace Cypher_Source
{
    class Program
    {
        private static string[] SaveData = null;
        private static Thread GameTimeThread = null;
        private static string difficulty = "UNSET";
        static void Main(string[] args)
        {
            string version = "0.1.5.0";
            var random = Apollo.Utility.random;
            Console.WriteLine("Check for updates...");
            AutoUpdater.Start("https://st3.zapto.org/apoll0/games/cipher%20source/update.xml");
            Console.WriteLine("APOLL0 text test.");
            try
            {
                Text.Print("Hello World");
                Console.WriteLine("Test successful!");
            }
            catch
            {
                Console.WriteLine("Test failed.");
                Thread.Sleep(5000);
                Environment.Exit(-1);
            }
            Text.Print("Loading recourses");
            bool PizzaEE = false;
            System.Media.SoundPlayer pizzatime = null;
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-pizza")
                {
                    pizzatime = new System.Media.SoundPlayer(@"pizza.wav");
                    PizzaEE = true;
                }
                if (args[i] == "-save_Test")
                {
                    SaveData = new string[3];
                    SaveData[0] = "name=EgName";
                    SaveData[1] = "Stage=0";
                    SaveData[2] = "Version=" + version;
                    Savefiles.Save("Test", SaveData);
                    Environment.Exit(0);
                }
                if (args[i] == "-load_Test")
                {
                    SaveData = Savefiles.Load("Test");
                    for (int j = 0; j < SaveData.Length; j++)
                    {
                        Console.WriteLine(SaveData[j]);
                    }
                    Console.ReadLine();
                }
                if (args[i] == "-Novid")
                {
                    goto NoVid;
                }
            }
            Console.Clear();
            Text.Print("Generic BIOS copyright 1987.");
            Text.Print("");
            Text.Print("Running RAM check...");
            Time.Sleep(1200);
            Text.Print("4GB detected");
            Console.Clear();
            Console.Beep();
            Text.Print("Boot from CD/DVD");
            Time.Sleep(250);
            Text.Print("Boot from USB");
            Time.Sleep(100);
            Text.Print("boot from HDD", false);
            Time.Sleep(150);
            Console.Clear();
            Text.Print("Loading operating system", false);
            Time.Sleep(2500);
            Console.Clear();
            Utility.Title("Cipher Source");
            Text.Print("8\"\"\"\"8                               8\"\"\"\"8                        ");
            Text.Print("8    \" e  eeeee e   e eeee eeeee     8      eeeee e   e eeeee  eeee eeee  ");
            Text.Print("8e     8  8   8 8   8 8    8   8     8eeeee 8  88 8   8 8   8  8  8 8      ");
            Text.Print("88     8e 8eee8 8eee8 8eee 8eee8e        88 8   8 8e  8 8eee8e 8e   8eee   ");
            Text.Print("88   e 88 88    88  8 88   88   8    e   88 8   8 88  8 88   8 88   88     ");
            Text.Print("88eee8 88 88    88  8 88ee 88   8    8eee88 8eee8 88ee8 88   8 88e8 88ee   ");
            Text.Print(" ");
            Title_slogan_animation();
            Text.Print(" ");
            NoVid:
            Text.Typefast("press any key to play.", false);
            Console.ReadKey(true);
            Console.Clear();
            Text.Print("Encryption is a fallacy.");
            Time.Sleep(100);
            Console.Clear();
            Text.Print("Save name? ", false);
            string SavName = Console.ReadLine();
            string name;
            if (File.Exists(SavName + ".svp") == true)
            {
                SaveData = Savefiles.Load(SavName);
                if (SaveData.Length < 3)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Text.Print("Fatal error:                                                                            ");
                    Text.Print("             Load of save data was succsessful but returned the incorrect array size    ");
                    Text.Print("--------------------------------------End of Error--------------------------------------");
                    Time.Sleep(10*1000);
                    Environment.Exit(-1);
                }
                if (version != (SaveData[2]))
                {
                    Text.Print("Save outdated, please create a new save.");
                }
                else
                {
                    goto SaveSkip;
                }
            }
            Text.Print("Character name? ", false);
            name = Console.ReadLine();
            if (name == "")
            {
                var RNGName = random.Next(0, 10);
                if (RNGName == 0)
                {
                    name = "Jimmy";
                }
                if (RNGName == 1)
                {
                    name = "Bob";
                }
                if (RNGName == 2)
                {
                    name = "Billy";
                }
                if (RNGName == 3)
                {
                    name = "Bin Man Bob";
                }
                if (RNGName == 4)
                {
                    name = "Sally";
                }
                if (RNGName == 5)
                {
                    name = "Jessica";
                }
                if (RNGName == 6)
                {
                    name = "Jeff";
                }
                if (RNGName == 7)
                {
                    name = "Jacob";
                }
                if (RNGName == 8)
                {
                    name = "Katie";
                }
                if (RNGName == 9)
                {
                    name = "kathryn";
                }
                if (RNGName == 10)
                {
                    name = "Lisa";
                }
            }

            if (SavName == "")
            {
                SavName = "Save";
                while (File.Exists(SavName + ".svp") == true)
                {
                    int s = 0;
                    s++;
                    SavName = "Save" + s.ToString();
                }
            }
            Text.Print("Getting variables", false);
            int Stage = 1;
            SaveData = new string[3];
            SaveData[0] = "name=" + name;
            SaveData[1] = "stage=" + Stage;
            SaveData[2] = "version=" + version;
            Text.Print("..Creating save", false);
            Savefiles.Save(SavName, SaveData);
            Text.Print("..starting", false);
            SaveSkip:
            name = SaveData[0];
            Stage = int.Parse(SaveData[1]);
            if (PizzaEE == true)
            {
                pizzatime.PlayLooping();
            }
            if (Stage == 0)
            {
                Tutorial(SavName);
            }

        }
        private static void Title_slogan_animation()
        {
            Text.Print("                      ", false);
            Text.Print("E", false);
            Time.Sleep(100);
            Text.Print("n", false);
            Time.Sleep(100);
            Text.Print("c", false);
            Time.Sleep(100);
            Text.Print("r", false);
            Time.Sleep(100);
            Text.Print("y", false);
            Time.Sleep(100);
            Text.Print("p", false);
            Time.Sleep(100);
            Text.Print("t", false);
            Time.Sleep(150);
            Text.Print("i", false);
            Time.Sleep(200);
            Text.Print("o", false);
            Time.Sleep(250);
            Text.Print("n", false);
            Time.Sleep(500);
            Text.Print( " ", false);
            Time.Sleep(100);
            Text.Print( "i", false);
            Time.Sleep(250);
            Text.Print( "s", false);
            Time.Sleep(100);
            Text.Print( " ", false);
            Time.Sleep(500);
            Text.Print( "o", false);
            Time.Sleep(50);
            Text.Print( "n", false);
            Time.Sleep(100);
            Text.Print( "l", false);
            Time.Sleep(100);
            Text.Print( "y", false);
            Time.Sleep(250);
            Text.Print( " ", false);
            Time.Sleep(250);
            Text.Print( "a", false);
            Time.Sleep(500);
            Text.Print( " ", false);
            Time.Sleep(100);
            Text.Print("f", false);
            Time.Sleep(100);
            Text.Print( "a", false);
            Time.Sleep(100);
            Text.Print( "l", false);
            Time.Sleep(250);
            Text.Print("l", false);
            Time.Sleep(150);
            Text.Print("a", false);
            Time.Sleep(100);
            Text.Print("c", false);
            Time.Sleep(100);
            Text.Print("y", false);
            Time.Sleep(500);
            Text.Print(".", false);
            Time.Sleep(1000);
            Text.Print(" ");
        }
        private static void Tutorial(string SavName)
        {
            var random = Apollo.Utility.random;
            string[] SaveData = Savefiles.Load(SavName);
            string name = SaveData[0];
            //string difficulty = SaveData[7];
            int gametime = 0; //how long it has been in seconds since timer starts
            bool timerenabled = true;
            GameTimeThread = new Thread(() =>
            {
                while (timerenabled == true)
                {
                    gametime = gametime + 1;
                    Time.Sleep(1000);
                }
            });
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Type("Imagine you are in 1991.");
            Text.Type("You are an amateur hacker who chose a group named 'Cipher'.");
            Time.Sleep(1000);
            Text.Type("Here is your test.");
            Apollo.Text.Newline();
            Text.Print("Home/" + name + "> ", false);
            Time.Sleep(1000);
            Text.Type("clear");
            Time.Sleep(250);
            Console.Clear();
            Text.Print( "Home/" + name + "> ", false);
            Time.Sleep(1000);
            Text.Type("ssh 124.268.1.26");
            Time.Sleep(250);
            Text.Print("Connecting to: " + "'124.268.1.26'");
            Time.Sleep(5000);
            Text.Print("Connected");
            Time.Sleep(500);
            Text.Newline();
            Text.Print("Message from 124.268.1.26: Welcome to the Cipher test server.");
            Text.Print("This server will give you a series of tests ranging from easy to hard.");
            Text.Print("This will set your skill level so we can send you missons of your'e difficulty.");
            Text.Print("Type 'start' to start the test");
            Text.Newline();
            CommandFail:
            Text.Print( "Home/" + name + "> ", false);
            string Command = Console.ReadLine();
            if (Command == "start")
            {
                goto Continue;
            }
            if (Command == "exit")
            {
                Environment.Exit(0);
            }
            if (Command == "help")
            {
                Time.Sleep(250);
                Text.Newline();
                Text.Print("Current available commands:");
                Text.Print("start");
                Text.Print("help");
                Text.Print("exit");
                Text.Newline();
                Time.Sleep(250);
                goto CommandFail;
            }
            if (Command == "") { goto CommandFail; }
            else
            {
                Text.Print("Unknown command: '" + Command + "'");
                goto CommandFail;
            }
            Continue:
            GameTimeThread.Start();
            Text.Newline();
            Text.Print("Message from 124.268.1.26: The timer has started. We'll start out with simple stuff, then get harder as we go.");
            Text.Print("Fist you need to open your'e cracker. At the moment you only have a simple one but you can buy better & faster ones later.");
            Text.Newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.Print("Open cracker by trping 'XCrack'");
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Newline();
            CommandFail2:
            Text.Print( "Home/" + name + "> ", false);
            Command = Console.ReadLine();
            if (Command == "XCrack")
            {
                goto Continue2;
            }
            if (Command == "exit")
            {
                Environment.Exit(0);
            }
            if (Command == "help")
            {
                Time.Sleep(250);
                Text.Newline();
                Text.Print("Current available commands:");
                Text.Print("Help");
                Text.Print("XCrack");
                Text.Print("shutdown");
                Text.Print("exit");
                Text.Newline();
                Time.Sleep(250);
                goto CommandFail;
            }
            if (Command == "shutdown")
            {
                int currentmin = DateTime.Now.Minute + 1;
                Text.Print("Shutdown sheduled for " + DateTime.Now + currentmin);
                currentmin = 0;
            }
            else
            {
                Text.Print("Unknown command: '" + Command + "'");
                goto CommandFail2;
            }
            Continue2:
            Text.Newline();
            Text.Print("XCrack");
            Text.Print("Copyright to MrBitz.");
            Text.Newline();
            Text.Print("Connection found, starting automaticly");
            Text.Newline();
            Text.Print( "Crack: [==", false);
            Time.Sleep(500);
            Text.Print("================================================", false);
            Time.Sleep(500);
            Text.Print("==================================================]");
            Text.Newline();
            Text.Print("Username: admin");
            Text.Print("Password: 123456");
            Text.Newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.Print("Type 'login to log in. (obviously)'");
            Console.ForegroundColor = ConsoleColor.Green;
            CommandFail3:
            Text.Print("Home/" + name + "> ", false);
            Command = Console.ReadLine();
            if (Command == "login")
            {
                goto Continue3;
            }
            if (Command == "exit")
            {
                Environment.Exit(0);
            }
            if (Command == "help")
            {
                Time.Sleep(250);
                Text.Newline();
                Text.Print("Current available commands:");
                Text.Print("Help");
                Text.Print("login");
                Text.Print("shutdown");
                Text.Print("exit");
                Text.Newline();
                Time.Sleep(250);
                goto CommandFail3;
            }
            if (Command == "shutdown")
            {
                int currentmin = DateTime.Now.Minute + 1;
                Text.Print("Shutdown sheduled for " + DateTime.Now + currentmin);
                currentmin = 0;
            }
            else
            {
                Text.Print("Unknown command: '" + Command + "'");
                goto CommandFail3;
            }
            Continue3:
            Time.Sleep(250);
            Text.Print("login as: ", false);
            string puzz1_username = Console.ReadLine();
            Text.Print("Password for "+puzz1_username+": ", false);
            string puzz1_passwd = Console.ReadLine();
            if (puzz1_username == "admin")
            {
                for (var i = 0; i < 6; i++)
                {
                    if (puzz1_passwd == "123456")
                    {
                        goto puzz1FinalStage;
                    }
                }
            }
            else
            {
                Text.Print("Access denied");
                goto CommandFail3;
            }
            puzz1FinalStage:
            Text.Print("Ok, your'e in. The following things should be simple, if you know the basic command line.");
            Text.Print("It is just a simple file transfer.");
            Text.Newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.Print("Type 'dir', then open 'File downloader' by typing 'FDownload'");
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Newline();
            CommandFail4:
            Text.Print("root/admin/"+"> ", false);
            Command = Console.ReadLine();
            if (Command == "FDownload")
            {
                goto Continue4;
            }
            if (Command == "dir")
            {
                Text.Newline();
                Text.Print("Direcory listing of root/admin");
                Text.Newline();
                Text.Print("TestInfo.txt");
                Text.Newline();
                goto CommandFail4;
            }
            if (Command == "exit")
            {
                Environment.Exit(0);
            }
            if (Command == "help")
            {
                Time.Sleep(250);
                Text.Newline();
                Text.Print("Current available commands:");
                Text.Print("Help");
                Text.Print("dir");
                Text.Print("FDownload");
                Text.Print("shutdown");
                Text.Print("exit");
                Text.Newline();
                Time.Sleep(250);
                goto CommandFail3;
            }
            if (Command == "shutdown")
            {
                int currentmin = DateTime.Now.Minute + 1;
                Text.Print("Shutdown sheduled for " + DateTime.Now + currentmin);
                currentmin = 0;
            }
            else
            {
                Text.Print("Unknown command: '" + Command + "'");
                goto CommandFail4;
            }
            Continue4:
            Text.Print("File Download (FDOownload)    Copyright to SampleName.");
            FileNotFound:
            Text.Newline();
            Text.Print("File to download:", false);
            string FTD = Console.ReadLine();
            if (FTD == "TestInfo.txt")
            {
                Text.Print("Downloading file " + FTD, false);
                for (var i = 0; i <= 3; i++)
                {
                    Time.Sleep(250);
                    Text.Print(".", false);
                }
                Text.Newline();
                Text.Print("File downloaded!");
            }
            if (FTD == "TestInfo")
            {
                Text.Print("Looking for file '" + FTD + "...");
                Time.Sleep(100);
                Text.Print("Found file: 'TestInfo.txt'.");
                Time.Sleep(50);
                Text.Print("Downloading file " + FTD + ".txt", false);
                for (var i = 0; i <= 3; i++)
                {
                    Time.Sleep(250);
                    Text.Print(".", false);
                }
                Text.Newline();
                Text.Print("File downloaded!");
            }
            else
            {
                Text.Print("Error: File not found.");
                goto FileNotFound;
            }
            Text.Newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.Print("Type exit disconnect & finish your task");
            Console.ForegroundColor = ConsoleColor.Green;
            CommandFail5:
            Text.Newline();
            Text.Print("Root/admin/" + ">", false);
            Command = Console.ReadLine();
            if (Command == "exit")
            {
                goto Continue5;
            }
            else if (Command == "help")
            {
                Text.Newline();
                Text.Print("Current available commands:");
                Text.Print("help");
                Text.Print("exit");
                goto CommandFail5;
            }
            else
            {
                Text.Newline();
                Text.Print("Unknown command: '" + Command + "'");
                goto CommandFail5;
            }
            Continue5:
            Text.Newline();
            Time.Sleep(250);
            Text.Print("Disconnecting from: '124.268.1.26' ");
            Text.Print("Disconnected.");
            EndingCommandReset:
            Text.Print("home/" + name + "/", false);
            Command = Console.ReadLine();
            Command = Command.ToLower();
            if (Command == "help")
            {
                Text.Print("Help - Provides help on a spesific command.");
                Text.Print("ssh - Connects to another computer via secure shell");
                goto EndingCommandReset;

            }
            if (Command.Length >= 3)
            {
                if (Command.Substring(0, 3) == "ssh")
                {
                    if (Command.Length >= 4)
                    {
                        if (Command.Substring(4) == "*")
                        {
                            Text.Print("All know connections:");
                            Text.Print("124.268.1.26 - Cipher test server");
                            Text.Print("124.268.1.25 - Cipher internal server");
                            Text.Print("124.268.1.50 - Cipher drop server");
                        }
                    }
                    else
                    {
                        Text.Print("usage: ssh username@address");
                        goto EndingCommandReset;
                    }
                }
            }
            if (Command == "exit")
            {
                Environment.Exit(0);
            }
            else
            {
                Text.Print("Unknown command: " + Command);
                goto EndingCommandReset;
            }

        }
    }
}
