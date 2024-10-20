using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Запускаем второй метод
        method2();
    }

    public static void method2()
    {
        // Читаем количество цветов
        int n = int.Parse(Console.ReadLine());

        // Если количество цветов равно нулю, выводим 0 и выходим
        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }

        // Считываем увлажнённости цветов
        string[] input = Console.ReadLine().Split(' ');
        List<(int moisture, int index)> flowers = new List<(int, int)>();

        for (int i = 0; i < n; i++)
        {
            int moisture = int.Parse(input[i]);
            // Добавляем увлажнённость и индекс цветка в список
            flowers.Add((moisture, i));
        }

        // Сортируем цветы по увлажнённости
        flowers.Sort();

        // Инициализируем переменные
        int steps = flowers.Count; // Начальное количество шагов
        int minMoisture = flowers[0].moisture; // Минимальная увлажнённость
        int minMoistureMaxIndex = flowers[0].index; // Индекс цветка с минимальной увлажнённостью
        int counter = 0;

        // Подсчитываем количество цветов с минимальной увлажнённостью
        foreach (var flower in flowers)
        {
            if (minMoisture == flower.moisture)
            {
                minMoistureMaxIndex = flower.index;
                counter++;
            }
            else break;
        }

        // Обновляем количество шагов с учётом индекса минимальной увлажнённости
        steps += minMoistureMaxIndex;
        int startIndex = counter;

        // Инициализируем переменные для отслеживания позиций
        int minPosition1 = flowers[counter - 1].index;
        int maxPosition1 = flowers[counter - 1].index;
        int minPosition2, maxPosition2;
        long stepMin1 = steps, stepMax1 = steps;
        long stepMin2 = steps, stepMax2 = steps;

        // Основной цикл для обработки оставшихся цветов
        for (int i = startIndex; i < flowers.Count; i++)
        {
            minPosition2 = flowers[i].index;

            // Перемещаемся по цветам с одинаковой увлажнённостью
            while (i + 1 < flowers.Count && flowers[i].moisture == flowers[i + 1].moisture)
            {
                i++;
            }
            maxPosition2 = flowers[i].index;

            // Рассчитываем длину между позициями
            int len = maxPosition2 - minPosition2;
            stepMin2 = Math.Min(Math.Abs(minPosition1 - minPosition2) + stepMin1,
                                 Math.Abs(maxPosition1 - minPosition2) + stepMax1);
            stepMax2 = Math.Min(Math.Abs(minPosition1 - maxPosition2) + stepMin1,
                                 Math.Abs(maxPosition1 - maxPosition2) + stepMax1);

            // Обновляем шаги и позиции для следующей итерации
            stepMax1 = stepMax2 + len;
            stepMin1 = stepMin2 + len;
            maxPosition1 = minPosition2;
            minPosition1 = maxPosition2;
        }

        // Выводим минимальное количество шагов
        Console.WriteLine(Math.Min(stepMax1, stepMin1));
    }

    public static void method1()
    {
        // Читаем количество цветов
        int n = int.Parse(Console.ReadLine());

        // Считываем увлажнённости цветов
        string[] input = Console.ReadLine().Split(' ');
        List<(int moisture, int index)> flowers = new List<(int, int)>();

        for (int i = 0; i < n; i++)
        {
            int moisture = int.Parse(input[i]);
            // Добавляем увлажнённость и индекс цветка в список
            flowers.Add((moisture, i));
        }

        // Сортируем цветы по увлажнённости
        flowers.Sort();
        int steps = flowers.Count; // Начальное количество шагов
        int minMoisture = flowers[0].moisture; // Минимальная увлажнённость
        int minMoistureMaxIndex = flowers[0].index; // Индекс цветка с минимальной увлажнённостью
        int counter = 0;

        // Подсчитываем количество цветов с минимальной увлажнённостью
        foreach (var flower in flowers)
        {
            if (minMoisture == flower.moisture)
            {
                minMoistureMaxIndex = flower.index;
                counter++;
            }
            else break;
        }

        // Обновляем количество шагов с учётом индекса минимальной увлажнённости
        steps += minMoistureMaxIndex;
        // Выводим результат обхода цветов
        Console.WriteLine(bypassingFlowers(flowers, steps, minMoistureMaxIndex, counter));
    }

    public static int bypassingFlowers(List<(int moisture, int index)> flowers, int steps, int position, int startIndex)
    {
        int maxIndex = flowers[startIndex].index; // Максимальный индекс увлажнённого цветка
        int minIndex = flowers[startIndex].index; // Минимальный индекс увлажнённого цветка
        int counter = 0;

        // Находим максимальный индекс среди цветов с одинаковой увлажнённостью
        for (int i = startIndex; i < flowers.Count; i++)
        {
            if (flowers[startIndex].moisture == flowers[i].moisture)
            {
                maxIndex = Math.Max(maxIndex, flowers[i].index);
                counter++;
            }
            else break;
        }

        // Рассчитываем шаги вправо и влево
        int stepRight = Math.Abs(maxIndex - position);
        int stepLeft = Math.Abs(minIndex - position);

        // Рассчитываем длину между минимальным и максимальным индексом
        int len = maxIndex - minIndex;

        // Если все оставшиеся цветы имеют одинаковую увлажнённость
        if (counter == flowers.Count - startIndex)
        {
            return steps + len + Math.Min(stepRight, stepLeft);
        }

        // Возвращаем минимальные шаги для обхода цветов
        return Math.Min(bypassingFlowers(flowers, steps + stepRight + len, minIndex, startIndex + counter),
                        bypassingFlowers(flowers, steps + stepLeft + len, maxIndex, startIndex + counter));
    }
}
