using System;

namespace PR_10.Library.Goods
{
    public class MilkProduct : Product, ICloneable
    {
        private int expirationDays;
        public int ExpirationDays
        {
            get => expirationDays;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Срок годности должен быть положительным. Устанавливаем значение 1.");
                    expirationDays = 1;
                }
                else
                {
                    expirationDays = value;
                }
            }
        }

        public MilkProduct() { }

        public MilkProduct(string name, double price, int expirationDays) : base(name, price)
        {
            ExpirationDays = expirationDays;
        }

        public override void Show()
        {
            Console.WriteLine($"Молочный продукт: {Name}, Цена: {Price:0.00} руб., Срок годности: {ExpirationDays} дней");
        }

        public new void Display()
        {
            Console.WriteLine($"Молочный продукт: {Name}, Цена: {Price:0.00} руб., Срок годности: {ExpirationDays} дней");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите срок годности (в днях): ");
            try
            {
                expirationDays = int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}. Установлено значение по умолчанию 1");
            }
        }



        public override void RandomInit()
        {

            base.RandomInit();
            string[] milkProductNames = { "Молоко", "Кефир", "Йогурт", "Сметана", "Творог" };
            Random rand = new Random();
            Name = milkProductNames[rand.Next(milkProductNames.Length)];
            ExpirationDays = rand.Next(1, 30);
        }


        // Переопределение Equals
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) // Вызываем базовый Equals
            {
                return false;
            }
            MilkProduct other = (MilkProduct)obj;
            return ExpirationDays == other.ExpirationDays; // Добавляем сравнение по сроку годности
        }
        // Переопределение GetHashCode
        public override int GetHashCode()
        {
            unchecked // Переполнение допустимо
            {
                int hash = base.GetHashCode(); // Берем хэш от базового класса
                hash = (hash * 397) ^ ExpirationDays.GetHashCode(); // Добавляем хэш срока годности
                return hash;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Срок годности: {ExpirationDays} дн.";
        }

        // Реализация ICloneable (глубокое клонирование)
        public override object Clone()
        {
            return new MilkProduct(this.Name, this.Price, this.ExpirationDays); // Создаем НОВЫЙ объект
        }
    }
}