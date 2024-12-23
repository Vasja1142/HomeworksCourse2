using System;
using System.Collections.Generic;
using System.Linq;
using PR_10.Library.Goods;
using System.Text;
using System.Threading.Tasks;

namespace PR_10_Tests
{
    [TestClass]
    public class ToyTests
    {
        [TestMethod]
        // Проверка создания игрушки с корректными данными
        public void Toy_Constructor_ValidData_CreatesToy()
        {
            string name = "Машинка";
            double price = 250.00;
            string material = "Пластик";
            Toy toy = new Toy(name, price, material);

            Assert.AreEqual(name, toy.Name);
            Assert.AreEqual(price, toy.Price);
            Assert.AreEqual(material, toy.Material);
        }

        [TestMethod]
        // Проверка создания игрушки с пустым материалом
        public void Toy_Constructor_EmptyMaterial_SetsDefaultMaterial()
        {
            string name = "Кукла";
            double price = 500;
            string material = "";
            Toy toy = new Toy(name, price, material);

            Assert.AreEqual(name, toy.Name);
            Assert.AreEqual(price, toy.Price);
            Assert.AreEqual("Неизвестный материал", toy.Material); // Материал должен быть установлен в значение по умолчанию
        }



        [TestMethod]
        // Проверка сеттера материала с непустым значением
        public void Toy_SetMaterial_NonEmptyValue_SetsMaterialCorrectly()
        {
            Toy toy = new Toy();
            string material = "Дерево";

            toy.Material = material;
            Assert.AreEqual(material, toy.Material);
        }


        [TestMethod]
        // Проверка сеттера материала с пустым значением
        public void Toy_SetMaterial_EmptyValue_SetsDefaultMaterial()
        {
            Toy toy = new Toy();
            string material = "";

            toy.Material = material;
            Assert.AreEqual("Неизвестный материал", toy.Material);
        }

        [TestMethod]
        // Проверка метода Show
        public void Toy_Show_DisplaysCorrectInformation()
        {
            string name = "Конструктор";
            double price = 1500;
            string material = "Пластик";
            Toy toy = new Toy(name, price, material);


            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                toy.Show();
                string expected = $"Игрушка: {name}, Цена: {price:0.00} руб., Материал: {material}\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }

        }


        [TestMethod]
        // Проверка метода Display
        public void Toy_Display_DisplaysCorrectInformation()
        {
            string name = "Конструктор";
            double price = 1500;
            string material = "Пластик";
            Toy toy = new Toy(name, price, material);


            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                toy.Display();
                string expected = $"Игрушка: {name}, Цена: {price:0.00} руб., Материал: {material}\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }

        }

        [TestMethod]
        public void Toy_Init_SetsPropertiesFromInput()
        {
            string input = "TestToy\n50,00\nPlastic";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var toy = new Toy();
                toy.Init();
                Assert.AreEqual("TestToy", toy.Name);
                Assert.AreEqual(50.00, toy.Price);
                Assert.AreEqual("Plastic", toy.Material);
            }
        }

        [TestMethod]
        // Проверка метода RandomInit
        public void Toy_RandomInit_GeneratesRandomValues()
        {
            Toy toy = new Toy();
            toy.RandomInit();

            string[] materials = { "Пластик", "Дерево", "Металл", "Ткань" };
            string[] toyNames = { "Кукла", "Машинка", "Конструктор", "Мяч", "Пазл" };

            Assert.IsTrue(toyNames.Contains(toy.Name));
            Assert.IsTrue(materials.Contains(toy.Material));
            Assert.IsTrue(toy.Price >= 0);


        }
    }
}
