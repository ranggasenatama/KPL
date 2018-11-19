using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public abstract class UndoableCommand : ICommand
    {
        public abstract void execute();

        public abstract void Undo();
    }
}
