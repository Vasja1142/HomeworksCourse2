using Lab13;
using PR_10.Library.Goods;
using PR_10.Library.Persons;
using PR_13;
using System.Reflection.Metadata;
using System.Threading.Tasks;

internal class Program
{
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №13: Разработка программы, управляемой событиями");
            Console.WriteLine("--------------------------------------------------------------------");

            // 1. Создать две коллекции MyNewCollection (п.11)
            // Используем MyNewCollection<Goods>, так как иерархия основана на Goods
            MyNewCollection<Goods> collection1 = new MyNewCollection<Goods>("Коллекция 1");
            MyNewCollection<Goods> collection2 = new MyNewCollection<Goods>("Коллекция 2");

            // 2. Создать два объекта типа Journal (п.11)
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            // 3. Подписать объекты Journal на события (п.11)
            // journal1 подписывается на оба события из collection1
            collection1.CollectionCountChanged += journal1.CollectionCountChangedHandler;
            collection1.CollectionReferenceChanged += journal1.CollectionReferenceChangedHandler;

            // journal2 подписывается ТОЛЬКО на CollectionReferenceChanged из ОБЕИХ коллекций
            collection1.CollectionReferenceChanged += journal2.CollectionReferenceChangedHandler;
            collection2.CollectionReferenceChanged += journal2.CollectionReferenceChangedHandler;

            Console.WriteLine("Подписки на события выполнены.");
            Console.WriteLine("Журнал 1 подписан на CountChanged и ReferenceChanged из Коллекции 1.");
            Console.WriteLine("Журнал 2 подписан на ReferenceChanged из Коллекции 1 и Коллекции 2.");
            Console.WriteLine("--------------------------------------------------------------------");


            // 4. Внести изменения в коллекции MyNewCollection (п.12)

            Console.WriteLine("\n--- Действия с Коллекцией 1 ---");
            // Добавление элементов
            collection1.Add(new Product("Хлеб", 50.0));
            collection1.Add(new MilkProduct("Молоко Простоквашино", 80.0, 7));
            collection1.Add(new Toy("Мяч", 150.0, "Резина"));
            collection1.Add(new Goods("Гвозди")); // Просто товар
            Console.WriteLine($"Коллекция 1 после добавления: {collection1.Length} элемента(ов).");

            // Удаление элемента по индексу
            Console.WriteLine("\nУдаляем элемент с индексом 1 (Молоко)...");
            bool removed = collection1.Remove(1);
            if (removed)
                Console.WriteLine($"Удаление успешно. Коллекция 1: {collection1.Length} элемента(ов).");
            else
                Console.WriteLine("Не удалось удалить элемент с индексом 1.");

            // Удаление несуществующего элемента по индексу
            Console.WriteLine("\nПытаемся удалить элемент с индексом 10 (не существует)...");
            removed = collection1.Remove(10);
            if (!removed)
                Console.WriteLine("Удаление неуспешно (ожидаемо).");


            // Изменение элемента по индексу
            Console.WriteLine("\nИзменяем элемент с индексом 0 (Хлеб на Батон)...");
            if (collection1.Length > 0)
            {
                try
                {
                    collection1[0] = new Product("Батон Нарезной", 45.0);
                    Console.WriteLine("Изменение успешно.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка при изменении: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Коллекция пуста, изменение невозможно.");
            }

            // Изменение другого элемента
            Console.WriteLine("\nИзменяем элемент с индексом 1 (Мяч на Куклу)...");
            if (collection1.Length > 1)
            {
                try
                {
                    collection1[1] = new Toy("Кукла Барби", 500.0, "Пластик");
                    Console.WriteLine("Изменение успешно.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка при изменении: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("В коллекции недостаточно элементов для изменения индекса 1.");
            }


            Console.WriteLine("\n--- Действия с Коллекцией 2 ---");
            // Добавление элементов
            collection2.AddDefaults(2); // Добавим 2 случайных товара/продукта
            collection2.Add(new Toy("Машинка", 300.0, "Металл"));
            Console.WriteLine($"Коллекция 2 после добавления: {collection2.Length} элемента(ов).");


            // Изменение элемента по индексу (сгенерирует событие для journal2)
            Console.WriteLine("\nИзменяем элемент с индексом 0 в Коллекции 2...");
            if (collection2.Length > 0)
            {
                try
                {
                    // Создадим новый случайный элемент для замены
                    Goods replacement = new MilkProduct(); // Используем конструктор по умолчанию
                    ((IInit)replacement).RandomInit(); // Генерируем случайные данные
                    collection2[0] = replacement;
                    Console.WriteLine("Изменение успешно.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка при изменении: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Коллекция 2 пуста, изменение невозможно.");
            }


            // Удаление элемента из Коллекции 2 (не должно попасть ни в один журнал)
            Console.WriteLine("\nУдаляем элемент с индексом 1 из Коллекции 2...");
            removed = collection2.Remove(1);
            if (removed)
                Console.WriteLine($"Удаление успешно. Коллекция 2: {collection2.Length} элемента(ов).");
            else
                Console.WriteLine("Не удалось удалить элемент с индексом 1.");


            Console.WriteLine("\n--------------------------------------------------------------------");


            // 5. Вывести данные обоих объектов Journal (п.13)
            Console.WriteLine("\n--- Содержимое Журнала 1 ---");
            Console.WriteLine(journal1.ToString());

            Console.WriteLine("\n--- Содержимое Журнала 2 ---");
            Console.WriteLine(journal2.ToString());

            Console.WriteLine("\n--------------------------------------------------------------------");
            Console.WriteLine("Демонстрация завершена. Нажмите Enter для выхода.");
            Console.ReadLine();
        }

}

