using System;
using System.Drawing;

namespace optLab
{
    class PicPainter
    {
        private readonly double picOffset;
        private readonly int picWidth, picHeight;
        private readonly int origWidth, origHeight;
        private readonly float pointSize = 1.5f, minPointSize = 3f;
        Graphics picGraphics;

        public PicPainter(Graphics picGraphics, int width, int height, double picOffset)
        {
            this.picGraphics = picGraphics;
            this.picOffset = picOffset;
            this.origWidth = width;
            this.origHeight = height;
            this.picWidth = width - (int)(width * picOffset);
            this.picHeight = height - (int)(height * picOffset);
        }

        public void ClearGraphics()
        {
            picGraphics.FillRectangle(Brushes.White, 0, 0, origWidth, origHeight);
        }

        public void DrawLine(double firstX1, double firstX2, double secondX1, double secondX2, double botBorder, double upBorder, double offset, Pen pen)
        {
            var firstCoordinates = ToPic(picWidth, picHeight, offset, botBorder, upBorder, firstX2, firstX1);
            var secondCoordinates = ToPic(picWidth, picHeight, offset, botBorder, upBorder, secondX2, secondX1);
            picGraphics.DrawLine(pen, firstCoordinates.Item1, firstCoordinates.Item2, secondCoordinates.Item1, secondCoordinates.Item2);
        }

        public void DrawCoordinateLines(double botBorder, double upBorder, double offset,int size, double deltaX)
        {
            var font = new Font("Times New Roman", CalcFontSize(deltaX));
            var coordinates = ToPic(picWidth, picHeight, offset, botBorder, upBorder, 0d, 0d);
            picGraphics.DrawLine(Pens.Black, coordinates.Item1, 0, coordinates.Item1, origHeight);
            picGraphics.DrawLine(Pens.Black, 0, coordinates.Item2, origWidth, coordinates.Item2);
            picGraphics.DrawString("x1", font, Brushes.Black, coordinates.Item1, 0);
            picGraphics.DrawString("x2", font, Brushes.Black, origWidth - font.Size * 2, coordinates.Item2 - font.Size * 2);
            picGraphics.DrawString("0", font, Brushes.Black, coordinates.Item1 - font.Size * 2, coordinates.Item2);
            var deltaPlus = coordinates.Item2;
            var deltaCoordinates = ToPic(picWidth, picHeight, 0, botBorder, upBorder, deltaX, deltaX);
            for(var i = deltaX; i <= upBorder; i += deltaX)
            {
                var value = Math.Round(i, 2);
                deltaPlus -= deltaCoordinates.Item1;
                picGraphics.DrawString(value.ToString(), font, Brushes.Black, coordinates.Item1 - font.Size * 2, deltaPlus);             
            }
            deltaPlus = coordinates.Item2;
            for (var i = -deltaX; i >= botBorder; i -= deltaX)
            {
                var value = Math.Round(i, 2);
                deltaPlus += deltaCoordinates.Item1;
                picGraphics.DrawString(value.ToString(), font, Brushes.Black, coordinates.Item1 - font.Size * 2, deltaPlus);
            }
            deltaPlus = coordinates.Item1;
            for (var i = deltaX; i <= upBorder; i += deltaX)
            {
                var value = Math.Round(i, 2);
                deltaPlus += deltaCoordinates.Item1;
                picGraphics.DrawString(value.ToString(), font, Brushes.Black, deltaPlus - font.Size, coordinates.Item2);
            }
            deltaPlus = coordinates.Item1;
            for (var i = -deltaX; i >= botBorder; i -= deltaX)
            {
                var value = Math.Round(i, 2);
                deltaPlus -= deltaCoordinates.Item1;
                picGraphics.DrawString(value.ToString(), font, Brushes.Black, deltaPlus - font.Size, coordinates.Item2);
            }
        }

        public void DrawPoint(double x1, double x2, double botBorder, double upBorder, double offset, bool minPoint = false)
        {
            var brush = Brushes.Black;
            var size = pointSize;
            var coordinates = ToPic(picWidth, picHeight, offset, botBorder, upBorder, x2, x1);
            if (minPoint)
            {
                brush = Brushes.Green;
                size = minPointSize;
                picGraphics.DrawString("min", new Font("Times New Roman", 8f), Brushes.Green, coordinates.Item1, coordinates.Item2);
            }
            picGraphics.FillRectangle(brush, coordinates.Item1, coordinates.Item2, size, size);           
        }

        /// <summary>
        /// Convent function numbers (1.5, 1.5) to coordinates in pixels.
        /// </summary>
        /// <param name="width">Original pic width</param>
        /// <param name="height">Original pic height</param>
        /// <param name="offset">Offset added to pic</param>
        /// <param name="bot"></param>
        /// <param name="up"></param>
        /// <param name="x2"></param>
        /// <param name="x1"></param>
        /// <returns></returns>
        private Tuple<float, float> ToPic(double width, double height, double offset, double bot, double up, double x2, double x1)
        {
            var size = Math.Abs(bot) + Math.Abs(up);
            var x = width / size * x2 + width * offset; 
            var y = height - (height / size * x1 + height * offset) + 0.125d* height;
            return new Tuple<float, float>((float)x, (float)y);
        }

        private float CalcFontSize(double step) => (float)(10d * step / 0.5);
    }
}
