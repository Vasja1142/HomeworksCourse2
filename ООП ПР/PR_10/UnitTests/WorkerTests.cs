using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10.Library.Persons;
using System;

namespace UnitTests
{
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void Worker_Constructor_Default()
        {
            // Arrange & Act
            Worker worker = new Worker();

            // Assert
            Assert.IsNotNull(worker);
            Assert.IsNull(worker.Name);
            Assert.AreEqual(0, worker.Age);
            Assert.IsNull(worker.Address);
            Assert.IsNull(worker.Profession);
            Assert.AreEqual(0, worker.Salary);
        }

        [TestMethod]
        public void Worker_Constructor_Parameterized()
        {
            // Arrange
            string name = "Иван";
            int age = 30;
            string city = "Москва";
            string profession = "Инженер";
            double salary = 50000;

            // Act
            Worker worker = new Worker(name, age, city, profession, salary);

            // Assert
            Assert.AreEqual(name, worker.Name);
            Assert.AreEqual(age, worker.Age);
            Assert.AreEqual(city, worker.Address.City);
            Assert.AreEqual(profession, worker.Profession);
            Assert.AreEqual(salary, worker.Salary);
        }

        [TestMethod]
        public void Worker_Show()
        {
            // Arrange
            Worker worker = new Worker("Иван", 30, "Москва", "Инженер", 50000);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw); // Перенаправляем вывод консоли

            // Act
            worker.Show();

            // Assert
            string expected = $"Рабочий: Иван, Возраст: 30, Город: Москва, Профессия: Инженер, Зарплата: 50000.00{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
        }


        [TestMethod]
        public void Worker_Clone()
        {
            // Arrange
            Worker worker = new Worker("Иван", 30, "Москва", "Инженер", 50000);

            // Act
            Worker clonedWorker = (Worker)worker.Clone();

            // Assert
            Assert.AreNotSame(worker, clonedWorker); // Убедитесь, что это разные объекты
            Assert.AreEqual(worker.Name, clonedWorker.Name);
            Assert.AreEqual(worker.Age, clonedWorker.Age);
            Assert.AreEqual(worker.Address.City, clonedWorker.Address.City);
            Assert.AreEqual(worker.Profession, clonedWorker.Profession);
            Assert.AreEqual(worker.Salary, clonedWorker.Salary);
        }

        [TestMethod]
        public void Worker_CompareTo()
        {
            // Arrange
            Worker worker1 = new Worker("Иван", 30, "Москва", "Инженер", 50000);
            Worker worker2 = new Worker("Петр", 25, "Санкт-Петербург", "Слесарь", 60000);
            Worker worker3 = new Worker("Сидор", 35, "Новосибирск", "Токарь", 50000);

            // Act & Assert
            Assert.AreEqual(-1, worker1.CompareTo(worker2)); // worker1.Salary < worker2.Salary
            Assert.AreEqual(1, worker2.CompareTo(worker1)); // worker2.Salary > worker1.Salary
            Assert.AreEqual(0, worker1.CompareTo(worker3)); // worker1.Salary == worker3.Salary
            Assert.AreEqual(1, worker1.CompareTo(null));   // worker1 > null

        }

        //Тесты для Init() и RandomInit() сложнее реализовать в чистом виде, 
        //так как они используют Console.ReadLine().  Можно использовать подходы с мокированием Console.ReadLine() или перенаправлением ввода.
    }
}