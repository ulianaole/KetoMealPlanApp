using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    class Planner
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
    }
}
