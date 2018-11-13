using DrawingToolkit.States;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        public Graphics Graphics { get; set; }
        
        public abstract Boolean isSelected(Point mouse);
        public abstract void isNotSelected();

        public abstract bool Intersect(int xTest, int yTest);

        public abstract void Translate(int x, int y, int xAmount, int yAmount);


        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }
        private DrawingState state;

        public DrawingObject()
        {
            this.ChangeState(PreviewState.GetInstance());
        }

        public abstract void RenderOnPreview();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnStaticView();

        public void ChangeState(DrawingState drawingState)
        {
            this.state = drawingState;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }
        public void Select()
        {
            this.state.Select(this);
        }
        public void Deselect()
        {
            this.state.Deselect(this);
        }
    }
}
