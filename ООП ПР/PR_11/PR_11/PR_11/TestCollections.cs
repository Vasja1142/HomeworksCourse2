using PR_10.Library.Persons;
using System.Diagnostics;

namespace PR_11
{

    public class TestCollections
    {
        public LinkedList<Worker> Collection1Workers { get; set; }
        public LinkedList<string> Collection1Strings { get; set; }
        public Dictionary<Person, Worker> Collection2PersonWorker { get; set; }
        public Dictionary<string, Worker> Collection2StringWorker { get; set; }

        public TestCollections(int numElements = 1000)
        {
            Collection1Workers = new LinkedList<Worker>();
            Collection1Strings = new LinkedList<string>();
            Collection2PersonWorker = new Dictionary<Person, Worker>();
            Collection2StringWorker = new Dictionary<string, Worker>();

            // Генерация и добавление элементов
            for (int i = 0; i < numElements; i++)
            {
                Worker worker = GenerateWorker(i); // Генерируем рабочего
                Person basePerson = worker.BasePerson; // Получаем базовый объект Person

                Collection1Workers.AddLast(worker);
                Collection1Strings.AddLast(worker.ToString());
                Collection2PersonWorker.Add(basePerson, worker); // Ключ - базовый Person
                Collection2StringWorker.Add(basePerson.ToString(), worker); // Ключ - строковое представление Person
            }
        }

        // Генерация рабочего с автоматическим созданием базового Person
        private Worker GenerateWorker(int id)
        {
            Random rand = new Random();
            string[] names = { "Иван", "Мария", "Петр", "Анна" };
            string[] cities = { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург" };
            string[] professions = { "Инженер", "Слесарь", "Токарь", "Сварщик", "Электрик" };

            string name = names[rand.Next(names.Length)] + id; // Добавляем id, чтобы имена были уникальными
            int age = rand.Next(18, 60);
            string city = cities[rand.Next(cities.Length)];
            string profession = professions[rand.Next(professions.Length)];
            double salary = rand.NextDouble() * 50000 + 20000;

            return new Worker(name, age, city, profession, salary);
        }


        public void AddWorker(Worker worker)
        {

            Collection1Workers.AddLast(worker);
            Collection1Strings.AddLast(worker.ToString());
            Collection2PersonWorker.Add(worker.BasePerson, worker);
            Collection2StringWorker.Add(worker.BasePerson.ToString(), worker);


        }



        public void RemoveWorker(Worker worker)
        {
            Collection1Workers.Remove(worker);
            Collection1Strings.Remove(worker.ToString());

            // Для удаления из словарей нужно получить ключ
            Person basePersonKey = worker.BasePerson;


            Collection2PersonWorker.Remove(basePersonKey);
            Collection2StringWorker.Remove(basePersonKey.ToString());

        }


        public void MeasureSearchTime()
        {

            Worker first = Collection1Workers.First.Value;
            Worker middle = Collection1Workers.ElementAt(Collection1Workers.Count / 2);
            Worker last = Collection1Workers.Last.Value;
            Worker notPresent = GenerateWorker(9999);


            Console.WriteLine("Первое измерение LinkedList:");
            MeasureContainsTime(first, middle, last, notPresent, 1); // 1 итерация для первого измерения

            Console.WriteLine("\nУсредненные значения LinkedList:");
            MeasureContainsTime(first, middle, last, notPresent, 200);
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // Аналогично для ContainsKey и ContainsValue
            Console.WriteLine("\nПервое измерение Dictionary:");
            MeasureContainsKeyTime(first, middle, last, notPresent, 1);

            Console.WriteLine("\nУсредненные значения Dictionary:");
            MeasureContainsKeyTime(first, middle, last, notPresent, 200);
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("\nПервое измерение Dictionary:");
            MeasureContainsValueTime(first, middle, last, notPresent, 1);

            Console.WriteLine("\nУсредненные значения Dictionary:");
            MeasureContainsValueTime(first, middle, last, notPresent, 200);
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }



        private void MeasureContainsTime(Worker first, Worker middle, Worker last, Worker notPresent, int iterations)
        {
            Console.WriteLine("Время поиска Contains (мкс):");
            MeasureTime(() => Collection1Workers.Contains(first), "Первый (Worker):", iterations); // LinkedList<Worker>
            MeasureTime(() => Collection1Workers.Contains(middle), "Центральный (Worker):", iterations);
            MeasureTime(() => Collection1Workers.Contains(last), "Последний (Worker):", iterations);
            MeasureTime(() => Collection1Workers.Contains(notPresent), "Отсутствует (Worker):", iterations);

            MeasureTime(() => Collection1Strings.Contains(first.ToString()), "Первый (string):", iterations); // LinkedList<string>
                                                                                                  // ... (аналогично для middle, last, notPresent, используя ToString())
            MeasureTime(() => Collection1Strings.Contains(middle.ToString()), "Центральный (string):", iterations);
            MeasureTime(() => Collection1Strings.Contains(last.ToString()), "Последний (string):", iterations);
            MeasureTime(() => Collection1Strings.Contains(notPresent.ToString()), "Отсутствует (string):", iterations);

        }

        private void MeasureContainsKeyTime(Worker first, Worker middle, Worker last, Worker notPresent, int iterations)
        {
            Console.WriteLine("\nВремя поиска ContainsKey (мкс):");

            Person firstKey = first.BasePerson;
            // ... (аналогично для middleKey, lastKey, notPresentKey)
            Person middleKey = middle.BasePerson;
            Person lastKey = last.BasePerson;
            Person notPresentKey = notPresent.BasePerson;

            MeasureTime(() => Collection2PersonWorker.ContainsKey(firstKey), "Первый (Person):",iterations); // Dictionary<Person, Worker>
            // ... (аналогично для middleKey, lastKey, notPresentKey)
            MeasureTime(() => Collection2PersonWorker.ContainsKey(middleKey), "Центральный (Person):", iterations);
            MeasureTime(() => Collection2PersonWorker.ContainsKey(lastKey), "Последний (Person):", iterations);
            MeasureTime(() => Collection2PersonWorker.ContainsKey(notPresentKey), "Отсутствует (Person):", iterations);


            MeasureTime(() => Collection2StringWorker.ContainsKey(firstKey.ToString()), "Первый (string):", iterations); // Dictionary<string, Worker>
            // ... (аналогично для middle, last, notPresent, используя ToString())
            MeasureTime(() => Collection2StringWorker.ContainsKey(middleKey.ToString()), "Центральный (string):", iterations);
            MeasureTime(() => Collection2StringWorker.ContainsKey(lastKey.ToString()), "Последний (string):", iterations);
            MeasureTime(() => Collection2StringWorker.ContainsKey(notPresentKey.ToString()), "Отсутствует (string):", iterations);

        }


        private void MeasureContainsValueTime(Worker first, Worker middle, Worker last, Worker notPresent, int iterations)
        {
            Console.WriteLine("\nВремя поиска ContainsValue (мкс):");
            MeasureTime(() => Collection2PersonWorker.ContainsValue(first), "Первый (Worker):", iterations); // Dictionary<Person, Worker>
            // ... (аналогично для middle, last, notPresent)
            MeasureTime(() => Collection2PersonWorker.ContainsValue(middle), "Центральный (Worker):", iterations);
            MeasureTime(() => Collection2PersonWorker.ContainsValue(last), "Последний (Worker):", iterations);
            MeasureTime(() => Collection2PersonWorker.ContainsValue(notPresent), "Отсутствует (Worker):", iterations);

        }



        private void MeasureTime(Action action, string message, int iterations = 1)
        {
            // Метод-обертка для первого вызова (с JIT-компиляцией)
            Action firstRunAction = () =>
            {
                action(); // Один вызов для JIT, без дополнительных операций
            };

            double totalTime = 0;

            if (iterations == 1) // Первый замер (с JIT)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                firstRunAction(); // Вызываем обертку для JIT-компиляции и измерения времени
                sw.Stop();
                totalTime = sw.Elapsed.TotalMicroseconds;
            }
            else // Остальные замеры (без JIT, усреднение)
            {
                // "Прогрев" перед усреднением (без измерения времени)
                action();

                for (int i = 0; i < iterations; i++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    action();
                    sw.Stop();
                    totalTime += sw.Elapsed.TotalMicroseconds;
                }

                totalTime /= iterations;
            }

            Console.WriteLine($"{message} {totalTime:F2} мкс" + (iterations > 1 ? $" (среднее за {iterations} измерений)" : ""));
        }




    }
}
