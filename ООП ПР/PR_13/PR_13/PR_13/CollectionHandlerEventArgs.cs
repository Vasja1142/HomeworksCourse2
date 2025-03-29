using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_13
{
    // Класс для передачи информации о событии (п.6)
    public class CollectionHandlerEventArgs : EventArgs
    {
        // Название коллекции, в которой произошло событие
        public string CollectionName { get; }

        // Информация о типе изменений ("Add", "Remove", "Set")
        public string ChangeInfo { get; }

        // Ссылка на объект, с которым связаны изменения
        public object ChangedItem { get; } // Назвал ChangedItem для ясности, соответствует Obj в задании

        // Конструктор для инициализации
        public CollectionHandlerEventArgs(string collectionName, string changeInfo, object changedItem)
        {
            CollectionName = collectionName;
            ChangeInfo = changeInfo;
            ChangedItem = changedItem;
        }

        // Перегруженная версия метода ToString()
        public override string ToString()
        {
            string itemString = ChangedItem?.ToString() ?? "null"; // Безопасное получение строки объекта
            return $"Коллекция: '{CollectionName}', Изменение: {ChangeInfo}, Объект: [{itemString}]";
        }
    }

    // Определение делегата (п.5)
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
}
