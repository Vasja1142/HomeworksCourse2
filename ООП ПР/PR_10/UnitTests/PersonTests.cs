using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{

   
        [TestClass]
        public class PersonTests
        {
            [TestMethod]
            public void Person_Constructor_Default()
            {
                Person person = new Person();
                Assert.IsNotNull(person);
                Assert.IsNull(person.Name);
                Assert.AreEqual(0, person.Age);
                Assert.IsNotNull(person.Address); // Address should be initialized, not null
                Assert.IsNull(person.Address.City);
            }

            [TestMethod]
            public void Person_Constructor_Parameterized()
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
            public void Person_Show()
            {
                Person person = new Person("Иван", 30, "Москва");
                StringWriter sw = new StringWriter();
                Console.SetOut(sw);

                person.Show();

                string expected = $"Человек: Иван, Возраст: 30, Город: Москва{Environment.NewLine}";
                Assert.AreEqual(expected, sw.ToString());

                // Test with null Address.City
                person.Address.City = null;
                sw = new StringWriter();
                Console.SetOut(sw);
                person.Show();
                expected = $"Человек: Иван, Возраст: 30, Город: {Environment.NewLine}"; // Should print an empty City
                Assert.AreEqual(expected, sw.ToString());


            }

            [TestMethod]
            public void Person_Clone_DeepCopy()
            {
                Person person = new Person("Иван", 30, "Москва");
                Person clonedPerson = (Person)person.Clone();

                Assert.AreNotSame(person, clonedPerson); // Different objects
                Assert.AreEqual(person.Name, clonedPerson.Name);
                Assert.AreEqual(person.Age, clonedPerson.Age);

                Assert.AreNotSame(person.Address, clonedPerson.Address); // Deep copy - different Address objects
                Assert.AreEqual(person.Address.City, clonedPerson.Address.City);
            }



            [TestMethod]
            public void Person_Equals()
            {
                Person person1 = new Person("Иван", 30, "Москва");
                Person person2 = new Person("Иван", 30, "Москва");
                Person person3 = new Person("Петр", 25, "Москва");
                Person person4 = new Person("Иван", 30, "Санкт-Петербург");

                Assert.IsTrue(person1.Equals(person2));
                Assert.IsFalse(person1.Equals(person3));
                Assert.IsFalse(person1.Equals(person4));
                Assert.IsFalse(person1.Equals(null));
                Assert.IsFalse(person1.Equals("string")); // Different type
            }


            [TestMethod]
            public void Person_ShallowCopy()
            {
                Person person = new Person("Иван", 30, "Москва");
                Person shallowCopy = person.ShallowCopy();

                Assert.AreNotSame(person, shallowCopy); // Different objects

                // Shallow copy shares Address object
                Assert.AreSame(person.Address, shallowCopy.Address);

                Assert.AreEqual(person.Name, shallowCopy.Name);
                Assert.AreEqual(person.Age, shallowCopy.Age);
                Assert.AreEqual(person.Address.City, shallowCopy.Address.City); // Same City because of reference sharing
            }



            [TestMethod]
            public void PersonComparer_Compare()
            {
                Person person1 = new Person("Иван", 30, "Москва");
                Person person2 = new Person("Анна", 25, "Москва");
                Person person3 = new Person("Иван", 35, "Санкт-Петербург");

                PersonComparer comparer = new PersonComparer();

                Assert.IsTrue(comparer.Compare(person1, person2) > 0); // Иван > Анна
                Assert.IsTrue(comparer.Compare(person2, person1) < 0); // Анна < Иван
                Assert.IsTrue(comparer.Compare(person1, person3) == 0); // Иван == Иван (only names are compared)
            }

            // Тесты для Init() и RandomInit() требуют мокирования Console.ReadLine(), как описано ранее.
        }
    }

