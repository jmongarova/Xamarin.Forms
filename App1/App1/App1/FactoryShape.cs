using System;
using Xamarin.Forms;


namespace App1
{
    class FactoryShape
    {
        public CShape FactoryMethod(string type)
        {
            Random rnd = new Random();
            int x, y, OffsetX, OffsetY;
            Color ColorShape; 
            switch (type)
            {
                case "Круг":
                    x = rnd.Next(-200, 200);
                    y = rnd.Next(-200, 200);
                    int r = rnd.Next(100, 300);
                    OffsetX = rnd.Next(-100, 100);
                    OffsetY = rnd.Next(-100, 100);
                    ColorShape = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    return new CCircle(x, y, ColorShape, OffsetX, OffsetY, type, r);
                case "Треугольник":
                    x = rnd.Next(-300, 300);
                    y = rnd.Next(-300, 300);
                    int x2 = rnd.Next(-300, 300);
                    int y2 = rnd.Next(-300, 300);
                    int x3 = rnd.Next(-300, 300);
                    int y3 = rnd.Next(-300, 300);
                    OffsetX = rnd.Next(-100, 100);
                    OffsetY = rnd.Next(-100, 100);
                    ColorShape = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    return new CTriangle(x, y, ColorShape, OffsetX, OffsetY, type, x2, y2, x3, y3);
                case "Квадрат":
                    x = rnd.Next(-200, 200);
                    y = rnd.Next(-200, 200);
                    int side = rnd.Next(100, 300);
                    OffsetX = rnd.Next(-100, 100);
                    OffsetY = rnd.Next(-100, 100);
                    ColorShape = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    return new CSquare(x, y, ColorShape, OffsetX, OffsetY, type, side);


            }
            return null;
        }
    }
}
