using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    public class Planner
    {
        private static KetoAppModel db = new KetoAppModel();

        public static Person CreatePerson(int age, double height, double weight, GenderType gender, 
            double bodyFat, ActivityLevelType activityLevel)
        {
            var person = new Person(age, height, weight, gender, bodyFat, activityLevel);
            db.Persons.Add(person);
            db.SaveChanges();
            return person;
        }

        public static void CreateMeal(int calories, int fatGrams, int proteinGrams, int netCarbGrams,
            string name, MealType type)
        {
            var meal = new Meal
            {
                Calories = calories,
                FatGrams = fatGrams,
                ProteinGrams = proteinGrams,
                NetCarbGrams = netCarbGrams,
                Name = name,
                Type = type
            };
            db.Meals.Add(meal);
            db.SaveChanges();
            
        }

        public static void CreateExtraIngredient(int calories, ExtraIngredientType ingredientType, string name,
            int grams)
        {
            var extraIngredinet = new ExtraIngredient
            {
                Calories = calories,
                Type = ingredientType,
                Name = name,
                MacroGrams = grams

            };
            db.ExtraIngredients.Add(extraIngredinet);
            db.SaveChanges();
        }

        public static List<Meal> ListMeals(MealType mealType)
        {
            return db.Meals.Where(m => m.Type == mealType).ToList();
        }

        public void CreateDailyMealPlan(Person person)
        {
            var mealNetCarbsLimit = (int) person.NetCarbsGramsDaily / 3;
            var mealProteinsLimit = (int) person.ProteinGramsDaily / 3;
            var mealFatsLimit = (int) person.FatGramsDaily / 3;


        }
    }
}
