using System;

namespace SDK
{
    class Program
    {
        static void Main(string[] args)
        {
            Pakgram = Apolo.Pakgram
            Console.WriteLine("Testing Debug ouputs...");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Hello World!");
            System.Threading.Thread.Sleep(250);
            Console.WriteLine("Test succsessfull!");
            System.Threading.Thread.Sleep(250);
            Console.Clear();
            Console.Write("Starting Load");
            System.Threading.Thread.Sleep(250);
            Console.Write(".");
            System.Threading.Thread.Sleep(250);
            Console.Write(".");
            System.Threading.Thread.Sleep(250);
            Console.WriteLine(".");
            System.Threading.Thread.Sleep(250);
            Console.Write("Namespace Load: System");//fake load to show activity, next load is real.
            System.Threading.Thread.Sleep(125);
            Console.Write(".");
            System.Threading.Thread.Sleep(125);
            Console.Write(".");
            System.Threading.Thread.Sleep(125);
            Console.Write(".");
            System.Threading.Thread.Sleep(125);
            Console.Write(".");
            Console.Write("......");
            System.Threading.Thread.Sleep(250);
            Console.Write("...");
            System.Threading.Thread.Sleep(250);
            Console.WriteLine("..Done!");
            Console.Write("Loading Packfiles");
            Pakgram paker = new Pakgram();
            Console.ReadLine();
        }
    }
}
