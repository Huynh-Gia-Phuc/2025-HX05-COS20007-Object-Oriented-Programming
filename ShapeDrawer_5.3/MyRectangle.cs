using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;
using MyGame;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100 + 58, 100 + 58)
        {
        }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            this._width = width;
            this._height = height;
            this.X = x;
            this.Y = y;
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 5, Y - 5, _width + 10, _height + 10);
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.X >= X && pt.X <= X + _width &&
                   pt.Y >= Y && pt.Y <= Y + _height;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }
    }
}
