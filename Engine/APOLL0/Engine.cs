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
        /// <summary>
        /// Initialises the engine, mode 1; console. 2l 2D. 3; 3D.
        /// </summary>
        /// <param name="mode"></param>
        public static void Initialize(int mode)
        {
            Console.ConsoleInit(mode);
            GraphicsManager.VInit(mode);
        }
    }
}
