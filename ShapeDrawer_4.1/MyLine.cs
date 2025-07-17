using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;
        private const int ENDPOINT_RADIUS = 5;
        private const float LINE_LENGTH = 40.0f;
        public const int NUM_LINES = 8; // Easy to change number of lines
        private static Random _random = new Random();
        private float _angle; // Store the unique angle for this line

        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        public MyLine(int lineIndex) : this(Color.Red, 0.0f, 0.0f, lineIndex)
        {
        }

        public MyLine(Color color, float startX, float startY, int lineIndex) : base(color)
        {
            this.X = startX;
            this.Y = startY;
            
            // Calculate base angle for this line (in radians)
            float baseAngle = (float)(2 * Math.PI * lineIndex / NUM_LINES);
            
            // Add some random variation to the angle
            this._angle = baseAngle + (float)(_random.NextDouble() * 0.5 - 0.25); // ±0.25 radians variation
            
            // Calculate end point using trigonometry
            this._endX = startX + LINE_LENGTH * (float)Math.Cos(_angle);
            this._endY = startY + LINE_LENGTH * (float)Math.Sin(_angle);
        }

        public override void DrawOutline()
        {
            // Draw circles around start and end points
            SplashKit.DrawCircle(Color.Black, X, Y, ENDPOINT_RADIUS);
            SplashKit.DrawCircle(Color.Black, _endX, _endY, ENDPOINT_RADIUS);
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        }

        public override bool IsAt(Point2D pt)
        {
            //// Calculate distance from point to line
            //double lineLength = Math.Sqrt(Math.Pow(_endX - X, 2) + Math.Pow(_endY - Y, 2));
            //if (lineLength == 0) return false;

            //// Calculate distance from point to line using the line equation
            //double distance = Math.Abs((_endY - Y) * pt.X - (_endX - X) * pt.Y + _endX * Y - _endY * X) / lineLength;

            //// Check if point is within the line segment
            //double dotProduct = ((pt.X - X) * (_endX - X) + (pt.Y - Y) * (_endY - Y)) / (lineLength * lineLength);
            //bool isWithinSegment = dotProduct >= 0 && dotProduct <= 1;

            //return distance <= ENDPOINT_RADIUS && isWithinSegment;
            //return SplashKit.PointOnLine(pt, , 20);
            Line line = SplashKit.LineFrom(X, Y, _endX, _endY);
            return SplashKit.PointOnLine(pt, line, 10);
        }
    }
}
