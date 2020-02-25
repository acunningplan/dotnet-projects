using System;
using Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bob = new Person();
            //bob.Name = "Bob Smith";
            //bob.DateOfBirth = new DateTime(1965, 12, 22);
            //WriteLine(
            //     $"{bob.Name} was born on {bob.DateOfBirth: dddd, d MMMM yyyy}");

            //var alice = new Person
            //{
            //    Name = "Alice Jones",
            //    DateOfBirth = new DateTime(1998, 3, 7)
            //};
            //WriteLine(
            //    $"{alice.Name} was born on {alice.DateOfBirth:dd MMM yy}");

            //bob.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            //WriteLine($"{bob.Name}'s favourite wonder is {bob.FavouriteAncientWonder}. It's integer is {(int)bob.FavouriteAncientWonder}");

            //bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            ////bob.BucketList = (WondersOfTheAncientWorld)18;
            //WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            //bob.Children.Add(new Person { Name = "Alfred" });
            //bob.Children.Add(new Person { Name = "Zoe" });

            //WriteLine(
            //    $"{bob.Name} has {bob.Children.Count} children:");

            //foreach (Person child in bob.Children)
            //{
            //    WriteLine($"{child.Name}");
            //}

            //WriteLine($"{bob.Name} is a {Person.Species}");
            //WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            //var gunny = new Person("Gunny", "Mars");
            //WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
            //  arg0: gunny.Name, arg1: gunny.HomePlanet, arg2: gunny.Instantiated);


            //// Optional parameters
            //WriteLine(bob.OptionalParameters(number: 98.5, command: "Hide!"));

            //// Controlling how parameters are passed
            //int a = 10; int b = 20; int c = 30;
            //WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            //bob.PassingParameters(a, ref b, out c);
            //WriteLine($"After: a = {a}, b = {b}, c = {c}");

            //var sam = new Person
            //{
            //    Name = "Sam",
            //    DateOfBirth = new DateTime(1972, 1, 27)
            //};
            //WriteLine(sam.Origin);
            //WriteLine(sam.Greeting);
            //WriteLine(sam.Age);


            //sam.FavouriteIceCream = "Chocolate Fudge";
            //WriteLine($"Sam's favorite ice-cream flavor is {sam.FavouriteIceCream}."); sam.FavouritePrimaryColour = "Red";
            //WriteLine($"Sam's favorite primary color is {sam.FavouritePrimaryColour}.");

            //            var harry = new Person { Name = "Harry" };
            //            var mary = new Person { Name = "Mary" };
            //            var jill = new Person { Name = "Jill" };

            //            var baby1 = mary.ProcreateWith(harry);
            //            var baby2 = Person.Procreate(harry, jill);
            //            var baby3 = harry * mary;

            //            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            //            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            //            WriteLine($"{jill.Name} has {jill.Children.Count} children.");

            //            WriteLine($"{harry.Name}'s first child is named \"{harry.Children[0].Name}\"");

            //            harry.Shout += Harry_Shout;
            //            harry.Poke();
            //            harry.Poke();
            //            harry.Poke();
            //            harry.Poke();

            //            Person[] people =
            //{
            //            new Person {Name = "Simon" },
            //            new Person { Name = "Jenny" },
            //            new Person { Name = "Adam" },
            //            new Person { Name = "Richard" }
            //        };

            //            WriteLine("Initial list of people");
            //            foreach (var person in people)
            //            {
            //                WriteLine($"{person.Name}");
            //            }

            //            WriteLine("Use person's IComparable implementation to sort:");
            //            Array.Sort(people);
            //            foreach (var person in people)
            //            {
            //                WriteLine($"{person.Name}");
            //            }

            //            WriteLine("Use PersonComparer's IComparer implementation to sort:");
            //            Array.Sort(people, new PersonComparer());
            //            foreach (var person in people)
            //            {
            //                WriteLine($"{person.Name}");
            //            }

            //            var t1 = new Thing();
            //            t1.Data = 42;
            //            WriteLine($"Thing with an integer: {t1.Process(42)}");

            //            var t2 = new Thing();
            //            t2.Data = "apple";
            //            WriteLine($"Thing with a string: {t2.Process("apple")}");

            //            var gt1 = new GenericThing<int>();
            //            gt1.Data = 42;
            //            WriteLine($"Thing with an integer: {gt1.Process(42)}");

            //            var gt2 = new GenericThing<string>();
            //            gt2.Data = "apple";
            //            WriteLine($"Thing with an integer: {gt2.Process("apple")}");

            //            string number1 = "4";
            //            WriteLine($"{number1} squared is {Squarer.Square(number1)}");
            //            byte number2 = 3;
            //            WriteLine($"{number2} squared is {Squarer.Square(number2)}");

            //            Employee john = new Employee
            //            {
            //                Name = "John Jones",
            //                DateOfBirth = new DateTime(1990, 7, 28)
            //            };
            //            john.WriteToConsole();

            //            john.EmployeeCode = "JJ001";
            //            john.HireDate = new DateTime(2014, 11, 23);
            //            WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

            //            WriteLine(john.ToString());

            Employee aliceInEmployee = new Employee
            {
                Name = "Alice",
                EmployeeCode = "AA123",
                DateOfBirth = new DateTime(1995, 6, 18)
            };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            //Employee explicitAlice = (Employee)aliceInPerson;

            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee explicitAlice = (Employee)aliceInPerson;
            }

            Employee aliceAsEmployee = aliceInPerson as Employee;
            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Employee");
            }

            try
            {
                aliceInPerson.TimeTravel(new DateTime(1992, 12, 3));
            }
            catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            WriteLine("{0} is a valid e-mail address: {1}", arg0: email1, arg1: StringExtensions.IsValidEmail(email1));
            WriteLine("{0} is a valid e-mail address: {1}", arg0: email2, arg1: StringExtensions.IsValidEmail(email2));

            WriteLine("{0} is a valid e-mail address: {1}", arg0: email1, arg1: email1.IsValidEmail());
            WriteLine("{0} is a valid e-mail address: {1}", arg0: email2, arg1: email2.IsValidEmail());
        }
        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }
    }
}

