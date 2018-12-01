using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    class MoveCommand : UndoableCommand
    {
        DrawingObject obj;
        int x;
        int y;

        public MoveCommand(DrawingObject obj, int x, int y)
        {
            this.obj = obj;
            this.x = x;
            this.y = y;
        }


        public override void execute()
        {
            obj.Translate(x, y);
        }

        public override void Undo()
        {
            obj.Translate(-x, -y);
        }
    }
}
