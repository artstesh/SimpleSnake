using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using Unity;

namespace SnakeGame
{
    public partial class MainWindow : Window
    {
        DispatcherTimer time;
        List<Snake> snakebody;
        List<Food> food;
        Random rd = new Random();
        double x = 100;
        double y = 100;
        int direction;
        int left = 4;
        int right = 6;
        int up = 8;
        int down = 2;
        int score;
        int count;
        
        [Dependency]
        private IFoodManager _foodManager { get; set; }
        public MainWindow(IFoodManager foodManager)
        {
            _foodManager = foodManager;
            InitializeComponent();
            time = new DispatcherTimer();
            snakebody = new List<Snake>();
            food = new List<Food>();
            snakebody.Add(new Snake(x, y));
            food.Add(new Food(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10));
            time.Interval = new TimeSpan(0, 0, 0, 0, 100);   /*you can change speed of the snake here */
            time.Tick += time_Tick;
        }

        void addfoodincanvas()
        {
            food[0].SetPosition();
            mycanvas.Children.Insert(0,food[0].Ellipse);
        }


        void addsnakeincanvas()
        {
            foreach (Snake snake in snakebody)
            {
                snake.SetSnakePosition();
                mycanvas.Children.Add(snake.Rectangle);
            }
        }


        void time_Tick(object sender, EventArgs e)
        {
            if(direction!=0)
            {
                for(int i=snakebody.Count-1;i>0;i--)
                {
                    snakebody[i] = snakebody[i - 1];
                }
            }


            if (direction == up)
                y -= 10;
            if (direction == down)
                y += 10;
            if (direction == left)
                x -= 10;
            if (direction == right)
                x += 10;


            if(snakebody[0].CoordinateX== food[0].CoordinateX && snakebody[0].CoordinateY== food[0].CoordinateY)
            {
                snakebody.Add(new Snake(food[0].CoordinateX, food[0].CoordinateY));
                food[0] = new Food(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10);
                mycanvas.Children.RemoveAt(0);
                addfoodincanvas();
                score++;
                txtbScore.Text = score.ToString();
            }


            snakebody[0] = new Snake(x, y);

            if(snakebody[0].CoordinateX>370 || snakebody[0].CoordinateY>350 || snakebody[0].CoordinateX<0 || snakebody[0].CoordinateY<0)
            {
                Close();
            }


            for (int i = 1; i < snakebody.Count;i++ )
            {
                if (snakebody[0].CoordinateX == snakebody[i].CoordinateX && snakebody[0].CoordinateY == snakebody[i].CoordinateY)
                    Close();
            }


            for (int i = 0; i < mycanvas.Children.Count; i++)
            {
                if (mycanvas.Children[i] is Rectangle)
                    count++;
            }
            mycanvas.Children.RemoveRange(1, count);
            count = 0;
            addsnakeincanvas();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && direction != down)
                direction = up;
            if (e.Key == Key.Down && direction != up)
                direction = down;
            if (e.Key == Key.Left && direction != right)
                direction = left;
            if (e.Key == Key.Right && direction != left)
                direction = right;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addsnakeincanvas();
            addfoodincanvas();
            time.Start();
        }
    }
}
