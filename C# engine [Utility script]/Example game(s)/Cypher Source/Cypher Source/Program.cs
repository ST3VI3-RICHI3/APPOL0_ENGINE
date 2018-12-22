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
            var random = Apollo.utility.random;
            Console.WriteLine("Check for updates...");
            AutoUpdater.Start("https://st3.zapto.org/apoll0/games/cipher%20source/update.xml");
            Console.WriteLine("APOLL0 text test.");
            try
            {
                Text.print("Hello World");
                Console.WriteLine("Test successful!");
            }
            catch
            {
                Console.WriteLine("Test failed.");
                Thread.Sleep(5000);
                Environment.Exit(-1);
            }
            Text.print("Loading recourses");
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
                    SaveData = new string[6];
                    SaveData[0] = "name";
                    SaveData[1] = "EGName";
                    SaveData[2] = "Stage";
                    SaveData[3] = "1";
                    SaveData[4] = "Version";
                    SaveData[5] = version;
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
            Text.print("Generic BIOS copyright 1987.");
            Text.print("");
            Text.print("Running RAM check...");
            time.sleep(1200);
            Text.print("4GB detected");
            Console.Clear();
            Console.Beep();
            Text.print("Boot from CD/DVD");
            time.sleep(250);
            Text.print("Boot from USB");
            time.sleep(100);
            Text.print("boot from HDD", false);
            time.sleep(150);
            Console.Clear();
            Text.print("Loading operating system", false);
            time.sleep(2500);
            Console.Clear();
            utility.title("Cipher Source");
            Text.print("8\"\"\"\"8                               8\"\"\"\"8                        ");
            Text.print("8    \" e  eeeee e   e eeee eeeee     8      eeeee e   e eeeee  eeee eeee  ");
            Text.print("8e     8  8   8 8   8 8    8   8     8eeeee 8  88 8   8 8   8  8  8 8      ");
            Text.print("88     8e 8eee8 8eee8 8eee 8eee8e        88 8   8 8e  8 8eee8e 8e   8eee   ");
            Text.print("88   e 88 88    88  8 88   88   8    e   88 8   8 88  8 88   8 88   88     ");
            Text.print("88eee8 88 88    88  8 88ee 88   8    8eee88 8eee8 88ee8 88   8 88e8 88ee   ");
            Text.print(" ");
            title_slogan_animation();
            Text.print(" ");
            NoVid:
            Text.typefast("press any key to play.", false);
            Console.ReadKey(true);
            Console.Clear();
            Text.print("Encryption is a fallacy.");
            time.sleep(100);
            Console.Clear();
            Text.print("Save name? ", false);
            string SavName = Console.ReadLine();
            string name;
            if (File.Exists(SavName + ".svp") == true)
            {
                SaveData = Savefiles.Load(SavName);
                goto SaveSkip;
            }
            Text.print("Character name? ", false);
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
            Text.print("Getting variables", false);
            int Stage = 1;
            SaveData = new string[6];
            SaveData[0] = "name";
            SaveData[1] = "EGName";
            SaveData[2] = "Stage";
            SaveData[3] = "1";
            SaveData[4] = "Version";
            SaveData[5] = version;
            Text.print("..Creating save", false);
            Savefiles.Save(SavName, SaveData);
            Text.print("..starting", false);
            SaveSkip:
            name = SaveData[1];
            Stage = Int32.Parse(SaveData[3]);
            if (PizzaEE == true)
            {
                pizzatime.PlayLooping();
            }
            if (Stage == 1)
            {
                tutorial(SavName);
            }
        }
        private static void title_slogan_animation()
        {
            Text.print("                      ", false);
            Text.print("E", false);
            time.sleep(100);
            Text.print("n", false);
            time.sleep(100);
            Text.print("c", false);
            time.sleep(100);
            Text.print("r", false);
            time.sleep(100);
            Text.print("y", false);
            time.sleep(100);
            Text.print("p", false);
            time.sleep(100);
            Text.print("t", false);
            time.sleep(150);
            Text.print("i", false);
            time.sleep(200);
            Text.print("o", false);
            time.sleep(250);
            Text.print("n", false);
            time.sleep(500);
            Text.print( " ", false);
            time.sleep(100);
            Text.print( "i", false);
            time.sleep(250);
            Text.print( "s", false);
            time.sleep(100);
            Text.print( " ", false);
            time.sleep(500);
            Text.print( "o", false);
            time.sleep(50);
            Text.print( "n", false);
            time.sleep(100);
            Text.print( "l", false);
            time.sleep(100);
            Text.print( "y", false);
            time.sleep(250);
            Text.print( " ");
            time.sleep(250);
            Text.print( "a");
            time.sleep(500);
            Text.print( " ");
            time.sleep(100);
            Text.print("f", false);
            time.sleep(100);
            Text.print( "a", false);
            time.sleep(100);
            Text.print( "l", false);
            time.sleep(250);
            Text.print("l", false);
            time.sleep(150);
            Text.print("a", false);
            time.sleep(100);
            Text.print("c", false);
            time.sleep(100);
            Text.print("y", false);
            time.sleep(500);
            Text.print(".", false);
            time.sleep(1000);
            Text.print(" ");
        }
        private static void tutorial(string SavName)
        {
            var random = Apollo.utility.random;
            string[] SaveData = Savefiles.Load(SavName);
            string name = SaveData[1];
            //string difficulty = SaveData[7];
            int gametime = 0; //how long it has been in seconds since timer starts
            bool timerenabled = true;
            GameTimeThread = new Thread(() =>
            {
                while (timerenabled == true)
                {
                    gametime = gametime + 1;
                    time.sleep(1000);
                }
            });
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Text.type("Imagine you are in 1991.");
            Text.type("You are an amateur hacker who chose a group named 'Cipher'.");
            time.sleep(1000);
            Text.type("Here is your test.");
            Apollo.Text.newline();
            Text.print("Home/" + name + "> ", false);
            time.sleep(1000);
            Text.type("clear");
            time.sleep(250);
            Console.Clear();
            Text.print( "Home/" + name + "> ", false);
            time.sleep(1000);
            Text.type("ssh 124.268.1.26");
            time.sleep(250);
            Text.print("Connecting to: " + "'124.268.1.26'");
            time.sleep(5000);
            Text.print("Connected");
            time.sleep(500);
            Text.newline();
            Text.print("Message from 124.268.1.26: Welcome to the Cipher test server.");
            Text.print("This server will give you a series of tests ranging from easy to hard.");
            Text.print("This will set your skill level so we can send you missons of your'e difficulty.");
            Text.print("Type 'start' to start the test");
            Text.newline();
            CommandFail:
            Text.print( "Home/" + name + "> ", false);
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
                time.sleep(250);
                Text.newline();
                Text.print("Current available commands:");
                Text.print("start");
                Text.print("help");
                Text.print("exit");
                Text.newline();
                time.sleep(250);
                goto CommandFail;
            }
            if (Command == "") { goto CommandFail; }
            else
            {
                Text.print("Unknown command: '" + Command + "'");
                goto CommandFail;
            }
            Continue:
            GameTimeThread.Start();
            Text.newline();
            Text.print("Message from 124.268.1.26: The timer has started. We'll start out with simple stuff, then get harder as we go.");
            Text.print("Fist you need to open your'e cracker. At the moment you only have a simple one but you can buy better & faster ones later.");
            Text.newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.print("Open cracker by trping 'XCrack'");
            Console.ForegroundColor = ConsoleColor.Green;
            Text.newline();
            CommandFail2:
            Text.print( "Home/" + name + "> ", false);
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
                time.sleep(250);
                Text.newline();
                Text.print("Current available commands:");
                Text.print("Help");
                Text.print("XCrack");
                Text.print("shutdown");
                Text.print("exit");
                Text.newline();
                time.sleep(250);
                goto CommandFail;
            }
            if (Command == "shutdown")
            {
                int currentmin = DateTime.Now.Minute + 1;
                Text.print("Shutdown sheduled for " + DateTime.Now + currentmin);
                currentmin = 0;
            }
            else
            {
                Text.print("Unknown command: '" + Command + "'");
                goto CommandFail2;
            }
            Continue2:
            Text.newline();
            Text.print("XCrack");
            Text.print("Copyright to MrBitz.");
            Text.newline();
            Text.print("Connection found, starting automaticly");
            Text.newline();
            Text.print( "Crack: [==", false);
            time.sleep(500);
            Text.print("================================================", false);
            time.sleep(500);
            Text.print("==================================================]");
            Text.newline();
            Text.print("Username: admin");
            Text.print("Password: 123456");
            Text.newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.print("Type 'login to log in. (obviously)'");
            Console.ForegroundColor = ConsoleColor.Green;
            CommandFail3:
            Text.print("Home/" + name + "> ", false);
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
                time.sleep(250);
                Text.newline();
                Text.print("Current available commands:");
                Text.print("Help");
                Text.print("login");
                Text.print("shutdown");
                Text.print("exit");
                Text.newline();
                time.sleep(250);
                goto CommandFail3;
            }
            if (Command == "shutdown")
            {
                int currentmin = DateTime.Now.Minute + 1;
                Text.print("Shutdown sheduled for " + DateTime.Now + currentmin);
                currentmin = 0;
            }
            else
            {
                Text.print("Unknown command: '" + Command + "'");
                goto CommandFail3;
            }
            Continue3:
            time.sleep(250);
            Text.print("login as: ", false);
            string puzz1_username = Console.ReadLine();
            Text.print("Password for "+puzz1_username+": ", false);
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
                Text.print("Access denied");
                goto CommandFail3;
            }
            puzz1FinalStage:
            Text.print("Ok, your'e in. The following things should be simple, if you know the basic command line.");
            Text.print("It is just a simple file transfer.");
            Text.newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.print("Type 'dir', then open 'File downloader' by typing 'FDownload'");
            Console.ForegroundColor = ConsoleColor.Green;
            Text.newline();
            CommandFail4:
            Text.print("root/admin/"+"> ", false);
            Command = Console.ReadLine();
            if (Command == "FDownload")
            {
                goto Continue4;
            }
            if (Command == "dir")
            {
                Text.newline();
                Text.print("Direcory listing of root/admin");
                Text.newline();
                Text.print("TestInfo.txt");
                Text.newline();
                goto CommandFail4;
            }
            if (Command == "exit")
            {
                Environment.Exit(0);
            }
            if (Command == "help")
            {
                time.sleep(250);
                Text.newline();
                Text.print("Current available commands:");
                Text.print("Help");
                Text.print("dir");
                Text.print("FDownload");
                Text.print("shutdown");
                Text.print("exit");
                Text.newline();
                time.sleep(250);
                goto CommandFail3;
            }
            if (Command == "shutdown")
            {
                int currentmin = DateTime.Now.Minute + 1;
                Text.print("Shutdown sheduled for " + DateTime.Now + currentmin);
                currentmin = 0;
            }
            else
            {
                Text.print("Unknown command: '" + Command + "'");
                goto CommandFail4;
            }
            Continue4:
            Text.print("File Download (FDOownload)    Copyright to SampleName.");
            FileNotFound:
            Text.newline();
            Text.print("File to download:", false);
            string FTD = Console.ReadLine();
            if (FTD == "TestInfo.txt")
            {
                Text.print("Downloading file " + FTD, false);
                for (var i = 0; i <= 3; i++)
                {
                    time.sleep(250);
                    Text.print(".", false);
                }
                Text.newline();
                Text.print("File downloaded!");
            }
            if (FTD == "TestInfo")
            {
                Text.print("Looking for file '" + FTD + "...");
                time.sleep(100);
                Text.print("Found file: 'TestInfo.txt'.");
                time.sleep(50);
                Text.print("Downloading file " + FTD + ".txt", false);
                for (var i = 0; i <= 3; i++)
                {
                    time.sleep(250);
                    Text.print(".", false);
                }
                Text.newline();
                Text.print("File downloaded!");
            }
            else
            {
                Text.print("Error: File not found.");
                goto FileNotFound;
            }
            Text.newline();
            Console.ForegroundColor = ConsoleColor.Blue;
            Text.print("Type exit disconnect & finish your task");
            Console.ForegroundColor = ConsoleColor.Green;
            CommandFail5:
            Text.newline();
            Text.print("Root/admin/" + ">", false);
            Command = Console.ReadLine();
            if (Command == "exit")
            {
                goto Continue5;
            }
            else if (Command == "help")
            {
                Text.newline();
                Text.print("Current available commands:");
                Text.print("help");
                Text.print("exit");
                goto CommandFail5;
            }
            else
            {
                Text.newline();
                Text.print("Unknown command: '" + Command + "'");
                goto CommandFail5;
            }
            Continue5:
            Text.newline();
            time.sleep(250);
            Text.print("Disconnecting from: '124.268.1.26' ");
            Text.print("Disconnected.");
            EndingCommandReset:
            Text.print("home/" + name + "/", false);
            Command = Console.ReadLine();
            Command = Command.ToLower();
            if (Command == "help")
            {
                Text.print("Help - Provides help on a spesific command.");
                Text.print("ssh - Connects to another computer via secure shell");
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
                            Text.print("All know connections:");
                            Text.print("124.268.1.26 - Cipher test server");
                            Text.print("124.268.1.25 - Cipher internal server");
                            Text.print("124.268.1.50 - Cipher drop server");
                        }
                    }
                    else
                    {
                        Text.print("usage: ssh username@address");
                        goto EndingCommandReset;
                    }
                }
            }
            else
            {
                Text.print("Unknown command: " + Command);
                goto EndingCommandReset;
            }

        }
    }
}
