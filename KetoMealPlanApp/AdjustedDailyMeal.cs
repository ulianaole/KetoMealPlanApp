using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    public class AdjustedMeal
    {
        public ExtraIngredient NetCarbsIngredient { get; set; }
        public int NetCarbsIngredientCount { get; set; }
        public ExtraIngredient ProteinsIngredient { get; set; }
        public int ProteinsIngredientCount { get; set; }
        public ExtraIngredient FatssIngredient { get; set; }
        public int FatsIngredientCount { get; set; }
    }
}
