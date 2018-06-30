using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSDK
{
    class CustomCommands
    {
        ///<summary>
        ///<para>Puts the SDK in command mode.</para>
        ///<para>Usage: WinSDK.CustomCommands.CommandMode(latch[True / false])</para>
        ///<para>Note latch determines wether command mode will stay enabled after a command has been sent and ran.</para>
        ///</summary>
        public static void CommandMode(bool latch) //latch defines weather it stays in command more or returns to automatic.
        {
            Console.Write(Environment.CurrentDirectory+"> ");
            string command = Console.ReadLine();
        }
    }
}
