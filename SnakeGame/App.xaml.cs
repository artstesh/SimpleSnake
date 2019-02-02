using System.Windows;
using Unity;

namespace SnakeGame
{
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterSingleton<IFoodManager, FoodManager>();
            var mainWindow = container.Resolve<MainWindow>();            
            Current.MainWindow = mainWindow;
            Current.MainWindow.Show();
        }
    }
}
