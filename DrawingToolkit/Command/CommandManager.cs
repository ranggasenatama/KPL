using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public class CommandManager
    {
        Stack<ICommand> commandStacks = new Stack<ICommand>();
        Stack<ICommand> historyStacks = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.execute();
            if (command is UndoableCommand)
            {
                commandStacks.Push(command);
            }
        }

        public void Undo()
        {
            if (commandStacks.Count > 0)
            {
                UndoableCommand command = commandStacks.Pop() as UndoableCommand;
                historyStacks.Push(command);
                command.Undo();
            }
        }

        public void Redo()
        {
            if (commandStacks.Count > 0)
            {
                UndoableCommand command = historyStacks.Pop() as UndoableCommand;
                commandStacks.Push(command);
                command.execute();
            }
        }
    }
}
