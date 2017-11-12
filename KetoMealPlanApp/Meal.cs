using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    class Meal
    {
        public int Calories { get; set; }
        public int Fats { get; set; }
        public int Proteins { get; set; }
        public int NetCarbs { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
    