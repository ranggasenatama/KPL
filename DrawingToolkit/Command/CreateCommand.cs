using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    class CreateCommand : UndoableCommand
    {
        DrawingObject obj;
        ICanvas canvas;
        
        public CreateCommand(DrawingObject obj, ICanvas canvas)
        {
            this.obj = obj;
            this.canvas = canvas;
        }

        public override void execute()
        {
            canvas.AddDrawingObject(obj);
        }

        public override void Undo()
        {
            canvas.RemoveDrawingObject(obj);
        }
    }
}
