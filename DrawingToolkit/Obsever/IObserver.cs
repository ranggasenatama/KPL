using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Obsever
{
    public interface IObserver
    {
        void update(Observerable observerable);
    }
}
