using PR_10.Library.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10_Tests
{
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        // Проверка создания рабочего с корректными данными
        public void Worker_Constructor_ValidData_CreatesWorker()
        {
            string name = "Иван";
            int age = 30;
            string city = "Москва";
            string profession = "Инженер";
            double salary = 70000;

            Worker worker = new Worker(name, age, city, profession, salary);

            Assert.AreEqual(name, worker.Name);
            Assert.AreEqual(age, worker.Age);
            Assert.AreEqual(city, worker.Address.City);
            Assert.AreEqual(profession, worker.Profession);
            Assert.AreEqual(salary, worker.Salary);
        }



        [TestMethod]
        // Проверка создания рабочего с отрицательной зарплатой
        public void Worker_Constructor_NegativeSalary_SetsSalaryToDefault()
        {
            string name = "Иван";
            int age = 30;
            string city = "Москва";
            string profession = "Инженер";
            double salary = -70000;
            Worker worker = new Worker(name, age, city, profession, salary);

            Assert.AreEqual(50000, worker.Salary);
        }


        [TestMethod]
        // Проверка сеттера профессии с пустой строкой
        public void Worker_SetProfession_Empty_SetsDefaultProfession()
        {

            Worker worker = new Worker();
            worker.Profession = "";
            Assert.AreEqual("Не указана", worker.Profession);
        }

        [TestMethod]
        // Проверка сеттера зарплаты с отрицательным значением
        public void Worker_SetSalary_NegativeValue_SetsDefaultSalary()
        {

            Worker worker = new Worker();
            worker.Salary = -1000;
            Assert.AreEqual(50000, worker.Salary);
        }



        [TestMethod]
        // Проверка метода Show
        public void Worker_Show_DisplaysCorrectInformation()
        {
            string name = "Петр";
            int age = 28;
            string city = "Екатеринбург";
            string profession = "Слесарь";
            double salary = 60000;

            Worker worker = new Worker(name, age, city, profession, salary);


            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                worker.Show();
                string expected = $"Рабочий: {name}, Возраст: {age}, Город: {city}, Профессия: {profession}, Зарплата: {salary:0.00}\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }

        }

        [TestMethod]
        // Проверка метода Init с корректным вводом
        public void Worker_Init_ValidInput_SetsPropertiesCorrectly()
        {

            Worker worker = new Worker();
            string input = "TestWorker\n32\nTestCity\nTestProfession\n65000";
            using (var sr = new System.IO.StringReader(input))
            {
                Console.SetIn(sr);
                worker.Init();
            }

            Assert.AreEqual("TestWorker", worker.Name);
            Assert.AreEqual(32, worker.Age);
            Assert.AreEqual("TestCity", worker.Address.City);
            Assert.AreEqual("TestProfession", worker.Profession);
            Assert.AreEqual(65000, worker.Salary);
        }

        [TestMethod]
        // Проверка метода RandomInit
        public void Worker_RandomInit_GeneratesRandomValues()
        {
            Worker worker = new Worker();
            worker.RandomInit();


            string[] professions = { "Инженер", "Слесарь", "Токарь", "Сварщик", "Электрик" };


            Assert.IsTrue(worker.Salary >= 20000 && worker.Salary <= 70000);
            Assert.IsTrue(professions.Contains(worker.Profession));
        }

        [TestMethod]
        // Проверка метода Clone
        public void Worker_Clone_CreatesDeepCopy()
        {
            Worker worker = new Worker("Иван", 30, "Москва", "Инженер", 70000);
            Worker clone = (Worker)worker.Clone();

            Assert.AreEqual(worker.Name, clone.Name);
            Assert.AreEqual(worker.Age, clone.Age);
            Assert.AreEqual(worker.Address.City, clone.Address.City);
            Assert.AreEqual(worker.Profession, clone.Profession);
            Assert.AreEqual(worker.Salary, clone.Salary);

            // Проверяем, что Address - это разные объекты
            Assert.AreNotSame(worker.Address, clone.Address);
        }



        [TestMethod]
        // Проверка интерфейса IComparable
        public void Worker_CompareTo_SortsBySalary()
        {
            Worker worker1 = new Worker("Иван", 30, "Москва", "Инженер", 60000);
            Worker worker2 = new Worker("Петр", 28, "Екатеринбург", "Слесарь", 70000);


            int result = worker1.CompareTo(worker2);
            Assert.IsTrue(result < 0);  // worker1.Salary < worker2.Salary


            result = worker2.CompareTo(worker1);
            Assert.IsTrue(result > 0); // worker2.Salary > worker1.Salary

        }
    }
}
