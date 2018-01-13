using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    class Ingredient
    {
        [Key]
        public int MealId { get; set; }
        public int Calories { get; set; }
        public int FatGrams { get; set; }
        public int ProteinGrams { get; set; }
        public int NetCarbGrams { get; set; }
        public string Name { get; set; }
    }
}
