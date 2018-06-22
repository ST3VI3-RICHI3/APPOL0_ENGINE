// Application Programming Interface for Graphics: APIG
// Pronounced like "A Pig"
// Yes, I know.

namespace Apig
{
	class Structures
	{
		class Vector2D
		{
			double Xpos;
			double Ypos;
            public Vector2D(double X, double Y)
			{
				Xpos = X;
				Ypos = Y;
			}
            public void Transform(double XT, double YT)
			{
				Xpos += XT;
				Ypos += YT;
			}
		}
		class Vector3D
		{
			double Xpos;
			double Ypos;
			double Zpos;
			public Vector3D(double X, double Y, double Z)
			{
				Xpos = X;
				Ypos = Y;
				Zpos = Z;
			}
			public void Transform(double XT, double YT, double ZT)
			{
				Xpos += XT;
				Ypos += YT;
				Zpos += ZT;
			}
		}
	}
}