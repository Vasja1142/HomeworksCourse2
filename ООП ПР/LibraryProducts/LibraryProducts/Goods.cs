namespace LibraryProducts
{
    public class Goods
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
            Name = $"товар_{rand.Next(100, 1000)}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Goods other = (Goods)obj;
            return Name == other.Name;
        }


        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }

 
        public virtual object Clone()
        {
            return new Goods(this.Name); // Создаем НОВЫЙ объект
        }

        public override string ToString()
        {
            return $"Товар: {Name}";
        }
    }
}
}
