using System;
using System.Threading;
using System.IO;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Drawing;

namespace Apollo
{
    /// <summary>
    /// Aany console output funcions (Eg: printing text)
    /// </summary>
    class Text
    {
        /// <summary>
        /// Prints the passed text to the console
        /// </summary>
        /// <param name="newline"></param>
        /// <param name="text"></param>
        public static void Print(string text, bool newline = true)
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
        /// <summary>
        /// Simulates typing on a keyboard
        /// </summary>
        /// <param name="newline"></param>
        /// <param name="text"></param>
        public static void Type(string text, bool newline = true)
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
                Console.Write(text.Substring(i, 1));
            }
            if (newlineenabled == true && newlineenabled != false)
            {
                Console.WriteLine("");
            }
        }
        /// <summary>
        /// A fast variation of Text.type
        /// </summary>
        /// <param name="text"></param>
        /// <param name="newline"></param>
        public static void Typefast(string text, bool newline)
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
        /// <summary>
        /// Prints a new line
        /// </summary>
        public static void Newline()
        {
            Console.WriteLine("");
        }
    }
    /// <summary>
    /// Anything to do with time based funtions
    /// </summary>
    class Time
    {
        ///<summary>
        /// Waits for the ammount of time in ms
        /// </summary>
        public static void Sleep(int time)
        {
            Thread.Sleep(time);
        }
    }
    class Utility
    {
        public static void Title(string title)
        {
            Console.Title = title;
        }
        public static Random random = new Random();
        public class Notifications
        {
            public static void Send(string title, string text, int time)
            {
                System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon
                {
                    BalloonTipTitle = title,
                    BalloonTipText = text,
                    Visible = true
                };
                notifyIcon.ShowBalloonTip(time);
                notifyIcon.Dispose();
            }
        }
    }
    class Packfiles
    {
        public static string[] Check(string pakfile)
        {
            string[] na = { "na" };
            return na;
        }

        public static string[] Create(string name)
        {
            string[] na = { "na" };
            return na;
        }

        public static string[] Load(string pakfile)
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


        public static string[] Pak(string option, string pkf)
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
            string[] na = { "Could not load PacKFile: No option chosen..." };
            return na;
        }
    }
    class Files
    {
        public static string[] Read(string file)
        {
            string filetoload = file;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(file);
            }
            catch
            {
                string[] error = new string[1];
                error[0] = "error";
                return error;
            }
            string[] Data = new string[File.ReadAllLines(filetoload).Length];
            int i = 0;
            while (i != Data.Length)
            {
                Data[i] = reader.ReadLine();
                i++;
            }
            reader.Close();
            return Data;
        }
    }
    class Savefiles
    {
        public static string[] Save_Legacy(string savefile, string[] data, string ending = ".svp")
        {
            string filetosave = Environment.CurrentDirectory + "/" + savefile + ending;
            using (BinaryWriter sw = new BinaryWriter(File.Open(filetosave, FileMode.Create)))
            {
                byte[] signature = new byte[3];
                signature[0] = 0x73;
                signature[1] = 0x76;
                signature[2] = 0x70;
                sw.Write(signature);
                short files = (short)(data.Length / 2);
                byte[] leng = new byte[2];
                leng[0] = (byte)(files >> 8);
                leng[1] = (byte)(files);
                sw.Write(leng);
                for (int i = 0; i < data.Length / 2; i++)
                {
                    int varint = data[i * 2 + 1].Length;
                    byte[] bytes = new byte[3];
                    bytes[0] = (byte)(varint >> 16);
                    bytes[1] = (byte)(varint >> 8);
                    bytes[2] = (byte)varint;
                    sw.Write(bytes);
                    byte varnamesize = Convert.ToByte(data[i * 2].Length);
                    sw.Write(varnamesize);
                    byte[] varname = Encoding.ASCII.GetBytes(data[i * 2]);
                    sw.Write(varname);
                    byte[] vartosave = Encoding.ASCII.GetBytes(data[i * 2 + 1]);
                    sw.Write(vartosave);
                }
            }
            string[] returnval = new string[1];
            returnval[0] = "Done.";
            return returnval;
        }

        public static string[] Save(string savefile, string[] data, string ending = ".svp")
        {
            string filetosave = Environment.CurrentDirectory + "/" + savefile + ending;
            using (StreamWriter writer = new StreamWriter(filetosave))
            {
                writer.WriteLine("[Save start]");
                writer.WriteLine("{");
                for (int i = 0; i != data.Length; i++)
                {
                    writer.WriteLine("  " + data[i]);
                }
                writer.WriteLine("}");
            }
            string[] returnval = new string[1];
            returnval[0] = "Done.";
            return returnval;
        }

        public static string[] Load_Legacy(string savefile, string ending = ".svp")
        {
            string filetoload = Environment.CurrentDirectory + "/" + savefile + ending;
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
                catch
                {

                }
                /*catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Loading of SaVePack FAILED. File may be corrupt or incorrect.");
                    Environment.Exit(-1);
                }*/
                Console.WriteLine("Loading of SaVePack Succeeded.");
                return files;
            }
        }
        public static string[] Load(string savefile, string ending = ".svp")
        {
            var filetoload = Environment.CurrentDirectory + "/" + savefile + ending;
            using (StreamReader reader = new StreamReader(filetoload))
            {
                int i = 0;
                string buffer = "NONE";
                bool loading = false;
                string[] data = new string[File.ReadAllLines(filetoload).Length - 3];
                while (buffer != null)
                {
                    if (buffer == "NONE")
                    {
                        goto next;
                    }
                    if (buffer == "[Save start]")
                    {
                        Console.WriteLine("[[Load start]]");
                        goto next;
                    }
                    if (buffer == "{")
                    {
                        loading = true;
                        goto next;
                    }
                    if (buffer == "}")
                    {
                        Console.WriteLine("[[Load end]]");
                        loading = false;
                        goto next;
                    }
                    if (loading == true)
                    {
                        data[i] = buffer;
                        i++;
                    }
                    next:
                    try
                    {
                        buffer = reader.ReadLine().ToString();
                    }
                    catch
                    {
                        buffer = null;
                    }
                }
                i = 0;
                int o = 0;
                int O_Origonal = 0;
                buffer = " ";
                while (buffer == " ")
                {
                    buffer = data[i].ToString().Substring(o, 1);
                    o++;
                }
                O_Origonal = o;
                bool found = false;
                while (i != data.Length)
                {
                    while (found != true)
                    {
                        buffer = data[i].ToString().Substring(o, 1);
                        if (buffer == "=")
                        {
                            buffer = data[i].ToString().Substring(o + 1);
                            found = true;
                            data[i] = buffer;
                        }
                        o++;
                    }
                    i++;
                    o = O_Origonal;
                    found = false;
                }
                return data;
            }
        }
    }
    class Graphics
    {
        class Graphics2D
        {
            private static int X = 0;
            private static int Y = 0;
            public static void Draw(int LengthX, int LengthY)
            {
                throw new NotImplementedException();
            }
        }
    }
}