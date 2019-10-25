using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace APOLL0
{
    class GraphicsManager
    {

        //--Section 1 - Graphical Properties--\\

        class Properites
        {
            public static Size WindowSize = new Size(500, 500);
        }

        //------------------------------------\\

        //--Section 2 - File management--\\

        //-------------------------------\\

        //--Section 3 - Video Initialization--\\

        public static void VInit(int mode)
        {
            if (mode == 1)
            {
                //Console app, do nothing & exit function.
            }
            if (mode == 2)
            {
                G2DInit();
            }
            if (mode == 3)
            {
                //G3DInit();
                throw new NotImplementedException();
            }
        }

        private static APOLL0.GameWindow gameWindow = new GameWindow();

        private static void G2DInit()
        {
            Properites.WindowSize = new Size(750, 500);
            gameWindow.Size = Properites.WindowSize;
            gameWindow.FormBorderStyle = FormBorderStyle.None;
            gameWindow.BackColor = Color.Black;
            gameWindow.StartPosition = FormStartPosition.CenterScreen;
            gameWindow.Text = "GameName";
            GameWindowThread.Start();
        }

        private static System.Threading.Thread GameWindowThread = new System.Threading.Thread(GameWindowShow);

        protected static void GameWindowShow()
        {
            gameWindow.Show();
        }

        //------------------------------------\\

        //--Section 4 - 2D video drawing--\\

        public static void DrawLoop(Form GameWindow)
        {
            
        }

        //---------------------------------\\
    }
}
