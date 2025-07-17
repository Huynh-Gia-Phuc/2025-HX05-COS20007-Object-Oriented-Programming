using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public MyCircle() : this(Color.Blue, 50 + 58)
        {
        }

        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 10);
        }

        public override void Draw()
        {
            if(Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override bool IsAt(Point2D pt)
        {
            double dx = pt.X - X;
            double dy = pt.Y - Y;
            return (dx * dx + dy * dy) <= (_radius * _radius);
        }
    }
}
