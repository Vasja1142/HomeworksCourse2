using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PR_10.Library.Goods; // Подключаем пространство имен с классами Goods, Product, MilkProduct, Toy

namespace PR_12
{


    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрация DoublyLinkedList
            Console.WriteLine("=== Двусвязный список ===");
            DoublyLinkedList doublyList = new DoublyLinkedList();
            doublyList.Add(new Toy("Кукла", 25.50, "Пластик"));
            doublyList.Add(new MilkProduct("Молоко", 2.99, 14));
            doublyList.Add(new Product("Хлеб", 1.50));
            doublyList.Add(new Toy("Машинка", 15.00, "Металл"));

            doublyList.Print();

            Console.WriteLine("\nУдаление первого вхождения 'Кукла':");
            doublyList.DeleteFirstByName("Кукла");
            doublyList.Print();

            Console.WriteLine("\nОчистка списка:");
            doublyList.Clear();
            doublyList.Print(); // Должно быть пусто


            // Демонстрация BinaryTree
            Console.WriteLine("\n=== Бинарное дерево ===");
            BinaryTree binaryTree = new BinaryTree();
            List<Goods> goods = new List<Goods>
            {
                new Toy("Кукла", 25.50, "Пластик"),
                new MilkProduct("Молоко", 2.99, 14),
                new Product("Хлеб", 1.50),
                new Toy("Машинка", 15.00, "Металл"),
                new MilkProduct("Кефир", 3.20, 10)
            };

            binaryTree.BuildIdealTree(goods);
            Console.WriteLine("Идеальное дерево:");
            binaryTree.PrintTree();

            // Подсчет элементов, начинающихся с 'М'
            char searchChar = 'М';
            int countStartingWithM = binaryTree.CountElementsStartingWith(searchChar);
            Console.WriteLine($"\nКоличество элементов, начинающихся с '{searchChar}': {countStartingWithM}");

            // Преобразование в дерево поиска
            Console.WriteLine("\nПреобразование в дерево поиска...");
            binaryTree.ConvertToSearchTree();
            Console.WriteLine("Дерево поиска:");
            binaryTree.PrintTree();

            Console.WriteLine("\nОчистка дерева:");
            binaryTree.Clear();
            binaryTree.PrintTree();  // Ничего не выводится

            // Демонстрация HashTable
            Console.WriteLine("\n=== Хеш-таблица ===");
            HashTable hashTable = new HashTable(5); // Маленький размер для демонстрации
            hashTable.Add("Кукла", new Toy("Кукла", 25.50, "Пластик"));
            hashTable.Add("Молоко", new MilkProduct("Молоко", 2.99, 14));
            hashTable.Add("Хлеб", new Product("Хлеб", 1.50));

            hashTable.PrintTable();

            Console.WriteLine("\nПоиск 'Молоко':");
            Goods foundGood = hashTable.Find("Молоко");
            if (foundGood != null)
            {
                foundGood.Show();
            }
            else
            {
                Console.WriteLine("Не найдено");
            }

            Console.WriteLine("\nУдаление 'Молоко':");
            hashTable.Delete("Молоко");

            Console.WriteLine("\nПоиск 'Молоко' после удаления:");
            foundGood = hashTable.Find("Молоко");
            if (foundGood != null)
            {
                foundGood.Show();
            }
            else
            {
                Console.WriteLine("Не найдено");
            }

            hashTable.PrintTable();
            Console.WriteLine("\nДобавление 'Молоко' снова (должно работать):");
            hashTable.Add("Молоко", new MilkProduct("Молоко", 2.99, 14));
            hashTable.PrintTable();

            // Попытка добавить дубликат
            Console.WriteLine("\nДобавление дубликата");
            hashTable.Add("Кукла", new Toy("Кукла", 25.50, "Пластик"));

            // Добавление для переполнения
            Console.WriteLine("\nПопытка переполнения");
            hashTable.Add("Машинка", new Toy("Машинка", 15.00, "Металл"));
            hashTable.Add("Кефир", new MilkProduct("Кефир", 3.20, 10));
            hashTable.PrintTable();


            // Демонстрация MyCollection (SinglyLinkedList)
            Console.WriteLine("\n=== MyCollection (Односвязный список) ===");
            MyCollection<Goods> myCollection = new MyCollection<Goods>();
            Toy barbie = new Toy("Барби", 30.00, "Пластик");
            myCollection.Add(barbie);
            myCollection.Add(new MilkProduct("Сметана", 4.00, 7));
            myCollection.Add(new Product("Макароны", 2.00));

            Console.WriteLine("Исходная коллекция:");
            foreach (var good in myCollection)
            {
                good.Show(); // Вызываем Show() для каждого элемента
            }

            Console.WriteLine("\nУдаление 'Сметана':");

            MilkProduct smetana = new MilkProduct("Сметана", 4.00, 7);
            myCollection.Remove(smetana);  //  MilkProduct неявно преобразуется к Goods, но сравнение должно работать корректно


            Console.WriteLine("\nКоллекция после удаления:");
            foreach (var good in myCollection)
            {
                good.Show();
            }

            Console.WriteLine("\nПоиск 'Барби':");
            Console.WriteLine(myCollection.Find(barbie) ? "Найдено" : "Не найдено");


            Console.WriteLine("\nГлубокое клонирование:");
            MyCollection<Goods> deepClonedCollection = myCollection.DeepClone();
            foreach (var good in deepClonedCollection)
            {
                good.Show();
            }

            Console.WriteLine("\nОчистка оригинальной коллекции:");
            myCollection.Clear();
            Console.WriteLine($"Количество элементов в оригинальной коллекции: {myCollection.Count}"); // 0
            Console.WriteLine($"Количество элементов в клонированной коллекции: {deepClonedCollection.Count}");

            Console.WriteLine("\nИзменение клонированной коллекции");
            deepClonedCollection.Head.Data.Name = "Изменено";
            foreach (var good in deepClonedCollection)
            {
                good.Show();
            }

            Console.ReadKey();

        }
    }
}