using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2DGame
{
    public partial class GameWindow : Form
    {
        Anim1 anim1 = new Anim1();
        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            Apollo.Graphics.Graphics2D.GraphicsInit(this);
            StartTimer.Enabled = false;
            DrawUpdateTImer.Enabled = true;
        }
        private void DrawUpdateTImer_Tick(object sender, EventArgs e)
        {
            anim1.DrawLoop(this);
        }
    }
    class Anim1 : Apollo.Graphics.Graphics2D
    {
        static int posx = 0;
        static int posy = 0;
        static int num = 1;
        static bool TextShown = false;

        public override void DrawLoop(Form GameWindow)
        {
            if (!TextShown)
            {
                DrawingBrush.Color = Color.White;
                GraphicsOut.DrawString("Demo - Made using APOLL0 Graphics2D", new Font(SystemFonts.DefaultFont, FontStyle.Regular), DrawingBrush, 10, GameWindow.Height - 25);
                TextShown = true;
            }
            DrawingBrush.Color = Color.Green;
            GraphicsOut.FillRectangle(DrawingBrush, new Rectangle(posx, posy, 1, 1));
            posx++;
            num++;
            posy = Math.Sign(posx);
            if (posx > GameWindow.Width - 1)
            {
                GraphicsOut.Clear(Color.Black);
                TextShown=false;
                posx = 0;
            }
            if (num > 180)
            {
                num = 0;
            }
            DrawingBrush.Color = Color.Black;
        }
    }
}
