//8\"\"\"\"8                               8\"\"\"\"8
//8    \" e  eeeee e   e eeee eeeee     8      eeeee e   e eeeee  eeee eeee
//8e     8  8   8 8   8 8    8   8     8eeeee 8  88 8   8 8   8  8  8 8
//88     8e 8eee8 8eee8 8eee 8eee8e        88 8   8 8e  8 8eee8e 8e   8eee
//88   e 88 88    88  8 88   88   8    e   88 8   8 88  8 88   8 88   88
//88eee8 88 88    88  8 88ee 88   8    8eee88 8eee8 88ee8 88   8 88e8 88ee

using System;
using System.Threading;
using Apollo;

namespace Cypher_Source
{
    class Program
    {
        static void Main(string[] args)
        {
            var gametime = 0; //how long it has been in seconds since timer starts
            Console.WriteLine("APOLL0 text test.");
            try
            {
                Text.print(true, "Hello World");
                Console.WriteLine("Test successful!");
            }
            catch
            {
                Console.WriteLine("Test failed.");
                Thread.Sleep(5000);
                Environment.Exit(-1);
            }
            Text.print(true, "Loading recourses");
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-pizza")
                {
                    System.Media.SoundPlayer pizzatime = new System.Media.SoundPlayer(@"pizza.wav");
                    pizzatime.Play();
                }
            }
            Console.Clear();
            utility.title("Cipher Source");
            Text.print(true, "8\"\"\"\"8                               8\"\"\"\"8                        ");
			Text.print(true, "8    \" e  eeeee e   e eeee eeeee     8      eeeee e   e eeeee  eeee eeee  ");
			Text.print(true, "8e     8  8   8 8   8 8    8   8     8eeeee 8  88 8   8 8   8  8  8 8      ");
			Text.print(true, "88     8e 8eee8 8eee8 8eee 8eee8e        88 8   8 8e  8 8eee8e 8e   8eee   ");
			Text.print(true, "88   e 88 88    88  8 88   88   8    e   88 8   8 88  8 88   8 88   88     ");
			Text.print(true, "88eee8 88 88    88  8 88ee 88   8    8eee88 8eee8 88ee8 88   8 88e8 88ee   ");
            Text.print(true, " ");
            var GameTimeThread = new Thread(() =>
            {
                while (true)
                {
                    gametime = gametime + 1;
                    time.sleep(1000);
                }
            });
            title_slogan_animation();
            Text.print(true, " ");
            Text.typefast(false, "press any key to play.");
            Console.ReadKey(true);
            Console.Clear();
            Text.print(true, "Encryption is a fallacy.");
            Console.Clear();
            Text.print(false,"Creating save");
            Text.print(true, ".");
            Text.print(false, "starting");
            //Save creation save here
            Console.Clear();
            Text.print(false, "Creating save");
            Text.print(true, ".....Done!");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Text.type(true, "Imagine you are in 1991.");
            Text.type(true, "You are an amateur hacker who chose a group named 'Cipher'.");
            time.sleep(2500);
            Text.type(true, "Here is your test.");
            time.sleep(2500);
            GameTimeThread.Start();
            Console.ReadKey(true);

        }
        private static void title_slogan_animation()
        {
            Text.print(false, "                      ");
            Text.print(false, "E");
            time.sleep(100);
            Text.print(false, "n");
            time.sleep(100);
            Text.print(false, "c");
            time.sleep(100);
            Text.print(false, "r");
            time.sleep(100);
            Text.print(false, "y");
            time.sleep(100);
            Text.print(false, "p");
            time.sleep(100);
            Text.print(false, "t");
            time.sleep(150);
            Text.print(false, "i");
            time.sleep(200);
            Text.print(false, "o");
            time.sleep(250);
            Text.print(false, "n");
            time.sleep(500);
            Text.print(false, " ");
            time.sleep(100);
            Text.print(false, "i");
            time.sleep(250);
            Text.print(false, "s");
            time.sleep(100);
            Text.print(false, " ");
            time.sleep(500);
            Text.print(false, "o");
            time.sleep(50);
            Text.print(false, "n");
            time.sleep(100);
            Text.print(false, "l");
            time.sleep(100);
            Text.print(false, "y");
            time.sleep(250);
            Text.print(false, " ");
            time.sleep(250);
            Text.print(false, "a");
            time.sleep(500);
            Text.print(false, " ");
            time.sleep(100);
            Text.print(false, "f");
            time.sleep(100);
            Text.print(false, "a");
            time.sleep(100);
            Text.print(false, "l");
            time.sleep(250);
            Text.print(false, "l");
            time.sleep(150);
            Text.print(false, "a");
            time.sleep(100);
            Text.print(false, "c");
            time.sleep(100);
            Text.print(false, "y");
            time.sleep(500);
            Text.print(false, ".");
            time.sleep(1000);
            Text.print(true, " ");
        }
    }
}
