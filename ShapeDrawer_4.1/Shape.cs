using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;

        public Shape()
        {
            this._color = Color.Yellow;
            this._x = 0.0f;
            this._y = 0.0f;
        }

        public Shape(Color color)
        {
            this._color = color;
            this._x = 0.0f;
            this._y = 0.0f;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public abstract void DrawOutline();

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);
    }
}
