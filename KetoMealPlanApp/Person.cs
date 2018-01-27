using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    public class Person
    {
        [Key]
        public int UserId { get; private set; }
        
        private int age;

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Age cannot be less than zero");
                }
                else
                {
                    age = value;
                }
            }
        }

        /// <summary>
        /// Height in cm
        /// </summary>
        public double Height { get; private set; }
        /// <summary>
        /// Weight in kg
        /// </summary>
        public double Weight { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public GenderType Gender { get; private set; }
        /// <summary>
        /// Body Fat % expressed as 0.00
        /// </summary>
        public double BodyFat { get; private set; }
        /// <summary>
        /// Activity level as index
        /// </summary>
        public ActivityLevelType ActivityLevel { get; private set; }

        /// <summary>
        /// weight loss calories in kcal
        /// </summary>
        public int WeightLossCalories { get; private set; }
        /// <summary>
        /// Daily intake of Fats, Proteins and NetCarbs in kcal
        /// </summary>
        public int FatKcalDaily { get; private set; }
        public int ProteinKcalDaily { get; private set; }
        public int NetCarbsKcalDaily { get; private set; }
        /// <summary>
        /// Daily intake of Fats, Proteins and NetCarbs in g
        /// </summary>
        public int FatGramsDaily { get; private set; }
        public int ProteinGramsDaily { get; private set; }
        public int NetCarbsGramsDaily { get; private set; }

        /// <summary>
        /// Daily intake of Fats, Proteins and NetCarbs in %
        /// </summary>
        public double FatPercentageDaily { get; private set; }
        public double ProteinPercentageDaily { get; private set; }
        public double NetCarbsPercentageDaily { get; private set; }

        public Person()
        {
        }

        public Person(int age, double height, double weight, GenderType gender,
            double bodyFat, ActivityLevelType activityLevel)
        {
            Age = age;
            Height = height;
            Weight = weight;
            Gender = gender;
            BodyFat = bodyFat;
            ActivityLevel = activityLevel;

            WeightLossCalories = CalculateWeightLossCalories();
            FatKcalDaily = CalculateFatKcalDaily();
            ProteinKcalDaily = CalculateProteinKcalDaily();
            NetCarbsKcalDaily = CalculateNetCarbsKcalDaily();

            FatPercentageDaily = CalculateFatPercentageDaily();
            ProteinPercentageDaily = CalculateProteinPercentageDaily();
            NetCarbsPercentageDaily = CalculateNetCarbsPercentageDaily();

            FatGramsDaily = CalculateFatGramsDaily();
            ProteinGramsDaily = CalculateProteinGramsDaily();
            NetCarbsGramsDaily = CalculateNetCarbsGramsDaily();


        }

        /// <summary>
        /// Calculates total calories for weight loss
        /// </summary>
        /// <returns>WLC in kcal</returns>
        private int CalculateWeightLossCalories()
        {
            
            // Calculate Basic Metabolic Rate in kcal
            int bmr;
            if (Gender == GenderType.Male)
            {
                bmr = (int)(10 * Weight + 6.25 * Height - 5 * Age + 5);
            }
            else
            {
                bmr = (int)(10 * Weight + 6.25 * Height - 5 * Age - 161);
            }
            //Calculate Total energy Expenditure in kcal
            //var level = (int)ActivityLevel;
            double level;
            switch (ActivityLevel)
            {
                case ActivityLevelType.Sedentary:
                    level = 1.0;
                    break;
                case ActivityLevelType.LightlyActive:
                    level = 1.375;
                    break;
                case ActivityLevelType.ModeratelyActive:
                    level = 1.55;
                    break;
                case ActivityLevelType.VeryActive:
                    level = 1.725;
                    break;
                case ActivityLevelType.ExtraActive:
                    level = 1.9;
                    break;
                default:
                    // Set default to lightly active
                    level = 1.55;
                    break;
            }

            var tee = level * bmr;
            return (int) tee - 500;
        }

        private int CalculateFatKcalDaily()
        {
            return (int) (CalculateWeightLossCalories() - CalculateProteinKcalDaily() - CalculateNetCarbsKcalDaily());
        }

        private int CalculateProteinKcalDaily()
        {
            return (int) (CalculateProteinGramsDaily() * 4);
        }

        private int CalculateNetCarbsKcalDaily()
        { 
            return 100;
        }

        private double CalculateFatPercentageDaily()
        {
            return (CalculateFatKcalDaily() * 100) / (float)CalculateWeightLossCalories();
        }

        private double CalculateProteinPercentageDaily()
        {
            return (CalculateProteinKcalDaily() * 100) / (float)CalculateWeightLossCalories();
        }

        private double CalculateNetCarbsPercentageDaily()
        {
            return (CalculateNetCarbsKcalDaily() * 100) / (float)CalculateWeightLossCalories();
        }

        private int CalculateFatGramsDaily()
        {
            return (int) (CalculateFatKcalDaily()/9);
        }

        private int CalculateProteinGramsDaily()
        {
            var leanBodyMass = Weight - Weight * BodyFat / 100;
            return (int)(leanBodyMass * 2);
        }

        private int CalculateNetCarbsGramsDaily()
        {
            return 25;
        }
    }
}
