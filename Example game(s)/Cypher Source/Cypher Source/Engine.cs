using System;
using System.Threading;
using System.IO;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Apollo
{
    class Text
    {
        public static void print(bool newline, string text)
        {
            if (newline == true)
            {
                Console.WriteLine(text);
            }
            if (newline == false)
            {
                Console.Write(text);
            }
        }
		public static void type(bool newline, string text)
        {
            bool newlineenabled = false;
			if (newline == true)
			{

                newlineenabled = true;
            }
			for (var i = 0; i < text.Length; i++)
			{
				if (text.Substring(i, 1) == " ")
				{
					Thread.Sleep(50);
				}
				Thread.Sleep(50);
				Console.Write(text.Substring(i,1));
			}
            if (newlineenabled==true && newlineenabled != false)
            {
                Console.WriteLine("");
            }
        }
		public static void typefast(bool newline, string text)
        {
            if (newline == true)
            {
                Console.WriteLine("");
            }
            for (var i = 0; i < text.Length; i++)
            {
                Thread.Sleep(10);
                Console.Write(text.Substring(i, 1));
            }
        }
    }
	class time
    {
        public static void sleep(int time)
        {
            Thread.Sleep(time);
        }
    }
    class utility
    {
        public static void title(string title)
        {
            Console.Title = title;
        }
    }
    class Packfiles
    {
        public string[] Check(string pakfile)
        {
            string[] na = {"na"};
            return na;
        }

        public string[] Create(string folder)
        {
            string[] na = {"na"};
            return na;
        }

		public string[] Load(string pakfile)
		{
			string filetounpack = Environment.CurrentDirectory + "/" + pakfile + ".pkf";
			if (!File.Exists(filetounpack))
			{
				Console.WriteLine("The specified file does not exist, Exiting...");
				Environment.Exit(-1);
			}
            using (StreamReader sr = new StreamReader(filetounpack))
            {
                string line = sr.ReadToEnd();
                string sig = line.Substring(0, 3);
                if (sig == "pkf")
                {
                    Console.WriteLine(Environment.CurrentDirectory + "/" + pakfile + ".pkf" + " is a PacKFile.");
                }
                else
                {
                    Console.WriteLine(Environment.CurrentDirectory + "/" + pakfile + ".pkf" + " is NOT a PacKFile.");
                    Environment.Exit(-1);
                }
                int fileamount = line.Substring(3, 2).ToCharArray()[0];
                fileamount += line.Substring(3, 2).ToCharArray()[1];
                int size_of_archive_scanned = 5;
                string[] files = { };
                try
                {
                    for (int i = 0; i < fileamount; i++)
                    {
                        int filesize = line.Substring(size_of_archive_scanned, 3).ToCharArray()[2];
                        filesize += line.Substring(size_of_archive_scanned, 3).ToCharArray()[1] * 256;
                        filesize += line.Substring(size_of_archive_scanned, 3).ToCharArray()[0] * 65536;
                        size_of_archive_scanned += 3;
                        int filenamesize = line.Substring(size_of_archive_scanned, 1).ToCharArray()[0];
                        size_of_archive_scanned++;
                        string filename = line.Substring(size_of_archive_scanned, filenamesize);
                        size_of_archive_scanned += filenamesize;
                        string file = line.Substring(size_of_archive_scanned, filesize + 1);
                        size_of_archive_scanned += filesize;
                        Array.Resize(ref files, files.Length + 1);
                        files.SetValue(filename, files.Length - 1);
                        Array.Resize(ref files, files.Length + 1);
                        files.SetValue(file, files.Length - 1);
                        Console.WriteLine(filename + " Loaded.");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Loading of PacKFile FAILED. File may be corrupt or incorrect.");
                    Environment.Exit(-1);
                }
                Console.WriteLine("Loading of PacKFile Succeeded.");
                return files;
            }
        }


        public string[] Pak(string option, string pkf)
        {
            if (option == "/C")
            {
                return Check(pkf);
            }
            if (option == "-C")
            {
                return Create(pkf);
            }
            if (option == "-L")
            {
                return Load(pkf);
            }
            string[] na = {"Could not load PacKFile: No option chosen..."};
            return na;
        }
    }
    class Savefiles
    {
        public string[] Check(string savefile)
        {
            string[] na = {"na"};
            return na;
        }

        public string[] Save(string savefile)
        {
            string[] na = {"na"};
            return na;
        }

        public string[] Load(string savefile)
        {
            string filetoload = Environment.CurrentDirectory + "/" + savefile + ".svp";
            if (!File.Exists(filetoload))
            {
              Console.WriteLine("The specified file does not exist, Exiting...");
              Environment.Exit(-1);
            }
                using (StreamReader sr = new StreamReader(filetoload))
                {
                    string line = sr.ReadToEnd();
                    string sig = line.Substring(0, 3);
                    if (sig == "svp")
                    {
                        Console.WriteLine(Environment.CurrentDirectory + "/" + savefile + ".svp" + " is a SaVePack.");
                    }
                    else
                    {
                        Console.WriteLine(Environment.CurrentDirectory + "/" + savefile + ".svp" + " is NOT a SaVePack.");
                        Environment.Exit(-1);
                    }
                    int fileamount = line.Substring(3, 2).ToCharArray()[0];
                    fileamount += line.Substring(3, 2).ToCharArray()[1];
                    int size_of_archive_scanned = 5;
                    string[] files = { };
                    try
                    {
                        for (int i = 0; i < fileamount; i++)
                        {
                            int filesize = line.Substring(size_of_archive_scanned, 3).ToCharArray()[2];
                            filesize += line.Substring(size_of_archive_scanned, 3).ToCharArray()[1] * 256;
                            filesize += line.Substring(size_of_archive_scanned, 3).ToCharArray()[0] * 65536;
                            size_of_archive_scanned += 3;
                            int filenamesize = line.Substring(size_of_archive_scanned, 1).ToCharArray()[0];
                            size_of_archive_scanned++;
                            string filename = line.Substring(size_of_archive_scanned, filenamesize);
                            size_of_archive_scanned += filenamesize;
                            string file = line.Substring(size_of_archive_scanned, filesize + 1);
                            size_of_archive_scanned += filesize;
                            Array.Resize(ref files, files.Length + 1);
                            files.SetValue(filename, files.Length - 1);
                            Array.Resize(ref files, files.Length + 1);
                            files.SetValue(file, files.Length - 1);
                            Console.WriteLine(filename + " Loaded.");
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Loading of SaVePack FAILED. File may be corrupt or incorrect.");
                        Environment.Exit(-1);
                    }
                    Console.WriteLine("Loading of SaVePack Succeeded.");
                    return files;
                }
            }


        public string[] Sav(string option, string svp)
        {
            if (option == "/C")
            {
                return Check(svp);
            }
            if (option == "-S")
            {
                return Save(svp);
            }
            if (option == "-L")
            {
                return Load(svp);
            }
            string[] na = {"Could not load SaVePack: No option chosen..."};
            return na;
        }
    }
}
