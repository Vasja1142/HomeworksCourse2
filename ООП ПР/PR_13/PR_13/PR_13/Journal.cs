using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_13
{
    class Journal
    {
        // Список записей журнала
        private List<JournalEntry> journalEntries = new List<JournalEntry>();

        // Обработчик события CollectionCountChanged (п.10)
        // Метод должен соответствовать сигнатуре делегата CollectionHandler
        public void CollectionCountChangedHandler(object source, CollectionHandlerEventArgs args)
        {
            // Создаем новую запись в журнале на основе полученных аргументов
            JournalEntry entry = new JournalEntry(
                args.CollectionName,
                args.ChangeInfo,
                args.ChangedItem?.ToString() ?? "null" // Безопасно получаем строку объекта
            );
            // Добавляем запись в список
            journalEntries.Add(entry);
        }

        // Обработчик события CollectionReferenceChanged (п.10)
        // Метод должен соответствовать сигнатуре делегата CollectionHandler
        public void CollectionReferenceChangedHandler(object source, CollectionHandlerEventArgs args)
        {
            // Создаем новую запись в журнале
            JournalEntry entry = new JournalEntry(
                args.CollectionName,
                args.ChangeInfo,
                args.ChangedItem?.ToString() ?? "null" // Безопасно получаем строку объекта
            );
            // Добавляем запись в список
            journalEntries.Add(entry);
        }

        // Метод для вывода содержимого журнала в консоль или в виде строки
        public override string ToString()
        {
            if (journalEntries.Count == 0)
            {
                return "Журнал пуст.";
            }

            StringBuilder sb = new StringBuilder("Содержимое журнала:\n");
            foreach (var entry in journalEntries)
            {
                sb.AppendLine(entry.ToString());
            }
            return sb.ToString();
        }
    }
}

