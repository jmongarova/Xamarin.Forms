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
    abstract class CShape
    {
        public string Type { get; set; }                 // тип фигуры
        public int PosX { get; set; }                    // X - координата точки привязки
        public int PosY { get; set; }                    // Y - координата точки привязки
        public int OffsetX { get; set; }                // X - координата смещения точки 
        public int OffsetY { get; set; }                // Y - координата смещения точки 
        public Color ColorShape { get; set; }
        public CShape(int x, int y, Color ColorShape, int OffsetX, int OffsetY, string Type)
        {
            PosX = x;
            PosY = y;
            this.OffsetX = OffsetX;
            this.OffsetY = OffsetY;
            this.ColorShape = ColorShape;
            this.Type = Type;
        }
        //public string m_type { get; set; }  
        //public int m_xpos { get; set; }                  
        //public int m_ypos { get; set; }                  
        //public int offset_x { get; set;}
        //public int offset_y { get; set; }
        //public Color color_shape { get; set; }
    };
}
