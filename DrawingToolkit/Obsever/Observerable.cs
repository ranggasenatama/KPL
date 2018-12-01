using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Obsever
{
    public class Observerable
    {
        private List<IObserver> listObservers = new List<IObserver>();

        public void attach(IObserver observer)
        {
            listObservers.Add(observer);
        }
        public void detach(IObserver observer)
        {
            listObservers.Remove(observer);
        }
        public void notify()
        {
            foreach (IObserver observer in this.listObservers)
            {
                observer.update(this);
            }
        }
    }
}
