using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyFootballObjects
{
    public class ColorConverterPlus
    {
        public System.Drawing.Color BrushToDrawingColor(SolidColorBrush brush)
        {
            System.Drawing.Color c = System.Drawing.Color.FromArgb(brush.Color.A, brush.Color.R, brush.Color.G, brush.Color.B);
            return c;
        }

        public SolidColorBrush DrawingColorToBrush(System.Drawing.Color color)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            return brush;
        }

        public System.Drawing.Color MediaColorToDrawingColor(System.Windows.Media.Color color)
        {
            var drawingcolor = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
            return drawingcolor;
        }

        public System.Windows.Media.Color DrawingColorToColorMediaColor(System.Drawing.Color color)
        {
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            return newColor;
        }
    }
}
