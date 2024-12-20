using PR_10.Library.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10.Library.Goods
{
    public class Goods : IInit
    {
        public string Name { get; set; }

        public Goods() { }

        public Goods(string name)
        {
            Name = name;
        }


        public virtual void Show()
        {
            Console.WriteLine($"Товар: {Name}");
        }
        public void Display() // Невиртуальный метод
        {
            Console.WriteLine($"Товар: {Name}");
        }

        public virtual void Init()
        {
            Console.Write("Введите название товара: ");
            Name = Console.ReadLine();

            if (string.IsNullOrEmpty(Name))
            {
                Console.WriteLine("Название товара не может быть пустым. Устанавливаем значение по умолчанию.");
                Name = "Без названия";
            }
        }

        public virtual void RandomInit()
        {
            Random rand = new Random();
            Name = $"товар_{rand.Next(100, 1000)}"; // Генерируем имя "товар_XXX"
        }
    }

   

}
