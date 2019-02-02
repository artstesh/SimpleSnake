using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame
{
    public class Food
    {
        public double CoordinateX,CoordinateY;
        public readonly Ellipse Ellipse = new Ellipse();
        public Food(double coordinateX,double coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }
        public void SetPosition()
        {
            Ellipse.Width = Ellipse.Height = 10;
            Ellipse.Fill = Brushes.Blue;
            Canvas.SetLeft(Ellipse, CoordinateX);
            Canvas.SetTop(Ellipse,CoordinateY);
        }
    }
}
