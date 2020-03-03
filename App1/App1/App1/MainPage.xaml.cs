using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Threading;


namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Random rnd = new Random();
        CShape[] shapes = new CShape[300];
   
       
        int IteratorShape = 0;                                       //счетчик для массива типов фигур
        int width;
        int height;
        public MainPage()
        {
             InitializeComponent();
            TimerCallback tm = new TimerCallback(CountOffset);
            Timer timer = new Timer(tm, null, 0, 500);                  // создаем таймер
        }
        public void CountOffset(object obj)                             //движение фигур
        {
            if (shapes != null)
            {
                for (int l = 0; l < IteratorShape; l++)
                {
                    if (shapes[l].Type == "Круг")
                    {
                        CCircle circle = shapes[l] as CCircle;
                        if (Math.Abs(circle.PosX)+ circle.Radius + Math.Abs(circle.OffsetX)> width  / 2)
                        {
                            circle.OffsetX *= -1;
                        }
                        if (Math.Abs(circle.PosY) + circle.Radius + Math.Abs(circle.OffsetY) > height / 2)
                        {
                            circle.OffsetY *= -1;
                        }
                        circle.PosX += circle.OffsetX;
                        circle.PosY += circle.OffsetY;
                        
                    }
                    else if (shapes[l].Type == "Треугольник")
                    {
                        CTriangle triangle = shapes[l] as CTriangle;
                        if (Math.Abs(triangle.PosX) + Math.Abs(triangle.OffsetX) > width / 2 ||
                            Math.Abs(triangle.PosX2) + Math.Abs(triangle.OffsetX) > width / 2 ||
                            Math.Abs(triangle.PosX3) + Math.Abs(triangle.OffsetX) > width / 2)
                        {
                            triangle.OffsetX *= -1;
                        }
                        if (Math.Abs(triangle.PosY) + Math.Abs(triangle.OffsetY) > height / 2 ||
                            Math.Abs(triangle.PosY2) + Math.Abs(triangle.OffsetY) > height / 2 ||
                            Math.Abs(triangle.PosY3) + Math.Abs(triangle.OffsetY) > height / 2)
                        {
                            triangle.OffsetY *= -1;
                        }
                        triangle.PosX += triangle.OffsetX;
                        triangle.PosX2 += triangle.OffsetX;
                        triangle.PosX3 += triangle.OffsetX;
                        triangle.PosY += triangle.OffsetY;
                        triangle.PosY2 += triangle.OffsetY;
                        triangle.PosY3 += triangle.OffsetY;
                    }
                    else if (shapes[l].Type == "Квадрат")
                    {
                        CSquare square = shapes[l] as CSquare;
                        if (Math.Abs(square.PosX + (square.SquareSide / 2)) + (square.SquareSide / 2) + Math.Abs(square.OffsetX) > width / 2)
                        {
                            square.OffsetX *= -1;
                        }
                        if (Math.Abs(square.PosY + (square.SquareSide / 2)) + (square.SquareSide / 2) + Math.Abs(square.OffsetY) > height / 2)
                        {
                            square.OffsetY  *= -1;
                        }
                        square.PosX += square.OffsetX;
                        square.PosY += square.OffsetY;
                    }
                }
                SKC.InvalidateSurface();
            }
        }
        void OnHslCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {

            width = args.Info.Width;
            height = args.Info.Height;
            args.Surface.Canvas.Clear();
            if(shapes!=null)
            {
                for (int l=0; l < IteratorShape; l++)
                {
                    if (shapes[l].Type == "Круг")
                    {
                        CCircle circle = shapes[l] as CCircle;
                        SKPaint paint = new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Color = circle.ColorShape.ToSKColor(),
                        };
                        args.Surface.Canvas.DrawCircle((args.Info.Width  / 2) + circle.PosX, (args.Info.Height  / 2) + circle.PosY, circle.Radius, paint);

                    }
                    else if (shapes[l].Type == "Треугольник")
                    {
                        CTriangle triangle = shapes[l] as CTriangle;
                        // Create the path
                        SKPath path = new SKPath();
                        SKPaint fillPaint = new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Color = triangle.ColorShape.ToSKColor(),
                        };
                        path.MoveTo((args.Info.Width / 2) + triangle.PosX, (args.Info.Height / 2) + triangle.PosY);
                        path.LineTo((args.Info.Width / 2) + triangle.PosX2, (args.Info.Height / 2) + triangle.PosY2);
                        path.LineTo((args.Info.Width / 2) + triangle.PosX3, (args.Info.Height / 2) + triangle.PosY3);
                        path.Close();

                       
                        args.Surface.Canvas.DrawPath(path, fillPaint);

                    }
                    else if (shapes[l].Type == "Квадрат")
                    {
                        CSquare square = shapes[l] as CSquare;
                        SKPaint paint3 = new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Color = square.ColorShape.ToSKColor(),
                        };
                        args.Surface.Canvas.DrawRect((args.Info.Width / 2) + square.PosX, (args.Info.Height / 2) + square.PosY, square.SquareSide, square.SquareSide, paint3);

                    }
                         
                }
            }
        }
        private void CircleClick(object sender, EventArgs e)
        {
            FactoryShape FactoryShape = new FactoryShape();
            CShape Shape = FactoryShape.FactoryMethod("Круг");
            shapes[IteratorShape] = Shape;  
            SKC.InvalidateSurface();
            IteratorShape++;
        }
        private void TriangleClick(object sender, EventArgs e)
        {
            FactoryShape FactoryShape = new FactoryShape();
            CShape Shape = FactoryShape.FactoryMethod("Треугольник");
            shapes[IteratorShape] = Shape;
            SKC.InvalidateSurface();
            IteratorShape++;

        }
        private void SquareClick(object sender, EventArgs e)
        {
            FactoryShape FactoryShape = new FactoryShape();
            CShape Shape = FactoryShape.FactoryMethod("Квадрат");
            shapes[IteratorShape] = Shape;
            SKC.InvalidateSurface();
            IteratorShape++;                          
        }
        private void ClearClick(object sender, EventArgs e)
        {
            for (int j = 0; j < IteratorShape; j++)
            {
                shapes[j] = null;
            }           
            IteratorShape = 0;
            SKC.InvalidateSurface();
        }
    }
}
