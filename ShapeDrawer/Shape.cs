using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color = Color.Chocolate;
        private float _x = 0.0f;
        private float _y = 0.0f;
        private int _width;
        private int _height;

        public Shape(int param)
        {
            _width = param;
            _height = param;
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            { 
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }

        }

        public int Heigh
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public void Draw()
        {
            SplashKit.FillRectangle (_color, _x, _y,
                                     _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            if (pt.X >= _x && pt.X <= _x + _width &&
                pt.Y >= _y && pt.Y <= _y + _height)
                return true;
            else return false;

        }
    }
}
