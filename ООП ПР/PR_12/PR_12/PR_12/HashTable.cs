using PR_10.Library.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_12
{
    // Задание 3: Хеш-таблица
    public class HashEntry
    {
        public string Key;
        public Goods Value;
        public bool IsDeleted;

        public HashEntry(string key, Goods value)
        {
            Key = key;
            Value = value;
            IsDeleted = false;
        }
    }

    public class HashTable
    {
        private HashEntry[] table;
        private int size;
        private int count;

        public HashTable(int size)
        {
            this.size = size;
            table = new HashEntry[size];
            count = 0;
        }

        private int HashFunction(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash = (hash * 31) + c;
            }
            return Math.Abs(hash % size);
        }

        public void Add(string key, Goods value)
        {
            if (count == size)
            {
                Console.WriteLine("Хеш-таблица заполнена.");
                return;
            }

            int index = HashFunction(key);
            int startIndex = index; // Сохраняем начальный индекс

            while (table[index] != null && !table[index].IsDeleted)
            {
                if (table[index].Key == key)
                {
                    Console.WriteLine($"Ключ '{key}' уже есть.");
                    return;
                }
                index = (index + 1) % size;
                if (index == startIndex) // Проверка на зацикливание!
                {
                    Console.WriteLine("Хеш-таблица заполнена (коллизии).");
                    return;
                }
            }

            table[index] = new HashEntry(key, value);
            count++;
        }
        public Goods Find(string key)
        {
            int index = HashFunction(key);

            while (table[index] != null)
            {
                if (table[index].Key == key && !table[index].IsDeleted)
                {
                    return table[index].Value;
                }
                index = (index + 1) % size;
            }

            return null;
        }

        public void Delete(string key)
        {
            int index = HashFunction(key);

            while (table[index] != null)
            {
                if (table[index].Key == key && !table[index].IsDeleted)
                {
                    table[index].IsDeleted = true;
                    count--;
                    return;
                }
                index = (index + 1) % size;
            }
        }

        public void PrintTable()
        {
            Console.WriteLine("Содержимое хеш-таблицы:");
            for (int i = 0; i < size; i++)
            {
                if (table[i] != null && !table[i].IsDeleted)
                {
                    Console.WriteLine($"Индекс {i}: Ключ = {table[i].Key}, Значение = {table[i].Value.Name}");
                }
                else
                {
                    Console.WriteLine($"Индекс {i}: Пусто");
                }
            }
        }
    }


}
