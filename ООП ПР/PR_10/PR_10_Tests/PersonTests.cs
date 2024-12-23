using PR_10.Library.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10_Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        // Проверка создания человека с корректными данными
        public void Person_Constructor_ValidData_CreatesPerson()
        {
            string name = "Иван";
            int age = 30;
            string city = "Москва";

            Person person = new Person(name, age, city);

            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(age, person.Age);
            Assert.AreEqual(city, person.Address.City);
        }


        [TestMethod]
        // Проверка создания человека с некорректным возрастом (отрицательным)
        public void Person_Constructor_NegativeAge_SetsAgeToDefault()
        {
            string name = "Иван";
            int age = -5;
            string city = "Москва";

            Person person = new Person(name, age, city);

            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(20, person.Age);  // Возраст должен быть установлен в 20
            Assert.AreEqual(city, person.Address.City);
        }


        [TestMethod]
        // Проверка сеттера имени с пустой строкой
        public void Person_SetName_Empty_SetsDefaultName()
        {
            Person person = new Person();
            person.Name = "";
            Assert.AreEqual("Имя не указано", person.Name);

        }

        [TestMethod]
        public void Person_SetAddress_Empty_SetsDefaultName()
        {
            string name = "Мария";
            int age = 25;
            string city = "";
            Person person = new Person(name, age, city);
            Assert.AreEqual("Не указан", person.Address.City);
        }

        [TestMethod]
        public void Worker_Init_SetsPropertiesFromInput()
        {
            string input = "Jane Doe\n25\nLondon\nEngineer\n60000";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var worker = new Worker();
                worker.Init();
                Assert.AreEqual("Jane Doe", worker.Name);
                Assert.AreEqual(25, worker.Age);
                Assert.AreEqual("London", worker.Address.City);
                Assert.AreEqual("Engineer", worker.Profession);
                Assert.AreEqual(60000, worker.Salary);
            }
        }

        [TestMethod]
        public void Person_Init_SetsPropertiesFromInput()
        {
            string input = "John Doe\n30\nNew York";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var person = new Person();
                person.Init();
                Assert.AreEqual("John Doe", person.Name);
                Assert.AreEqual(30, person.Age);
                Assert.AreEqual("New York", person.Address.City);
            }
        }

        [TestMethod]
        // Проверка сеттера возраста с некорректным значением (больше 100)
        public void Person_SetAge_InvalidValue_SetsAgeToDefault()
        {
            Person person = new Person();
            person.Age = 120;
            Assert.AreEqual(20, person.Age);
        }

        [TestMethod]
        // Проверка метода Show
        public void Person_Show_DisplaysCorrectInformation()
        {
            string name = "Мария";
            int age = 25;
            string city = "Санкт-Петербург";
            Person person = new Person(name, age, city);


            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                person.Show();
                string expected = $"Человек: {name}, Возраст: {age}, Город: {city}\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        // Проверка метода Init с корректным вводом
        public void Person_Init_ValidInput_SetsPropertiesCorrectly()
        {
            Person person = new Person();
            string input = "TestPerson\n35\nTestCity";

            using (var sr = new System.IO.StringReader(input))
            {
                Console.SetIn(sr);
                person.Init();
            }

            Assert.AreEqual("TestPerson", person.Name);
            Assert.AreEqual(35, person.Age);
            Assert.AreEqual("TestCity", person.Address.City);

        }


        [TestMethod]
        // Проверка метода RandomInit
        public void Person_RandomInit_GeneratesRandomValues()
        {
            Person person = new Person();
            person.RandomInit();

            string[] names = { "Иван", "Мария", "Петр", "Анна" };
            string[] cities = { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург" };

            Assert.IsTrue(names.Contains(person.Name));
            Assert.IsTrue(person.Age >= 18 && person.Age < 60);
            Assert.IsTrue(cities.Contains(person.Address.City));
        }

        [TestMethod]
        // Проверка метода Clone (глубокое копирование)
        public void Person_Clone_CreatesDeepCopy()
        {
            Person person = new Person("Иван", 30, "Москва");
            Person clone = (Person)person.Clone();

            Assert.AreEqual(person.Name, clone.Name);
            Assert.AreEqual(person.Age, clone.Age);
            Assert.AreEqual(person.Address.City, clone.Address.City);

            // Проверяем, что Address - это разные объекты (глубокая копия)
            Assert.AreNotSame(person.Address, clone.Address);

        }


        [TestMethod]
        // Проверка метода ShallowCopy (поверхностное копирование)
        public void Person_ShallowCopy_CreatesShallowCopy()
        {
            Person person = new Person("Иван", 30, "Москва");
            Person shallowCopy = person.ShallowCopy();

            Assert.AreEqual(person.Name, shallowCopy.Name);
            Assert.AreEqual(person.Age, shallowCopy.Age);
            Assert.AreEqual(person.Address.City, shallowCopy.Address.City);

            // Проверяем, что Address - это один и тот же объект (поверхностная копия)
            Assert.AreSame(person.Address, shallowCopy.Address);

        }



        [TestMethod]
        public void Person_Equals_ReturnsTrueForEqualPersons()
        {
            Person person1 = new Person("Иван", 30, "Москва");
            Person person2 = new Person("Иван", 30, "Москва");

            Assert.IsTrue(person1.Equals(person2));
        }

        [TestMethod]
        // Проверка работы IComparer
        public void PersonComparer_Compare_SortsByName()
        {
            Person person1 = new Person("Анна", 25, "Москва");
            Person person2 = new Person("Иван", 30, "Санкт-Петербург");

            PersonComparer comparer = new PersonComparer();
            int result = comparer.Compare(person1, person2);


            Assert.IsTrue(result < 0); // "Анна" должна быть перед "Иван"
        }

    }
}
