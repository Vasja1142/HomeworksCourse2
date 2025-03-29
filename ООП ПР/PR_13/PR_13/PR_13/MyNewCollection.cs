
using System;
using System.Collections.Generic; // Для List<T> в SortUsingList, если используется
using System.Collections.ObjectModel;
using PR_10; // Для IInit
using PR_12;
using Lab13;

namespace Lab13
{
    // Класс MyNewCollection, производный от MyCollection (п.3)
    public class MyNewCollection<T> : MyCollection<T> where T : IInit, new() // Добавляем ограничения из AddDefaults
    {
        // Открытое автореализуемое свойство с названием коллекции (п.4)
        public string CollectionName { get; set; }

        // Конструктор по умолчанию
        public MyNewCollection(string name) : base()
        {
            CollectionName = name;
        }

        // Конструктор копирования
        public MyNewCollection(string name, IEnumerable<T> collection) : base(collection)
        {
            CollectionName = name;
        }

        // Событие при изменении количества элементов (п.7)
        public event CollectionHandler CollectionCountChanged;

        // Событие при изменении ссылки на элемент (п.7)
        public event CollectionHandler CollectionReferenceChanged;

        // Защищенный виртуальный метод для генерации события CollectionCountChanged (хороший стиль)
        protected virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            // Проверяем, есть ли подписчики на событие
            CollectionCountChanged?.Invoke(source, args);
            // Эквивалентно:
            // if (CollectionCountChanged != null)
            // {
            //     CollectionCountChanged(source, args);
            // }
        }

        // Защищенный виртуальный метод для генерации события CollectionReferenceChanged (хороший стиль)
        protected virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }

        // Переопределение метода Add для генерации события (п.8 - неявно требуется для Add)
        public override void Add(T item)
        {
            base.Add(item); // Вызываем базовую логику добавления
            // Генерируем событие ПОСЛЕ успешного добавления
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.CollectionName, "Добавление", item));
        }

        // Переопределение AddDefaults для генерации события (п.8)
        // Примечание: AddDefaults вызывает Add, который уже генерирует событие для каждого элемента.
        // Генерировать одно событие на всю операцию AddDefaults может быть альтернативным подходом,
        // но следуя прямому требованию "AddDefaults бросает событие", оставим так,
        // что событие будет брошено N раз (по одному на каждый добавленный элемент).
        // Если нужно одно событие - нужно переопределить AddDefaults и вызвать OnCollectionCountChanged один раз после цикла.

        // Переопределение AddRange - аналогично AddDefaults, событие генерируется в Add
        // public new void AddRange(IEnumerable<T> collection) { ... } // Если нужна своя логика

        // Переопределение Remove(T item) для генерации события
        public override bool Remove(T item)
        {
            // Попытаемся найти элемент, чтобы передать его в событие
            // Необходимо найти элемент *перед* удалением, чтобы иметь на него ссылку
            T itemToRemove = default(T);
            bool found = false;
            var current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    itemToRemove = current.Data;
                    found = true;
                    break;
                }
                current = current.Next;
            }

            if (!found) return false; // Элемент не найден, событие не генерируем

            // Выполняем удаление с помощью базового метода
            bool removed = base.Remove(item); // Удаляем элемент

            if (removed) // Если удаление прошло успешно
            {
                // Генерируем событие ПОСЛЕ успешного удаления
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.CollectionName, "Удаление", itemToRemove));
            }
            return removed;
        }


        // Новый метод bool Remove(int j) для удаления по индексу (п.4, п.8)
        public bool Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                return false; // Недопустимый индекс
            }

            SinglyLinkedPoint<T> current = head;
            SinglyLinkedPoint<T> previous = null;
            T removedItem = default(T);

            if (index == 0) // Удаление первого элемента
            {
                removedItem = head.Data;
                head = head.Next;
            }
            else
            {
                // Идем до узла ПЕРЕД удаляемым
                for (int i = 0; i < index; i++)
                {
                    previous = current;
                    current = current.Next;
                    // Доп. проверка на всякий случай, хотя count должен гарантировать
                    if (current == null) return false;
                }
                // Нашли узел для удаления (current)
                removedItem = current.Data;
                // Исключаем его из списка
                previous.Next = current.Next;
            }

            count--; // Уменьшаем счетчик
            // Генерируем событие ПОСЛЕ успешного удаления (п.8)
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.CollectionName, "Удаление по индексу", removedItem));
            return true;
        }


        // Индексатор с целочисленным индексом (п.4, п.9)
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне допустимого диапазона.");
                }

                var current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set // п.9 - set бросает событие CollectionReferenceChanged
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне допустимого диапазона.");
                }

                var current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                // Получаем старое значение для возможного использования (хотя в событие передаем новое)
                T oldValue = current.Data;

                // Генерируем событие ПЕРЕД присвоением нового значения (или после, по логике задания)
                // В задании сказано "присваивается новое значение", событие передает "ссылку на новый элемент"
                // Логично генерировать после присвоения, но пример показывает генерацию *до* присвоения базовому классу.
                // Сделаем как в примере - генерируем ДО изменения.
                // В событие передаем НОВОЕ значение 'value'
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(this.CollectionName, "Присвоение нового значения элементу", value));

                // Присваиваем новое значение
                current.Data = value;
            }
        }

        // Переопределение Clear для генерации события (хотя не требуется по заданию)
        // public new void Clear()
        // {
        //     int originalCount = count;
        //     base.Clear();
        //     if (originalCount > 0) // Генерируем событие, только если коллекция не была пустой
        //     {
        //         OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.CollectionName, "Очистка коллекции", null)); // Объект null, т.к. удалено много элементов
        //     }
        // }
    }
}