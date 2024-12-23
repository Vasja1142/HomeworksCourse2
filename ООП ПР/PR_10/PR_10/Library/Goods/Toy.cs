using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10.Library.Goods
{
    public class Toy : Product
    {
        private string material;

        public string Material
        {
            get => material;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Материал не может быть пустым. Устанавливаем значение по умолчанию.");
                    material = "Неизвестный материал";
                }
                else
                {
                    material = value;
                }
            }
        }
        public Toy() { }

        public Toy(string name, double price, string material) : base(name, price)
        {
            Material = material;
        }


        public override void Show()
        {
            Console.WriteLine($"Игрушка: {Name}, Цена: {Price:0.00} руб., Материал: {Material}");
        }

        public new void Display() // Скрываем метод Display() базового класса
        {
            Console.WriteLine($"Игрушка: {Name}, Цена: {Price:0.00} руб., Материал: {Material}");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите материал игрушки: ");
            Material = Console.ReadLine();

            if (string.IsNullOrEmpty(Material))
            {
                Console.WriteLine("Материал не может быть пустым. Устанавливаем значение по умолчанию.");
                Material = "Неизвестный материал";
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] materials = { "Пластик", "Дерево", "Металл", "Ткань" };
            Random rand = new Random();
            Material = materials[rand.Next(materials.Length)];

            string[] toyNames = { "Кукла", "Машинка", "Конструктор", "Мяч", "Пазл" };
            Name = toyNames[rand.Next(toyNames.Length)]; // Выбираем случайное название из списка

        }

    }
}
