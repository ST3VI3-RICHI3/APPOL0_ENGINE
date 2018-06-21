using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Apollo
{
    class Pakgram
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
            using (StreamReader sr = new StreamReader(filetounpack))
            {
                string line = sr.ReadToEnd();
                string sig = line.Substring(0,3);
                if (sig=="pkf")
                {
                    Console.WriteLine(Environment.CurrentDirectory + "/" + pakfile + ".pkf" + " is a PacKFile.");
                }
                else
                {
                    Console.WriteLine(Environment.CurrentDirectory + "/" + pakfile + ".pkf" + " is NOT a PacKFile.");
                    Environment.Exit(-1);
                }
                int fileamount = line.Substring(3,2).ToCharArray()[0];
                fileamount += line.Substring(3,2).ToCharArray()[1];
                int size_of_archive_scanned = 5;
                string[] files = {};
                try
                {
                    for (int i=0; i < fileamount; i++)
                    {
                        int filesize = line.Substring(size_of_archive_scanned,3).ToCharArray()[2];
                        filesize += line.Substring(size_of_archive_scanned,3).ToCharArray()[1] * 256;
                        filesize += line.Substring(size_of_archive_scanned,3).ToCharArray()[0] * 65536;
                        size_of_archive_scanned += 3;
                        int filenamesize = line.Substring(size_of_archive_scanned,1).ToCharArray()[0];
                        size_of_archive_scanned++;
                        string filename = line.Substring(size_of_archive_scanned,filenamesize);
                        size_of_archive_scanned += filenamesize;
                        string file = line.Substring(size_of_archive_scanned, filesize + 1);
                        size_of_archive_scanned += filesize;
                        Array.Resize(ref files,files.Length + 1);
                        files.SetValue(filename, files.Length - 1);
                        Array.Resize(ref files,files.Length + 1);
                        files.SetValue(file, files.Length - 1);
                        Console.WriteLine(filename + " Loaded.");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
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
}
