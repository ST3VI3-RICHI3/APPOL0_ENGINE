using System;

namespace ST3_ENGINE
{
    class Pakgram
    {
        static void Check(string pakfile)
        {

        }

        static void Create(string folder)
        {

        }

        static void Load(string pakfile)
        {

        }

        static void Main(string[] args)
        {
            var unpackorpack = args[0];
            for (var arg = 0; arg < args.Length; arg++)
            {
                if (args[arg] == "/C")
                {
                    Check(args[arg++]);
                }
                if (args[arg] == "-C")
                {
                    Create(args[arg++]);
                }
                if (args[arg] == "-L")
                {
                    Load(args[arg++]);
                }
            }
        }
    }
}
