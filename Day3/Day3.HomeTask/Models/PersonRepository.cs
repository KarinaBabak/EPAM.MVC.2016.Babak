using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day3.HomeTask.Models
{
    public static class PersonRepository
    {
        public static List<Person> persons;

        static PersonRepository()
        {
            persons = new List<Person>();
            //persons.Add(new Person()
            //{
            //    Role = Faction.Light, Name = "Luck"
            //});

            //persons.Add(new Person()
            //{
            //    Role = Faction.Light,
            //    Name = "Lea"
            //});

            //persons.Add(new Person()
            //{
            //    Role = Faction.Dark,
            //    Name = "Dart"
            //});
        }

        public static void Add(Person person)
        {
            persons.Add(person);
        }

        public static List<Person> GetPersons()
        {
            return persons;
        }
                        
    }
}