using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10.Library.Persons
{
    public class Worker : Person, IComparable<Worker>
    {
        public string Profession { get; set; }
        public double Salary { get; set; }

        public Worker() : base() { } // Вызов конструктора базового класса

        public Worker(string name, int age, string city, string profession, double salary) : base(name, age, city)
        {
            Profession = profession;
            Salary = salary;
        }

        public override void Show()
        {
            Console.WriteLine($"Рабочий: {Name}, Возраст: {Age}, Город: {Address?.City}, Профессия: {Profession}, Зарплата: {Salary: 0.00}");
        }

        public override void Init()
        {
            base.Init(); // Вызов метода Init() базового класса
            Console.Write("Введите профессию: ");
            Profession = Console.ReadLine();
            Console.Write("Введите зарплату: ");
            Salary = double.Parse(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit(); // Вызов метода RandomInit() базового класса
            string[] professions = { "Инженер", "Слесарь", "Токарь", "Сварщик", "Электрик" };
            Random rand = new Random();
            Profession = professions[rand.Next(professions.Length)];
            Salary = rand.NextDouble() * 50000 + 20000; // Зарплата от 20000 до 70000
        }

        public new object Clone() // new скрывает метод Clone базового класса
        {
            return new Worker(Name, Age, Address?.City, Profession, Salary);
        }




        public int CompareTo(Worker other)
        {
            if (other == null) return 1; // this > null 
            return Salary.CompareTo(other.Salary); // Сортировка по зарплате
        }
    }
}
