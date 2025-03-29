using PR_10;
using System.Collections;

namespace PR_12
{
    // Задание 4: Обобщенная коллекция
    public class SinglyLinkedPoint<T>
    {
        public T Data { get; set; } // Данные узла
        public SinglyLinkedPoint<T> Next { get; set; } // Ссылка на следующий узел

        public SinglyLinkedPoint(T data)
        {
            Data = data;
            Next = null;
        }

        // Переопределяем ToString для удобства отладки узла
        public override string ToString()
        {
            return Data?.ToString() ?? "null";
        }
    }


    public class MyCollection<T> : IEnumerable<T>, ICollection
    {
        protected SinglyLinkedPoint<T> head; // Начало списка (protected для доступа из наследника)
        protected int count; // Количество элементов (protected для доступа из наследника)

        // Свойство для получения количества элементов (требование п.2)
        public int Length => count;

        // Конструктор по умолчанию
        public MyCollection()
        {
            head = null;
            count = 0;
        }

        // Конструктор для создания коллекции заданной емкости (для списка не очень актуально, но оставим)
        public MyCollection(int capacity) : this() // Вызов конструктора по умолчанию
        {
            // В списке емкость не резервируется заранее
        }

        // Конструктор копирования (поверхностное копирование)
        public MyCollection(IEnumerable<T> collection) : this()
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
            {
                Add(item); // Добавляем элементы из другой коллекции
            }
        }

        // Метод добавления элемента в конец списка
        public virtual void Add(T item) // Сделаем виртуальным для переопределения
        {
            var newNode = new SinglyLinkedPoint<T>(item);
            if (head == null)
            {
                head = newNode; // Список был пуст
            }
            else
            {
                var current = head;
                while (current.Next != null) // Идем до последнего элемента
                {
                    current = current.Next;
                }
                current.Next = newNode; // Добавляем в конец
            }
            count++;
        }

        // Метод для добавления элементов из другой коллекции
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        // Метод для автоматического формирования элементов (требование п.2)
        // Используем ограничение where T : IInit, new() для вызова RandomInit
        public void AddDefaults(int numberOfItems) where T : IInit, new()
        {
            if (numberOfItems <= 0) return;
            for (int i = 0; i < numberOfItems; i++)
            {
                T newItem = new T(); // Создаем объект типа T
                newItem.RandomInit(); // Инициализируем случайными данными
                Add(newItem);
            }
        }


        // Метод удаления первого вхождения элемента (по значению)
        public virtual bool Remove(T item) // Сделаем виртуальным
        {
            if (head == null) return false; // Список пуст

            // Проверка головы списка
            if (EqualityComparer<T>.Default.Equals(head.Data, item)) // Используем EqualityComparer для обобщенного сравнения
            {
                head = head.Next;
                count--;
                return true;
            }

            // Поиск в остальной части списка
            var current = head;
            while (current.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Next.Data, item))
                {
                    current.Next = current.Next.Next; // Исключаем узел из списка
                    count--;
                    return true;
                }
                current = current.Next;
            }

            return false; // Элемент не найден
        }


        // Метод очистки коллекции
        public void Clear()
        {
            head = null;
            count = 0;
            // Здесь можно было бы добавить вызов события, но это будет в наследнике
        }

        // Проверка наличия элемента
        public bool Contains(T item)
        {
            var current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // --- Реализация IEnumerable<T> ---
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data; // Возвращаем данные текущего узла
                current = current.Next; // Переходим к следующему
            }
        }

        // --- Реализация IEnumerable ---
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Возвращаем обобщенный перечислитель
        }

        // --- Реализация ICollection ---
        public int Count => count; // Свойство для количества элементов

        public bool IsReadOnly => false; // Коллекция изменяемая

        // Для ICollection (в простых реализациях можно оставить так)
        public bool IsSynchronized => false;
        public object SyncRoot => this;

        // Копирование элементов коллекции в массив
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Rank != 1) throw new ArgumentException("Массив должен быть одномерным.", nameof(array));
            if (array.Length - arrayIndex < count) throw new ArgumentException("Недостаточно места в целевом массиве.");

            var current = head;
            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }

        // Реализация CopyTo для необобщенного ICollection
        public void CopyTo(Array array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (array.Rank != 1) throw new ArgumentException("Массив должен быть одномерным.", nameof(array));
            // Проверка типа не обязательна строго, но желательна
            // if (array.Length - index < count) throw new ArgumentException("Недостаточно места в целевом массиве.");

            try
            {
                var current = head;
                while (current != null)
                {
                    if (index >= array.Length)
                        throw new ArgumentException("Недостаточно места в целевом массиве или индекс вышел за границы.");
                    array.SetValue(current.Data, index++);
                    current = current.Next;
                }
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException("Тип элементов коллекции несовместим с типом массива.", nameof(array), ex);
            }
        }

        // --- Методы из Лаб. 12 (Клонирование) ---
        // Глубокое клонирование (если T реализует ICloneable)
        public MyCollection<T> DeepClone() where T : ICloneable
        {
            MyCollection<T> clone = new MyCollection<T>();
            var current = head;
            while (current != null)
            {
                if (current.Data != null)
                {
                    // Клонируем сам объект данных
                    T clonedData = (T)current.Data.Clone();
                    clone.Add(clonedData);
                }
                else
                {
                    clone.Add(default(T)); // Добавляем null или значение по умолчанию
                }
                current = current.Next;
            }
            return clone;
        }

        // Поверхностное копирование
        public MyCollection<T> ShallowCopy()
        {
            // Можно использовать конструктор копирования
            return new MyCollection<T>(this);
        }


        // Метод сортировки (п.2) - требует IComparable<T>
        // Сортировка пузырьком как пример (не самая эффективная для списка)
        public void Sort() where T : IComparable<T>
        {
            if (count < 2) return; // Нечего сортировать

            bool swapped;
            do
            {
                swapped = false;
                var current = head;
                SinglyLinkedPoint<T> previous = null;

                while (current != null && current.Next != null)
                {
                    var nextNode = current.Next;
                    if (current.Data.CompareTo(nextNode.Data) > 0) // Если текущий > следующего
                    {
                        // Меняем узлы местами
                        if (previous == null) // Обмен с головой
                        {
                            head = nextNode;
                        }
                        else
                        {
                            previous.Next = nextNode;
                        }
                        current.Next = nextNode.Next;
                        nextNode.Next = current;

                        // Обновили previous для следующей итерации
                        previous = nextNode;
                        // current остается тем же узлом, но теперь он после nextNode
                        // поэтому в следующей итерации `current = head` или `previous.Next` установит правильное начало

                        swapped = true;
                        // Так как мы поменяли current и nextNode,
                        // на следующей итерации внешнего цикла while нам нужно
                        // начать сравнение с узла, который *теперь* находится перед 'current'
                        // но 'current' сам сдвинулся, поэтому проще перезапустить внутренний цикл или перестроить логику
                        // Для простоты можно перезапускать внешний do-while, но это неэффективно.
                        // Корректная реализация обмена для списка сложнее.

                        // Альтернатива: Сортировка копированием в List<T> и обратно
                        // Это проще и часто эффективнее для связного списка
                        SortUsingList(); // Вызовем более простой метод
                        return; // Выходим после сортировки через список

                    }
                    else
                    {
                        // Переходим к следующей паре
                        previous = current;
                        current = current.Next;
                    }
                }
            } while (swapped);
        }

        // Вспомогательный метод сортировки через List<T>
        private void SortUsingList() where T : IComparable<T>
        {
            if (count < 2) return;
            List<T> tempList = new List<T>(this); // Копируем все элементы в List
            tempList.Sort(); // Используем быструю сортировку List<T>
            // Перестраиваем связный список
            Clear(); // Очищаем текущий список
            AddRange(tempList); // Добавляем отсортированные элементы обратно
        }

        // Перегрузка для сортировки с использованием IComparer<T>
        public void Sort(IComparer<T> comparer)
        {
            if (count < 2) return;
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            List<T> tempList = new List<T>(this);
            tempList.Sort(comparer); // Используем переданный компаратор
            Clear();
            AddRange(tempList);
        }
    }
}