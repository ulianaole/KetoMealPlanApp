using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("Welcome to KetoMealPlanApp");
            Console.WriteLine("*******************************************");
            Console.Write("Please enter your email address: ");
            var email = Console.ReadLine();

            Console.Write("Please enter your age: ");
            var age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter your height in cm: ");
            var height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter your weight in kg: ");
            var weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please select the number corresponding to your gender");
            var genderType = Enum.GetNames(typeof(GenderType));
            for (var i = 0; i < genderType.Length; i++)
            {
                Console.WriteLine($"{i}.{genderType[i]}");
            }
            Console.Write("my gender: ");
            var gender = Convert.ToInt32(Console.ReadLine());


            Console.Write("Please enter your body fat %: ");
            var bodyFat = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please select the number corresponding to your activity level");
            var activityLevelType = Enum.GetNames(typeof(ActivityLevelType));
            for (var i = 0; i < activityLevelType.Length; i++)
            {
                Console.WriteLine($"{i}.{activityLevelType[i]}");
            }
            Console.Write("my activity level: ");
            var activityLevel = Convert.ToInt32(Console.ReadLine());

            var person = Planner.CreatePerson(email, age, height, weight, (GenderType)gender,
                bodyFat, (ActivityLevelType)activityLevel);

            //var person = Planner.CreatePerson(37, 170, 70.5, GenderType.Female,
            //    30, ActivityLevelType.LightlyActive);

            Console.WriteLine($"WeightLossCalories: {person.WeightLossCalories}, " +
                $"FatKcalDaily: {person.FatKcalDaily}, " +
                $"ProteinKcalDaily: {person.ProteinKcalDaily}, " +
                $"NetCarbsKcalDaily: {person.NetCarbsKcalDaily},\n" +
                $"FatGramsDaily: {person.FatGramsDaily}, " +
                $"ProteinGramsDaily: {person.ProteinGramsDaily}, " +
                $"NetCarbsGramsDaily: {person.NetCarbsGramsDaily} \n" +
                $"FatPercentageDaily: {person.FatPercentageDaily}, " +
                $"ProteinPercentageDaily: {person.ProteinPercentageDaily}, " +
                $"NetCarbsPercentageDaily: {person.NetCarbsPercentageDaily}\n");

            Console.WriteLine("Here is a list of available meals");
            Console.WriteLine("Breakfast options: ");
            var breakfastList = Planner.ListMeals(MealType.Breakfast);
            for (var i = 0; i < breakfastList.Count ; i++)
            {
                Console.WriteLine($"{i}.{breakfastList[i].Name}");
            }

            Console.WriteLine("Lunch options: ");
            var lunchList = Planner.ListMeals(MealType.Lunch);
            for (var i = 0; i < lunchList.Count; i++)
            {
                Console.WriteLine($"{i}.{lunchList[i].Name}");
            }

            Console.WriteLine("Dinner options: ");
            var dinnerList = Planner.ListMeals(MealType.Dinner);
            for (var i = 0; i < dinnerList.Count; i++)
            {
                Console.WriteLine($"{i}.{dinnerList[i].Name}");
            }

            Console.Write("Please choose your breakfast option, use the corresponding number ");
            var breakfastChoice = breakfastList[Convert.ToInt32(Console.ReadLine())];

            Console.Write("Please choose your lunch option, use the corresponding number ");
            var lunchChoice = lunchList[Convert.ToInt32(Console.ReadLine())];

            Console.Write("Please choose your dinner option, use the corresponding number ");
            var dinnerChoice = dinnerList[Convert.ToInt32(Console.ReadLine())];

            var breakfastExtraIngredients = Planner.CreateDailyMealPlan(person, breakfastChoice);
            var lunchExtraIngredients = Planner.CreateDailyMealPlan(person, lunchChoice);
            var dinnerExtraIngredients = Planner.CreateDailyMealPlan(person, dinnerChoice);

            Console.WriteLine("Here is your daily meal plan ");

            Console.WriteLine("=========================");
            Console.WriteLine("* Breakfast *");
            Console.WriteLine($"Name: {breakfastChoice.Name}");
            Console.WriteLine($"Kcal: {breakfastChoice.Calories}");
            Console.WriteLine($"NetCarbs in g: {breakfastChoice.NetCarbGrams}");
            Console.WriteLine($"Proteins in g: {breakfastChoice.ProteinGrams}");
            Console.WriteLine($"Fat s in g: {breakfastChoice.FatGrams}");
            Console.WriteLine($"Additional NetCarbs: {breakfastExtraIngredients.NetCarbsIngredientCount}x {breakfastExtraIngredients.NetCarbsIngredient.Name}");
            Console.WriteLine($"Additional Proteins: {breakfastExtraIngredients.ProteinsIngredientCount}x {breakfastExtraIngredients.ProteinsIngredient.Name}");
            Console.WriteLine($"Additional Fats: {breakfastExtraIngredients.FatsIngredientCount}x {breakfastExtraIngredients.FatssIngredient.Name}");

            Console.WriteLine("=========================");
            Console.WriteLine("* Lunch *");
            Console.WriteLine($"Name: {lunchChoice.Name}");
            Console.WriteLine($"Kcal: {lunchChoice.Calories}");
            Console.WriteLine($"NetCarbs in g: {lunchChoice.NetCarbGrams}");
            Console.WriteLine($"Proteins in g: {lunchChoice.ProteinGrams}");
            Console.WriteLine($"Fat s in g: {lunchChoice.FatGrams}");
            Console.WriteLine($"Additional NetCarbs: {lunchExtraIngredients.NetCarbsIngredientCount}x {lunchExtraIngredients.NetCarbsIngredient.Name}");
            Console.WriteLine($"Additional Proteins: {lunchExtraIngredients.ProteinsIngredientCount}x {lunchExtraIngredients.ProteinsIngredient.Name}");
            Console.WriteLine($"Additional Fats: {lunchExtraIngredients.FatsIngredientCount}x {lunchExtraIngredients.FatssIngredient.Name}");

            Console.WriteLine("=========================");
            Console.WriteLine("* Dinner *");
            Console.WriteLine($"Name: {dinnerChoice.Name}");
            Console.WriteLine($"Kcal: {dinnerChoice.Calories}");
            Console.WriteLine($"NetCarbs in g: {dinnerChoice.NetCarbGrams}");
            Console.WriteLine($"Proteins in g: {dinnerChoice.ProteinGrams}");
            Console.WriteLine($"Fat s in g: {dinnerChoice.FatGrams}");
            Console.WriteLine($"Additional NetCarbs: {dinnerExtraIngredients.NetCarbsIngredientCount}x {dinnerExtraIngredients.NetCarbsIngredient.Name}");
            Console.WriteLine($"Additional Proteins: {dinnerExtraIngredients.ProteinsIngredientCount}x {dinnerExtraIngredients.ProteinsIngredient.Name}");
            Console.WriteLine($"Additional Fats: {dinnerExtraIngredients.FatsIngredientCount}x {dinnerExtraIngredients.FatssIngredient.Name}");

        }

        static void CreateMeals()
        {
            Planner.CreateMeal(414, 30, 32, 4, "Burger Skillet", MealType.Breakfast);
            Planner.CreateMeal(159, 14, 3, 5, "Turnip Hash Browns", MealType.Breakfast);
            Planner.CreateMeal(213, 18, 10, 2, "Turmeric Scrambled Eggs", MealType.Breakfast);
            Planner.CreateMeal(233, 14, 21, 7, "Cabbage Rolls", MealType.Lunch);
            Planner.CreateMeal(267, 17, 28, 2, "One-pan Shrimp and Asparagus", MealType.Lunch);
            Planner.CreateMeal(276, 21, 21, 5, "Sausage and Kale", MealType.Lunch);
            Planner.CreateMeal(453, 33, 31, 9, "Chicken (or Turkey) and Broccoli Cassarole", MealType.Dinner);
            Planner.CreateMeal(336, 24, 19, 10, "Pan-fried Cod with Dill Caper Sauce", MealType.Dinner);
            Planner.CreateMeal(257, 17, 5, 21, "Lemony Pressure Cooker Artichokes with Aioli", MealType.Dinner);
        }

        static void CreateExtraIngredients()
        {
            Planner.CreateExtraIngredient(50, ExtraIngredientType.NetCarbsExtra, "1 apple or 1 orange or half banana", 14);
            Planner.CreateExtraIngredient(100, ExtraIngredientType.FatExtra, "1 tbsp of Pure Irish Butter or 2 tsp of Omega-3 Purified Fish Oil", 11);
            Planner.CreateExtraIngredient(100, ExtraIngredientType.ProteinExtra, "1 scoop of Pure Protein Powder", 22);
        }
    }
}
