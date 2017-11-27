using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    class Person
    {
        public int Age { get; set; }
        /// <summary>
        /// Height in cm
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Weight in kg
        /// </summary>
        public double Weight { get; set; }
        public GenderType Gender { get; set; }
        /// <summary>
        /// Body Fat % expressed as 0.00
        /// </summary>
        public double BodyFat { get; set; }
        /// <summary>
        /// calories in kcal
        /// </summary>
        public int Calories { get; set; }
        /// <summary>
        /// Fats in g
        /// </summary>
        public int Fats { get; set; }
        /// <summary>
        /// Proteins in g
        /// </summary>
        public int Proteins { get; set; }
        /// <summary>
        /// NetCarbs in g
        /// </summary>
        public int NetCarbs { get; set; }
        /// <summary>
        /// FatsPercentage in 0.00
        /// </summary>
        public double FatsPercentage { get; set; }
        /// <summary>
        /// FProteinPercentage in 0.00
        /// </summary>
        public double ProteinsPercentage { get; set; }
        /// <summary>
        /// NetCarbsPercentage in 0.00
        /// </summary>
        public double NetCarbsPercentage { get; set; }
        /// <summary>
        /// Activity level as index
        /// </summary>
        public double ActivityLevel { get; set; }

        /// <summary>
        /// Calculates Basic Metabolic rate
        /// </summary>
        /// <returns> BMR in kcal </returns>
        public int CalculateBMR()
        {
            if (Gender == GenderType.Male)
            {
                var bmr = 10 * Weight + 6.25 * Height - 5 * Age + 5;
                return (int)bmr;
            }
            else
            {
                var bmr = 10 * Weight + 6.25 * Height - 5 * Age - 161;
                return (int)bmr;
            }

        }

        /// <summary>
        /// calculates Total Energy Expenditure
        /// </summary>
        /// <returns> TEE in kcal</returns>
        public int CalculateTEE()
        {
            var tee = ActivityLevel * CalculateBMR();
            return (int)tee;
        }

        /// <summary>
        /// Calculates total calories for weight loss
        /// </summary>
        /// <returns>WLC in kcal</returns>
        public int CalculateWLC()
        {
            var wlc = CalculateTEE() - 500;
            return wlc;

        }

        /// <summary>
        /// Calculate Lean Body Mass
        /// </summary>
        /// <returns> LBM in kg</returns>
        public double CalculateLBM()
        {
            var lbm = Weight - Weight * BodyFat/100;
            return lbm;

        }

        /// <summary>
        /// Calculates Daily Protein Intake DPI
        /// </summary>
        /// <returns> DPI in g</returns>        
        public int CalculateDPI()
        {
            var dpi = CalculateLBM() * 2;
            return (int)dpi;

        }

        public int FatKcalDaily()
        {
            var k1 = CalculateWLC() - ProteinKcalDaily() - NetCarbsKcalDaily();
            return (int)k1;
        }

        public int ProteinKcalDaily()
        {
            var k2 = CalculateDPI() * 4;
            return (int)k2;
        }

        public int NetCarbsKcalDaily()
        { 
            return 100;
        }

        public double FatPercentageDaily()
        {
            var p1 = (FatKcalDaily() * 100) / (float)CalculateWLC();
            return p1;
        }

        public double ProteinPercentageDaily()
        {
            var p2 = (ProteinKcalDaily() * 100) / (float)CalculateWLC();
            return p2;
        }

        public double NetCarbsPercentageDaily()
        {
            var p3 = (NetCarbsKcalDaily() * 100) / (float)CalculateWLC();
            return p3;
        }

        public int FatGramsDaily()
        {
            var g1 = FatKcalDaily()/9;
            return (int)g1;
        }

        public int ProteinGramsDaily()
        {
            return CalculateDPI();
        }

        public int NetCarbsGramsDaily()
        {
            return 25;
        }
    }
}
