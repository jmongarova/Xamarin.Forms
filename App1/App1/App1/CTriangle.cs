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
    class CTriangle : CShape
    {
        public int PosX2 { get; set; }            
        public int PosY2 { get; set; }
        public int PosX3 { get; set; }           
        public int PosY3 { get; set; }
        public CTriangle(int x, int y, Color ColorShape, int OffsetX, int OffsetY,  string Type, int x2, int y2, int x3, int y3) : base(x, y, ColorShape, OffsetX, OffsetY, Type)// конструктор
        {   
            PosX2 = x2;
            PosY2 = y2;
            PosX3 = x3;
            PosY3 = y3;
        }
    };
}
