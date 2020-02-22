using System;
using System.Collections.Generic;

namespace Shared
{
    public partial class Person
    {
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();
        public const string Species = "Homo Sapien";
        public readonly string HomePlanet = "Earth";

        public readonly DateTime Instantiated;
        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true)
        {
            return string.Format(format: $"command is {command}, number is {number}, active is {active}");
        }

        public void PassingParameters(int x, ref int y, out int z)
        { // out parameters cannot have a default 
            // AND must be initialized inside the method  
            z = 99;
            x++; y++; z++;
        }

        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }

        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        public static Person operator *(Person p1, Person p2)
        {
            return Procreate(p1, p2);
        }
    }
}
