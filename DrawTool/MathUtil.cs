using System;
using System.Windows;
using System.Windows.Shapes;

namespace LinesIntersections.DrawTool
{
    public static class MathUtil
    {
        // General form equation reused from https://doubleroot.in/lessons/straight-line/general-form/
        // And intersection point formula reused from https://math.stackexchange.com/questions/1798037/find-intersection-point-of-two-straight-lines
        public static bool IsLineIntersecting(Line lineA, Line lineB)
        {
            // General form equation of LineA
            var A1 = lineA.Y2 - lineA.Y1;
            var B1 = lineA.X1 - lineA.X2;
            var C1 = A1 * lineA.X1 + B1 * lineA.Y1;

            // General form equation of LineB
            var A2 = lineB.Y2 - lineB.Y1;
            var B2 = lineB.X1 - lineB.X2;
            var C2 = A2 * lineB.X1 + B2 * lineB.Y1;

            var delta = A1 * B2 - A2 * B1;

            // If delta is equal to 0, it means lines are parallel
            if (delta == 0)
                return false;

            var x = (B2 * C1 - B1 * C2) / delta;
            var y = (A1 * C2 - A2 * C1) / delta;
            var pointOfIntersection = new Point(x, y);

            return IsIntersectionPointOnTheSegment(lineA, lineB, pointOfIntersection);
        }

        private static bool IsIntersectionPointOnTheSegment(Line lineA, Line lineB, Point intersectionPoint)
        {
            // Check if IntersectionPoint is on the lineA and LineB segments
            return Math.Min(lineA.X1, lineA.X2) <= intersectionPoint.X &&
                   intersectionPoint.X <= Math.Max(lineA.X1, lineA.X2) &&
                   Math.Min(lineA.Y1, lineA.Y2) <= intersectionPoint.Y &&
                   intersectionPoint.Y <= Math.Max(lineA.Y1, lineA.Y2) &&
                   Math.Min(lineB.X1, lineB.X2) <= intersectionPoint.X &&
                   intersectionPoint.X <= Math.Max(lineB.X1, lineB.X2) &&
                   Math.Min(lineB.Y1, lineB.Y2) <= intersectionPoint.Y &&
                   intersectionPoint.Y <= Math.Max(lineB.Y1, lineB.Y2);
        }
    }
}
