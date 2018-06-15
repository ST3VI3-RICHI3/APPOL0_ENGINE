using System;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ST3_ENGINE
{
    class Program
    {
        static void Main(string[] args)
        {
            Program GameProgram = new Program();
        	  Console.Beep();
        	  Console.WriteLine("APPOL0 Engine Loading...");
        	  for (var arg = 0; arg < args.Length; arg++)
        	  {
              //Add stuff when needed
        	  }
            Pakgram paker = new Pakgram();
            paker.Pak("-L", "testfile");
        }
    }
}
