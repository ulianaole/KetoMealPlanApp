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
            var person = Planner.CreatePerson(37, 170, 70.5, GenderType.Female,
                30, ActivityLevelType.LightlyActive);

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
