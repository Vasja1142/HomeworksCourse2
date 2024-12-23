using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10.Library.Goods
{
    public class MilkProduct : Product
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
        public new void Display() // Скрываем метод Display() базового класса
        {
            Console.WriteLine($"Молочный продукт: {Name}, Цена: {Price:0.00} руб., Срок годности: {ExpirationDays} дней");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите срок годности (в днях): ");
            try
            {
                expirationDays =  int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}. Установлено значение по умолчанию 1");
            }
        }



        public override void RandomInit()
        {

            base.RandomInit(); // Вызываем RandomInit() базового класса (Product), который вызывает RandomInit() Goods
            string[] milkProductNames = { "Молоко", "Кефир", "Йогурт", "Сметана", "Творог" };
            Random rand = new Random();
            Name = milkProductNames[rand.Next(milkProductNames.Length)];
            ExpirationDays = rand.Next(1, 30);
        }


    }
}
