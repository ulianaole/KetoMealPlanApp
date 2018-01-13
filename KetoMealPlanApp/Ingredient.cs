using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    public enum ExtraIngredientType
    {
        FatExtra,
        ProteinExtra,
        NetCarbsExtra
    }


    public class ExtraIngredient
    {
        [Key]
        public int IngredinetId { get; set; }
        public int Calories { get; set; }
        public ExtraIngredientType Type { get; set; }
        public string Name { get; set; }
        public int MacroGrams { get; set; }
    }
}
