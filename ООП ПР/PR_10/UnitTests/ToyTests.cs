using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_10.Library.Goods;
using System;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class ToyTests
    {
        [TestMethod]
        public void Toy_Constructor_Default()
        {
            Toy toy = new Toy();
            Assert.IsNull(toy.Name);
            Assert.AreEqual(0, toy.Price);
            Assert.AreEqual("Неизвестный материал", toy.Material); // Default material should be set
        }


        [TestMethod]
        public void Toy_Constructor_Parameterized()
        {
            string name = "Мишка";
            double price = 100;
            string material = "Плюш";

            Toy toy = new Toy(name, price, material);

            Assert.AreEqual(name, toy.Name);
            Assert.AreEqual(price, toy.Price);
            Assert.AreEqual(material, toy.Material);
        }

        [TestMethod]
        public void Toy_Material_Setter_Empty()
        {
            Toy toy = new Toy();
            toy.Material = "";
            Assert.AreEqual("Неизвестный материал", toy.Material);

            toy.Material = null;
            Assert.AreEqual("Неизвестный материал", toy.Material);
        }

        [TestMethod]
        public void Toy_Show()
        {
            Toy toy = new Toy("Машинка", 500, "Пластик");
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            toy.Show();

            string expected = $"Игрушка: Машинка, Цена: 500.00 руб., Материал: Пластик{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
        }


        [TestMethod]
        public void Toy_Display()
        {
            Toy toy = new Toy("Кукла", 300, "Ткань");
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            toy.Display(); // Используем Display()

            string expected = $"Игрушка: Кукла, Цена: 300.00 руб., Материал: Ткань{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
        }


        [TestMethod]
        public void Toy_Init()
        {
            string input = "Конструктор\n2000\nДерево";
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                Toy toy = new Toy();
                toy.Init();
                Assert.AreEqual("Конструктор", toy.Name);
                Assert.AreEqual(2000, toy.Price);
                Assert.AreEqual("Дерево", toy.Material);
            }


            // Test with empty material input
            input = "Мяч\n100\n"; // Empty material
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                Toy toy = new Toy();
                toy.Init();
                Assert.AreEqual("Мяч", toy.Name);
                Assert.AreEqual(100, toy.Price);
                Assert.AreEqual("Неизвестный материал", toy.Material); // Should default to "Неизвестный материал"

            }
        }




        [TestMethod]
        public void Toy_RandomInit()
        {

            Toy toy = new Toy();
            toy.RandomInit();

            // Check if properties are within expected ranges/sets
            string[] materials = { "Пластик", "Дерево", "Металл", "Ткань" };
            Assert.IsTrue(materials.Contains(toy.Material));

            string[] toyNames = { "Кукла", "Машинка", "Конструктор", "Мяч", "Пазл" };
            Assert.IsTrue(toyNames.Contains(toy.Name));

            Assert.IsTrue(toy.Price >= 10 && toy.Price <= 1000); // Assuming base.RandomInit sets price between 10 and 1000. Adjust as needed.


        }
    }
}