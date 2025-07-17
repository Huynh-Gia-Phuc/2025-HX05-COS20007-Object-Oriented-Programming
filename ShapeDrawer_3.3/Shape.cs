using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color = Color.Green;
        private float _x = 0.0f;
        private float _y = 0.0f;
        private int _width;
        private int _height;
        private bool _selected;
        private const int OUTLINE_OFFSET = 5; // Base offset
        private const int STUDENT_ID_LAST_DIGIT = 5; // Replace with your last digit

        public Shape(int width, int height)
        {
            _width = width;
            _height = height;
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

        public int Height
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

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public void DrawOutline()
        {
            int totalOffset = OUTLINE_OFFSET + STUDENT_ID_LAST_DIGIT;
            SplashKit.DrawRectangle(Color.Black, 
                _x - totalOffset, 
                _y - totalOffset,
                _width + (totalOffset * 2), 
                _height + (totalOffset * 2));
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y,
                                     _width, _height);
            if (_selected)
            {
                DrawOutline();
            }
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
