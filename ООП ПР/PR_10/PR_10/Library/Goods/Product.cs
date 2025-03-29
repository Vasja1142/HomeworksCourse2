using System;

namespace PR_10.Library.Goods
{
    public class Product : Goods, ICloneable
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
            Price = price;
        }

        public override void Show()
        {
            Console.WriteLine($"Продукт: {Name}, Цена: {Price:0.00} руб.");
        }
        public new void Display()
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
        // Переопределение Equals
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) // Сначала вызываем базовую версию Equals
            {
                return false;
            }
            Product other = (Product)obj;
            return Price == other.Price;  // Добавляем сравнение по цене
        }
        // Переопределение GetHashCode
        public override int GetHashCode()
        {
            unchecked // Переполнение допустимо
            {
                int hash = base.GetHashCode(); // Берем хэш от базового класса
                hash = (hash * 397) ^ Price.GetHashCode(); // Добавляем хэш цены
                return hash;
            }
        }

        // Реализация ICloneable (глубокое клонирование)
        public override object Clone()
        {
            return new Product(this.Name, this.Price); // Создаем НОВЫЙ объект
        }

        public override string ToString()
        {
            // Используем base.ToString() для получения информации из базового класса
            return $"{base.ToString()}, Цена: {Price:C}"; // C - формат валюты
        }
    }
}