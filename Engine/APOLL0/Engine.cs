using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOLL0
{
    /// <summary>
    /// Used for engine-wide functions such as initialization and exit.
    /// </summary>
    public class Engine
    {
        public static void Initialize()
        {
            Console.ConsoleInit();
        }
    }
}
