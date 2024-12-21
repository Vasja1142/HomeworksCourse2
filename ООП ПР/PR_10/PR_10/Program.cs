using PR_10.Library.Goods;
using PR_10.Library.Persons;
using System.Xml.Linq;

internal class Program
{
    private static Random rand = new Random();

    public static void Main(string[] args)
    {
        WorkWithGoods(10);

        Person[] people = CreatePersons(10);

        WorkingWithWorker(people);
        WorkingWithIInit();
        WorkingWithICloneable();
        WorkingWithIComparable(people);
    }
    public static Person[] CreatePersons(int len)
    {
        Console.WriteLine("Выберите режим внесения данных людей:\n" +
                            "1. Ручной режим\n" +
                            "2. Автоматический режим");
        int numMode = ImputInt();
        while (numMode > 2 || numMode < 1)
        {
            Console.WriteLine("Введено неверное значение. Введите снова: ");
            numMode = ImputInt();
        }
        Person[] people = new Person[len];
        switch (numMode)
        {
            case 1:
                people = CreateImputPeople(len);
                break;
            case 2:
                people = CreateRandomPeople(len);
                break;
        }
        return people;
    }
    public static void WorkWithGoods(int len)
    {
        //  Создаем массив и заполняем его объектами разных типов
        Goods[] goods = new Goods[len];

        for (int i = 0; i < goods.Length; i++)
        {
            switch (rand.Next(4)) // 4 типа товаров
            {
                case 0: goods[i] = new Goods(); break;
                case 1: goods[i] = new Product(); break;
                case 2: goods[i] = new MilkProduct(); break;
                case 3: goods[i] = new Toy(); break;
            }
            goods[i].RandomInit();
        }

        // Просмотр массива с помощью обычных и виртуальных функций
        Console.WriteLine("\nПросмотр с помощью обычных функций (тип Goods):");
        foreach (Goods g in goods)
        {
            g.Display(); 
        }



        Console.WriteLine("\nПросмотр с помощью виртуальных функций (полиморфизм):");
        foreach (Goods g in goods)
        {
            g.Show(); 
        }


        // 2. Запрос: Количество продуктов с ценой выше заданной
        Console.Write("\nВведите минимальную цену продукта: ");
        double minPrice;
        try
        {
            minPrice = Convert.ToDouble(Console.ReadLine());
        }
        catch (Exception e)
        {
            minPrice = 50;
            Console.WriteLine($"{e.Message} Введено значение по умолчанию - 50");
        }
        int productCount = goods.Count(g => g is Product && ((Product)g).Price > minPrice);

        Console.WriteLine($"Количество продуктов с ценой выше {minPrice}: {productCount}\n");

    }
    public static Person[] CreateRandomPeople(int len)
    {
        Person[] people = new Person[10]; // Теперь массив Person[]

        // Заполняем массив объектами Person, Worker и Customer
        for (int i = 0; i < people.Length; i++)
        {
            int personType = rand.Next(3);
            switch (personType)
            {
                case 0: people[i] = new Person(); break;
                case 1: people[i] = new Worker(); break;
                case 2: people[i] = new Worker(); break;
            }
            people[i].RandomInit();
        }

        people[rand.Next(people.Length)] = new Worker("Вася", 30, "Пермь", "Программист", 50000);
        return people;
    }

    public static Person[] CreateImputPeople(int len)
    {
        Person[] people = new Person[10]; // Теперь массив Person[]

        // Заполняем массив объектами Person, Worker и Customer
        for (int i = 0; i < people.Length; i++)
        {
            int personType = rand.Next(3);
            switch (personType)
            {
                case 0: people[i] = new Person(); break;
                case 1: people[i] = new Worker(); break;
                case 2: people[i] = new Worker(); break;
            }
            people[i].Init();
        }
        return people;
    }

    public static Person[] WorkingWithWorker(Person[] people)
    {
        
        foreach (Person g in people)
        {
            g.Show(); // Вызывается виртуальная функция
        }

        // 1. Запрос: Имена рабочих заданной профессии
        Console.Write("\nВведите профессию для поиска: ");
        string searchProfession = Console.ReadLine();

        var workersWithProfession = people
            .Where(g => g is Worker) // Фильтруем по типу Worker
            .Cast<Worker>()        // Приводим к Worker
            .Where(w => w.Profession == searchProfession); // Фильтруем по профессии

        Console.WriteLine($"Рабочие с профессией '{searchProfession}':");
        foreach (var worker in workersWithProfession)
        {
            Console.WriteLine(worker.Name);
        }

        // 2. Запрос:  Средняя зарплата всех рабочих
        double averageSalary = people
            .Where(g => g is Worker)
            .Cast<Worker>()
            .Average(w => w.Salary);

        Console.WriteLine($"\nСредняя зарплата всех рабочих: {averageSalary:0.00} руб.\n");
        return people;
    }

    public static void WorkingWithIInit()
    {
        IInit[] initArray = new IInit[3];

        initArray[0] = new Person();
        initArray[1] = new Worker();
        initArray[2] = new Product(); //  IInit реализован в Goods и наследуется Product


        foreach (IInit item in initArray)
        {
            item.RandomInit();
            item.Show(); // Полиморфизм: Show() вызывается для разных типов
        }
    }
    public static void WorkingWithICloneable()
    {
        Person p = new Person
        {
            Name = "Оригинал",
            Age = 30,
            Address = new Address { City = "Москва" }
        };

        Person shallowCopy = p.ShallowCopy();
        Person deepCopy = (Person)p.Clone();
        Console.WriteLine("\nОригинал:");
        p.Show();
        p.Address.City = "Санкт-Петербург"; // Изменяем город в оригинале
        p.Age = 35;

        Console.WriteLine("Измененный оригинал:");
        p.Show();
        Console.WriteLine("Поверхностная копия:");
        shallowCopy.Show();
        Console.WriteLine("Клон:");
        deepCopy.Show();
    }

    public static void WorkingWithIComparable(Person[] people)
    {
        // 2. Сортировка массива людей по зарплате (IComparable)
        Worker[] workers = people
            .Where(p => p is Worker)
            .Cast<Worker>()
            .ToArray();

        Array.Sort(workers); // Сортируем массив Worker[]

        Console.WriteLine("\nОтсортированный массив работников (по зарплате):");
        foreach (var worker in workers)
        {
            worker.Show();
        }

        // 3. Сортировка и поиск с IComparer (например, по имени)

        Array.Sort(people, new PersonComparer());
        Console.WriteLine("\nОтсортированный массив людей (по имени):");
        foreach (Person x in people) x.Show();

        // 4. Бинарный поиск
        Console.WriteLine("\nБинарный поиск по зарплате (50000):");
        Array.Sort(people.Where(p => p is Worker).Cast<Worker>().ToArray());
        int index = Array.BinarySearch<Worker>(workers.Cast<Worker>().ToArray(), new Worker { Salary = 50000 });
        if (index >= 0) Console.WriteLine("Элемент найден. Индекс = " + index + ". Имя: " + workers[index].Name + ". Зарплата: " + workers[index].Salary );
        else Console.WriteLine("Элемент не найден");


        Console.ReadKey();

    }

    public static int ImputInt()
    {
        int time;
        bool isIntTime = int.TryParse(Console.ReadLine(), out time);
        while (!isIntTime)
        {
            Console.WriteLine("Введено не целочисленное значение!");
            isIntTime = int.TryParse(Console.ReadLine(), out time);
        }
        return time;
    }
}