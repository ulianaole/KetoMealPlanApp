using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoMealPlanApp
{
    class Planner
    {
        private static List<Person> persons = new List<Person>();

        public static Person CreatePerson(int age, double height, double weight, GenderType gender, 
            double bodyFat, ActivityLevelType activityLevel)
        {
            var person = new Person(age, height, weight, gender, bodyFat, activityLevel);
            persons.Add(person);
            return person;
        }
    }
}
