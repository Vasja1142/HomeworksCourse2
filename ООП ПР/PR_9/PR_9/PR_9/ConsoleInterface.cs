using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_9
{
    internal class ConsoleInterface
    {
        internal static TimeArray CreateTimeArray()
        {
            string message = "Введите длину массива времен: ";
            string errorMessage = "Введено отрицательное значение. Введите корректную длину: ";
            int timeArraySize = ImputPositiveNumber(message, errorMessage);

            TimeArray timeArray = new TimeArray(timeArraySize);
            for (int i = 0; i < timeArraySize; i++) {
                timeArray[i] = CreateTime(i);
            }
            return timeArray;
        }

        public static Time CreateTime(int numTime)
        {
            string message = $"Введите количество минут в {numTime}-м времени: ";
            string errorMessage = "Введено отрицательное значение. Введите корректное время:";           
            return new Time(ImputPositiveNumber(message, errorMessage));
        }


        public static int ImputPositiveNumber(string message, string errorMessage) {
            Console.WriteLine(message);
            int num = ImputInt();
            while (num < 0)
            {
                Console.WriteLine(errorMessage);
                num = ImputInt();
            }
            return num;
        }

        public static int ImputInt()
        {
            int time;
            bool isNumTime = int.TryParse(Console.ReadLine(), out time);
            while (isNumTime)
            {
                Console.WriteLine("Введено не целочисленное значение!");
                isNumTime = int.TryParse(Console.ReadLine(), out time);
            }
            return time;
        }

    }
}
