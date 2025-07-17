using SplashKitSDK;
using System;
using System.Threading;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window windown = new Window("Shape Drawer", 800, 600);
            Shape myShape = new Shape(158);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                myShape.Draw();

                SplashKit.RefreshScreen();

                

                if(SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    Console.WriteLine("clicked");
                    Console.WriteLine(myShape.Heigh);
                    Console.WriteLine(myShape.Width);
                }

                if(SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.IsAt(SplashKit.MousePosition()))
                {
                    myShape.Color = SplashKit.RandomColor();
                }

            }while (!windown.CloseRequested);

        }
    }
}
