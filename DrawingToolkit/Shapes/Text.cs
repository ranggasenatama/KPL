using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class Text : DrawingObject
    {
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;

        public Text(int initX, int initY, String value)
        {
            this.brush = new SolidBrush(Color.Black);

            this.X = initX;
            this.Y = initY;
            this.Value = value;

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
                fontFamily,
                16,
                FontStyle.Regular,
                GraphicsUnit.Pixel);
        }

        public override bool isSelected(Point mouse)
        {
            if ((mouse.X >= X && mouse.X <= X) && (mouse.Y >= Y && mouse.Y <= Y))
            {
                return true;
            }
            return false;
        }

        public override void isNotSelected()
        {
            
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X) && (yTest >= Y && yTest <= Y))
            {
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            Graphics.DrawString(Value, font, brush, new PointF(X, Y));
        }
        public override void RenderOnEditingView()
        {
            Graphics.DrawString(Value, font, brush, new PointF(X, Y));
        }
        public override void RenderOnPreview()
        {
            Graphics.DrawString(Value, font, brush, new PointF(X, Y));
        }

        public override void Translate(int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
            this.centerPoint = new Point(this.X, this.Y);
            notify();
        }
    }
}
