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

            var person = Planner.CreatePerson(age, height, weight, (GenderType)gender,
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
                $"NetCarbsPercentageDaily: {person.NetCarbsPercentageDaily}");


        }
    }
}
