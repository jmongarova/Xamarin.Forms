using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace App1
{
    class CSquare : CShape
    {
        public int SquareSide { get; set; }       // сторона квадрата
        public CSquare(int x, int y, Color ColorShape,  int OffsetX, int OffsetY, string Type, int Side) : base(x, y, ColorShape, OffsetX, OffsetY, Type)
        {
            SquareSide = Side;
        }
    };
}
