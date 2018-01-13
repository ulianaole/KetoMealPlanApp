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
        
    }
}
