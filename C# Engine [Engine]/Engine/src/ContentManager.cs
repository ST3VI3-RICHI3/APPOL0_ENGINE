using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Media;

namespace Apoll0
{
    public class ContentManager
    {
        /// <summary>
        /// A string array containg all loaded files including their paths.
        /// EG: C:/pack.apak
        /// </summary>
        public static String[] FileIndex;
        public static String LoadPackfile(string Name, string PATH = null)
        {
            if (File.Exists)
            {
                if (PATH = null) {
                    using (StreamReader Reader = new StreamReader(Name))
                    {
                        string Buffer = Reader.ReadLine();
                        while (Buffer != "<Meta>")
                        {
                            Buffer = Reader.ReadLine();
                        }
                        Buffer = Reader.ReadLine();
                        
                    }
                }
            }
            else
            {
                string[] Err = new string[1];
                Err[0] = null;
                return(Err);
            }
        }
    }
}
