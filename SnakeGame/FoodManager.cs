using System.Collections.Generic;

namespace SnakeGame
{
    public class FoodManager : IFoodManager
    {
        private List<Food> food;

        public FoodManager()
        {
            food = new List<Food>();
        }

        public List<Food> GetAllFood()
        {
            return food;
        }
    }
}