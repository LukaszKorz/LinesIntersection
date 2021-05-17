using System.Collections.Generic;
using System.Windows;

namespace LinesIntersections.DrawTool
{
    public class DrawToolBase
    {
        protected UIElement ActiveShape;
        protected List<UIElement> CreatedShapes;
        protected bool CanPersistShape;

        protected void PersistShape()
        {
            if (CanPersistShape)
            {
                CreatedShapes.Add(ActiveShape);
                ActiveShape = null;
            }
        }
    }
}
