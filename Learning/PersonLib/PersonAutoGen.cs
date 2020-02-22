using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public partial class Person
    {
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }
        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => DateTime.Today.Year - DateOfBirth.Year;
        public string FavouriteIceCream { get; set; }
        private string favouritePrimaryColour;
        public string FavouritePrimaryColour
        {
            get { return favouritePrimaryColour; }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favouritePrimaryColour = value;
                        break;
                    default:
                        throw new ArgumentException(
                            $"{value} is not a primary colour. Choose from: red, green, blue.");
                }
            }
        }
    }
}
