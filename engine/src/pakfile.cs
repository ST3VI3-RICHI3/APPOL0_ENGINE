using System;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;

namespace ST3_ENGINE
{
    class Pakgram
    {
        public class Format
        {
            public class Header
            {
                public int signature = 7367526;
                public int version = 0x01;
            }
        }
        public void Check(string pakfile)
        {

        }

        public void Create(string folder)
        {

        }

        public void Load(string pakfile)
        {
            string filetounpack = Environment.CurrentDirectory + "/" + pakfile + ".pkf";
            using (StreamReader sr = new StreamReader(filetounpack))
            {
                // Read the file, then output binary gibberish to console for teh lulz of debugging
                string line = sr.ReadToEnd();
                string sig = line.Substring(0,3);
                if (sig=="pkf")
                {
                    Console.WriteLine(Environment.CurrentDirectory + "/" + pakfile + ".pkf" + " is a valid PacKFile.");
                }
                else
                {
                    Console.Beep(800, 150);
                    Thread.Sleep(50);
                    Console.Beep(800, 150);
                    Thread.Sleep(50);
                    Console.Beep(800, 500);
                    Thread.Sleep(500);
                    Console.Beep(800, 750);
                    Thread.Sleep(50);
                    Console.Beep(800, 750);
                    Console.WriteLine(Environment.CurrentDirectory + "/" + pakfile + ".pkf" + " is NOT a valid PacKFile.");
                }
            }
        }

        public void Pak(string option, string pkf)
        {
            if (option == "/C")
            {
                Check(pkf);
            }
            if (option == "-C")
            {
                Create(pkf);
            }
            if (option == "-L")
            {
                Load(pkf);
            }
        }
    }
}
