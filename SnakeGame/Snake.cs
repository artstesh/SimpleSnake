using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame
{
    class Snake
    {
        public double CoordinateX, CoordinateY;
        public readonly Rectangle Rectangle = new Rectangle();
        public Snake(double coordinateX,double coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
        public void SetSnakePosition()
        {
            Rectangle.Width = Rectangle.Height = 10;
            Rectangle.Fill = Brushes.Red;
            Canvas.SetLeft(Rectangle, CoordinateX);
            Canvas.SetTop(Rectangle, CoordinateY);
        }
    }
}
