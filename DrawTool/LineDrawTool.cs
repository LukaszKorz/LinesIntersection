using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinesIntersections.DrawTool
{
    public class LineDrawTool : DrawToolBase, IDrawTool
    {
        public Line ActiveLine { get => ActiveShape as Line; set => ActiveShape = value; }

        public LineDrawTool()
        {
            ActiveShape = null;
            CreatedShapes = new List<UIElement>();
            CanPersistShape = true;
        }

        public void MouseDownEventHandler(Point mousePosition, Canvas context)
        {
            if (ActiveLine == null)
                DrawShape(mousePosition, context);
            else
                PersistShape();
        }

        public void MouseMoveEventHandler(Point mousePosition)
        {
            if (ActiveLine != null)
            {
                ActiveLine.Y2 = mousePosition.Y;
                ActiveLine.X2 = mousePosition.X;
                ValidateLinePlacement(ActiveLine);
            }
        }

        private void DrawShape(Point mousePosition, Canvas context)
        {
            ActiveLine = new Line
            {
                X1 = mousePosition.X,
                Y1 = mousePosition.Y,
                X2 = mousePosition.X,
                Y2 = mousePosition.Y,
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
            };

            context.Children.Add(ActiveLine);
        }

        private void ValidateLinePlacement(Line activeLine)
        {
            var interceptingLanes = GetInterceptingLines(activeLine);

            if (interceptingLanes.Any())
            {
                CanPersistShape = false;
                SetLineColor(activeLine, Colors.Red);
            }
            else
            {
                CanPersistShape = true;
                SetLineColor(activeLine, Colors.Black);
            }
        }

        private List<UIElement> GetInterceptingLines(Line activeLine) =>
            CreatedShapes.Where(l => MathUtil.IsLineIntersecting(activeLine, (Line)l)).ToList();

        private static void SetLineColor(Line line, Color lineColor)
        {
            line.Fill = new SolidColorBrush(lineColor);
            line.Stroke = new SolidColorBrush(lineColor);
        }
    }
}
