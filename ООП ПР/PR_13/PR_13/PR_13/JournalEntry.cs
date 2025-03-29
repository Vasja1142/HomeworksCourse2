using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_13
{
    class JournalEntry
    {
        // Название коллекции
        public string CollectionName { get; }

        // Тип изменения
        public string ChangeInfo { get; }

        // Данные объекта (в виде строки)
        public string ChangedItemData { get; }

        // Конструктор
        public JournalEntry(string collectionName, string changeInfo, string changedItemData)
        {
            CollectionName = collectionName;
            ChangeInfo = changeInfo;
            ChangedItemData = changedItemData;
        }

        // Перегрузка ToString для вывода записи журнала
        public override string ToString()
        {
            return $"Коллекция: '{CollectionName}', Изменение: {ChangeInfo}, Данные объекта: [{ChangedItemData}]";
        }
    }
}
