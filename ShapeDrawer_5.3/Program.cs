using SplashKitSDK;
using System;
using System.Threading;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Circle,
            Rectangle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 1280, 720);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            Random random = new Random();
            
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                    
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Shape newShape;
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            myDrawing.AddShape(newShape);
                            break;
                        case ShapeKind.Line:
                            // Create all lines at once with random color
                            Color lineColor = SplashKit.RandomColor();
                            for (int i = 0; i < MyLine.NUM_LINES; i++)
                            {
                                newShape = new MyLine(lineColor, SplashKit.MouseX(), SplashKit.MouseY(), i);
                                myDrawing.AddShape(newShape);

                            }
                            //SplashKit.DrawLine(Color.Red, SplashKit.MouseX(), SplashKit.MouseY(), 1280, 720);
                            break;
                        default:
                            newShape = new MyRectangle();
                            newShape.X = SplashKit.MouseX() - 79;
                            newShape.Y = SplashKit.MouseY() - 79;
                            myDrawing.AddShape(newShape);
                            break;
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    List<Shape> selectedShapes = myDrawing.SelectedShapes;
                    foreach (Shape shape in selectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save("E:/COS20007/2025-HX05-COS20007-Object-Oriented-Programming/ShapeDrawer_5.3/TestDrawing.txt");
                    Console.WriteLine("Drawing saved to TestDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("E:/COS20007/2025-HX05-COS20007-Object-Oriented-Programming/ShapeDrawer_5.3/TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
