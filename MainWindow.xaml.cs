using LinesIntersections.DrawTool;
using System.Windows;
using System.Windows.Input;

namespace LinesIntersections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDrawTool _drawTool;

        public MainWindow()
        {
            InitializeComponent();

            DrawCanvas.MouseDown += MouseDownEventHandler;
            DrawCanvas.MouseMove += MouseMoveEventHandler;

            // TODO Implement .NetCore3 IOC
            _drawTool = new LineDrawTool();
        }

        private void MouseDownEventHandler(object sender, MouseButtonEventArgs e) =>
            _drawTool.MouseDownEventHandler(e.GetPosition(DrawCanvas), DrawCanvas);

        private void MouseMoveEventHandler(object sender, MouseEventArgs e) =>
            _drawTool.MouseMoveEventHandler(e.GetPosition(DrawCanvas));
    }
}
