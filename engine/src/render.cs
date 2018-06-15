using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ST3_ENGINE
{
    public class MainRender
    {
        public class Vector3d
        {
            public int X;
            public int Y;
            public int Z;
            public Vector3d(int p1, int p2, int p3)
            {
                X = p1;Y = p2;Z = p3;
            }
        }
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
                Vector3d nrm = new Vector3d(0, 0, 0);
                nrm.X = Point1.Y*Point2.Z - Point1.Z*Point2.Y;
                nrm.Y = Point1.Z*Point2.X - Point1.X*Point2.Z;
                nrm.Z = Point1.X*Point2.Y - Point1.Y*Point2.X;
                return nrm;
            }
        }
        public class Block
        {
            MainRender.Polygon[] Mesh;
            public Block(Polygon[] Polys)
            {
                for (int i=0;i<Polys.Length;i++)
                {
                    Mesh[i] = Polys[i];
                }
            }
        }
    }
    class Render
    {
        public class Model
        {
            MainRender.Polygon[] Mesh;
            public Model(MainRender.Polygon[] Polys)
            {
                for (int i=0;i<Polys.Length;i++)
                {
                    Mesh[i] = Polys[i];
                }
            }
        }
        public class Map
        {
            MainRender.Block[] WorldMesh;
            public Map(MainRender.Block[] Blocks)
            {
                for (int i=0;i<Blocks.Length;i++)
                {
                    WorldMesh[i] = Blocks[i];
                }
            }
        }
    }
}
