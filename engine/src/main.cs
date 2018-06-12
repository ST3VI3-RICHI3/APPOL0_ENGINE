using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ST3_ENGINE
{
    class Program
    {
        public string game;

        public Assembly GameDLL;

        public void SetAndRunGame(string gamename)
        {
            game = gamename;
            try
            {
                GameDLL = Assembly.LoadFile(Environment.CurrentDirectory + "\\" + game + "\\" + game + ".dll");
                if (GameDLL != null)
                {
                    object GameOBJ = GameDLL.CreateInstance("GameRuntimeClass");
                    if (GameOBJ != null)
                    {
                        MethodInfo gamemethodinfo = GameOBJ.GetType().GetMethod("RunGame");
                        gamemethodinfo.Invoke(GameOBJ, new object[0]);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        static void Main(string[] args)
        {
            Program GameProgram = new Program();
            Console.Beep();
            Console.WriteLine("ST3 Engine Loading...");
            for (var arg = 0; arg < args.Length; arg++)
            {
                if (args[arg] == "-game")
                {
                    GameProgram.SetAndRunGame(args[arg + 1]);
                    Console.WriteLine("Engine Loaded.");
                }
            }
        }
    }
}
