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
            var person = new Person()
            {
                Age = 37,
                Height = 170,
                Weight = 63,
                Gender = GenderType.Male,
                BodyFat = 20.5,
                ActivityLevel = ActivityLevelType.LightlyActive

            };

            Console.WriteLine($"wlc: {person.CalculateWLC()}, FatKcalDaily: {person.FatKcalDaily()}, ProteinKcalDaily: {person.ProteinKcalDaily()}, NetCarbsKcalDaily: {person.NetCarbsKcalDaily()},\n" +
                $"FatGramsDaily: {person.FatGramsDaily()}, ProteinGramsDaily: {person.ProteinGramsDaily()}, NetCarbsGramsDaily: {person.NetCarbsGramsDaily()} \n" +
                $"FatPercentageDaily: {person.FatPercentageDaily()}, ProteinPercentageDaily: {person.ProteinPercentageDaily()}, NetCarbsPercentageDaily: {person.NetCarbsPercentageDaily()}");


        }
    }
}
