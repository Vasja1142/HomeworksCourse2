using PR_10.Library.Persons;
using PR_10.Library.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PR_10.Library.Persons
{
    public class Address
    {
        private string city;
        public string City
        {
            get => city;
            set
            {
                if (value == null || value == "")
                {
                    city = "Не указан";
                }
                else city = value;
            }
        }
    }

    public class Person : IInit, ICloneable
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == null || value == "")
                    name = "Имя не указано";
                else name = value;
            }

        }
        private int age;
        public int Age
        {
            get => age;
            set
            {

                if (value < 0 || value == null || value > 100)
                {
                    age = 20;
                    Console.WriteLine("Введено некорректное значение. Установлено значение по умолчанию'20'");
                }
                else
                {
                    age = value;
                }
            }
        }
        public Address Address { get; set; }

        public Person()
        {
            Address = new Address();
        }

        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            Address = new Address { City = city };
        }

        public virtual void Show()
        {
            Console.WriteLine($"Человек: {Name}, Возраст: {Age}, Город: {Address?.City}");
        }

        public virtual void Init()
        {
            Console.Write("Введите имя: ");
            Name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            bool isNum = int.TryParse(Console.ReadLine(), out int imputNum);
            if (!isNum)
            {
                Age = 20;
                Console.WriteLine("Введено некорректное значение. Установлено значение по умолчанию'20'.");
            }
            else { Age = imputNum; }
            Console.Write("Введите город: ");
            Address.City = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            string[] names = { "Иван", "Мария", "Петр", "Анна" };
            string[] cities = { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург" };
            Random rand = new Random();
            Name = names[rand.Next(names.Length)];
            Age = rand.Next(18, 60);
            Address.City = cities[rand.Next(cities.Length)];
        }

        public object Clone()
        {
            return new Person(Name, Age, Address?.City); // Глубокое копирование с учетом Address
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Person other = (Person)obj;
            return Name == other.Name && Age == other.Age && Address?.City == other.Address?.City;
        }


        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone(); // Поверхностное копирование
        }
        public override string ToString()
        {
            return $"{Name} ({Address?.City})"; 
        }

    }
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }

}