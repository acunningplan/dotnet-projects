using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public partial class Person : IComparable<Person>
    {
        public event EventHandler Shout;
        public int AngerLevel;
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
