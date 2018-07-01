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
            Console.Clear();
            utility.title("Cipher Source");
            Text.print(true, "8\"\"\"\"8                               8\"\"\"\"8                              ");
            Text.print(true, "8    \" e  eeeee e   e eeee eeeee     8      eeeee e   e eeeee  eeee eeee ");
            Text.print(true, "8e     8  8   8 8   8 8    8   8     8eeeee 8  88 8   8 8   8  8  8 8    ");
            Text.print(true, "88     8e 8eee8 8eee8 8eee 8eee8e        88 8   8 8e  8 8eee8e 8e   8eee ");
            Text.print(true, "88   e 88 88    88  8 88   88   8    e   88 8   8 88  8 88   8 88   88   ");
            Text.print(true, "88eee8 88 88    88  8 88ee 88   8    8eee88 8eee8 88ee8 88   8 88e8 88ee ");
            Text.print(true, " ");
            Text.print(true, " ");
            Text.print(true, "Load started");
            Console.ReadKey();
        }
    }
}
