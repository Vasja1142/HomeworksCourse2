using PR_10.Library.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

// Класс Address
public class Address
{
    public string City { get; set; }
}

public class Person : IInit, ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
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
        Age = int.Parse(Console.ReadLine());
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

}
public class PersonComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return string.Compare(x.Name, y.Name);
    }
}