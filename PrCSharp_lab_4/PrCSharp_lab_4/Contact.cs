using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_4
{
    public class Contact
    {
        private static readonly Random random = new Random();

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value ?? GenerateRandomName(); }
        }

        public int Age
        {
            get { return Age; }
            set { Age = value > 0 ? value : throw new ArgumentException(); }
        }

        public Contact(string name, int age)
        {
            Name = name;
            Age = age;
        }

        private string GenerateRandomName()
        {
            string randomName = "user";
            for (int i = 0; i < 5; i++)
            {
                randomName += random.Next(0, 9);
            }

            return randomName;
        }

        public override string ToString() => $"{Name}";
    }
}
