using System;

namespace PR_10.Library.Goods
{
    public class Toy : Product, ICloneable
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

        public new void Display()
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
            Name = toyNames[rand.Next(toyNames.Length)];
        }
        // Переопределение Equals
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) // Вызываем базовый Equals
            {
                return false;
            }
            Toy other = (Toy)obj;
            return Material == other.Material;  // Добавляем сравнение по материалу
        }
        // Переопределение GetHashCode
        public override int GetHashCode()
        {
            unchecked // Переполнение допустимо
            {
                int hash = base.GetHashCode(); // Берем хэш от базового класса
                hash = (hash * 397) ^ (Material != null ? Material.GetHashCode() : 0); // Добавляем хэш материала
                return hash;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Материал: {Material}";
        }


        // Реализация ICloneable (глубокое клонирование)
        public override object Clone()
        {
            return new Toy(this.Name, this.Price, this.Material); // Создаем НОВЫЙ объект
        }
    }
}