using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOLL0
{
    /// <summary>
    /// This class is used during console games, this should be used over default console functions due to efficiency.
    /// </summary>
    public class Console
    {
        /// <summary>
        /// Not to be called by user, used by engine initialisation to setup printing functions.
        /// </summary>
        public static void ConsoleInit()
        {
            PrintThread.Start();
        }
        private static string PrintText = null;
        private static bool NL = false;
        /// <summary>
        /// Prints the given text to the console (console application only)
        /// </summary>
        /// <param name="Text">The text to output, required.</param>
        /// <param name="NewLine">Weather or not a new line is used, not required but must be set to true for a new line.</param>
        public static void Print(string Text, bool NewLine)
        {
            PrintText = Text;
            NL = NewLine;
        }
        private static System.Threading.Thread PrintThread = new System.Threading.Thread(PrintThreadFunc);
        /// <summary>
        /// DO NOT CALL!!! This is a function meant for multithreading, it is not called by normal means, instead runs on a seperate thread. Console.Print() interfaces with this to achive text printing, calling this may result in a frozen appication or unexpected results.
        /// </summary>
        protected static void PrintThreadFunc()
        {
            string Buffer = PrintText;
            while (true)
            {
                if (Buffer != PrintText)
                {
                    Buffer = PrintText;
                    if (NL)
                    {
                        System.Console.WriteLine(Buffer);
                    }
                    else
                    {
                        System.Console.Write(Buffer);
                    }
                }
            }
        }
    }
}
