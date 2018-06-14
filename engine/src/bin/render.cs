using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;
using SharpDX;

namespace ST3_ENGINE
{
    class Render
    {
        public class Model
        {
            MainRender.Polygon[] Mesh;
            public Model(Polygon[] Polys)
            {
                for (i=0;i<Polys.Length;i++)
                {
                    Mesh[i] = Polys[i];
                }
            }
        }
        public class Map
        {
            MainRender.Block[] WorldMesh;
            public Map(Block[] Blocks)
            {
                for (i=0;i<Blocks.Length;i++)
                {
                    WorldMesh[i] = Blocks[i];
                }
            }
        }
        public class MainRender
        {
            public class Viewport
            {
                Vector3d Pos;
                Vector3d Look;
            }
            public class Polygon
            {
                Vector3d Point1;
                Vector3d Point2;
                Vector3d Point3;
                public Polygon(Vector3d P1, Vector3d P2, Vector3d P3)
                {
                    Point1=P1;Point2=P2;Point3=P3;
                }
                public Vector3d Normal(Polygon Poly)
                {
                    return Vector3d.Cross(Point1, Point2);
                }
            }
            public class Block
            {
                MainRender.Polygon[] Mesh;
                public Block(Polygon[] Polys)
                {
                    for (i=0;i<Polys.Length;i++)
                    {
                        Mesh[i] = Polys[i];
                    }
                }
            }
        }
    }
}
