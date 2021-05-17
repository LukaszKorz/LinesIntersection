

using System.Windows;
using System.Windows.Controls;

namespace LinesIntersections.DrawTool
{
    public interface IDrawTool
    {
        void MouseDownEventHandler(Point mousePosition, Canvas context);
        void MouseMoveEventHandler(Point mousePosition);
    }
}
