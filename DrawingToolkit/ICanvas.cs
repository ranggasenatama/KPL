using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public interface ICanvas
    {
        void SetActiveTool(ITool tool);
        void Repaint();
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject);
        void CheckSelectedObject();
        List<DrawingObject> GetListObjects();
        DrawingObject GetObjectAt(int x, int y);
        DrawingObject SelectObjectAt(int x, int y);
        void DeselectAllObjects();
        void RemoveDrawingObject(DrawingObject drawingObject);
    }
}
