using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    class Person
    {
        private int age;

        public int Age
        {
            get { return age; }
            set {
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
        public double Height { get; set; }
        /// <summary>
        /// Weight in kg
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GenderType Gender { get; set; }
        /// <summary>
        /// Body Fat % expressed as 0.00
        /// </summary>
        public double BodyFat { get; set; }
        /// <summary>
        /// Activity level as index
        /// </summary>
        public double ActivityLevel { get; set; }




        
        /// <summary>
        /// calories in kcal
        /// </summary>
        //public int Calories { get; set; }
        /// <summary>
        /// Fats in g
        /// </summary>
        //public int Fats { get; set; }
        /// <summary>
        /// Proteins in g
        /// </summary>
        //public int Proteins { get; set; }
        /// <summary>
        /// NetCarbs in g
        /// </summary>
        //public int NetCarbs { get; set; }
        /// <summary>
        /// FatsPercentage in 0.00
        /// </summary>
        //public double FatsPercentage { get; set; }
        /// <summary>
        /// FProteinPercentage in 0.00
        /// </summary>
        //public double ProteinsPercentage { get; set; }
        /// <summary>
        /// NetCarbsPercentage in 0.00
        /// </summary>
        //public double NetCarbsPercentage { get; set; }


        /// <summary>
        /// Calculates Basic Metabolic rate
        /// </summary>
        /// <returns> BMR in kcal </returns>
        public int CalculateBasicMetabolicRate()
        {
            if (Gender == GenderType.Male)
            {
                return (int) (10 * Weight + 6.25 * Height - 5 * Age + 5);
            }
            else
            {
                return (int) (10 * Weight + 6.25 * Height - 5 * Age - 161);
            }

        }

        /// <summary>
        /// calculates Total Energy Expenditure
        /// </summary>
        /// <returns> TEE in kcal</returns>
        public int CalculateTotalEnergyExpenditure()
        {
            return (int) (ActivityLevel * CalculateBasicMetabolicRate());
        }

        /// <summary>
        /// Calculates total calories for weight loss
        /// </summary>
        /// <returns>WLC in kcal</returns>
        public int CalculateWeightLossCalories()
        {
            return CalculateTotalEnergyExpenditure() - 500;
        }

        /// <summary>
        /// Calculate Lean Body Mass
        /// </summary>
        /// <returns> LBM in kg</returns>
        public double CalculateLeanBodyMass()
        {
           return Weight - Weight * BodyFat/100;
        }

        /// <summary>
        /// Calculates Daily Protein Intake DPI
        /// </summary>
        /// <returns> DPI in g</returns>        
        public int CalculateDailyProteinIntake()
        {
            return (int) (CalculateLeanBodyMass() * 2);
        }

        public int FatKcalDaily()
        {
            return (int) (CalculateWeightLossCalories() - ProteinKcalDaily() - NetCarbsKcalDaily());
        }

        public int ProteinKcalDaily()
        {
            return (int) (CalculateDailyProteinIntake() * 4);
        }

        public int NetCarbsKcalDaily()
        { 
            return 100;
        }

        public double FatPercentageDaily()
        {
            return (FatKcalDaily() * 100) / (float)CalculateWeightLossCalories();
        }

        public double ProteinPercentageDaily()
        {
            return (ProteinKcalDaily() * 100) / (float)CalculateWeightLossCalories();
        }

        public double NetCarbsPercentageDaily()
        {
            return (NetCarbsKcalDaily() * 100) / (float)CalculateWeightLossCalories();
        }

        public int FatGramsDaily()
        {
            return (int) (FatKcalDaily()/9);
        }

        public int ProteinGramsDaily()
        {
            return CalculateDailyProteinIntake();
        }

        public int NetCarbsGramsDaily()
        {
            return 25;
        }
    }
}
