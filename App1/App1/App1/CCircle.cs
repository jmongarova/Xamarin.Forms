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
    class CCircle : CShape
    {
        public int Radius { get; set; }           // радиус круга
        public CCircle(int x, int y,  Color ColorShape, int OffsetX , int OffsetY, string Type, int rad) : base (x, y, ColorShape, OffsetX, OffsetY,  Type)// конструктор
        {
            Radius = rad;
        }
    };
}
