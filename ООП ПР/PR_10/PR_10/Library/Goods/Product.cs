using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10.Library.Goods
{
    public class Product : Goods
    {
        private double price;

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Цена не может быть отрицательной. Устанавливаем значение 0.");
                    price = 0;
                }
                else
                {
                    price = value;
                }
            }
        }

        public Product() { }

        public Product(string name, double price) : base(name)
        {
            Price = price; // Используем сеттер для проверки значения
        }


        public override void Show()
        {
            Console.WriteLine($"Продукт: {Name}, Цена: {Price:0.00} руб.");
        }
        public new void Display() // Скрываем метод Display() базового класса
        {
            Console.WriteLine($"Продукт: {Name}, Цена: {Price:0.00} руб.");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите цену продукта: ");

            try
            {
                Price = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Price = 0;
                Console.WriteLine($"{ex.Message} Введено значение по умолчанию '0'");
            }

        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random rand = new Random();
            Price = rand.NextDouble() * 100;
        }

    }
}
