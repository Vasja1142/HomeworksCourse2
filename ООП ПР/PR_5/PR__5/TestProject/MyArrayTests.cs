using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR__5;
using System;
using System.IO;


namespace PR_5.Tests
{
    [TestClass]
    public class MyArrayTests
    {
        [TestMethod]
        public void CreateConsole_Test()
        {
            // Ïîäãîòàâëèâàåì âõîäíûå äàííûå äëÿ èìèòàöèè ââîäà ïîëüçîâàòåëÿ
            string input = "3\n1\n2\n3"; // Äëèíà ìàññèâà 3, ıëåìåíòû 1, 2, 3
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            int[] arr = MyArray.CreateConsole();

            // Ïğîâåğÿåì, ÷òî äëèíà ìàññèâà ñîîòâåòñòâóåò îæèäàåìîé
            Assert.AreEqual(3, arr.Length);
            // Ïğîâåğÿåì çíà÷åíèÿ ıëåìåíòîâ ìàññèâà
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
        }

        [TestMethod]
        public void CreateRandom_Test()
        {
            // Ïîäãîòàâëèâàåì âõîäíûå äàííûå äëÿ èìèòàöèè ââîäà ïîëüçîâàòåëÿ
            string input = "5\n1\n10"; // Äëèíà ìàññèâà 5, ìèíèìàëüíîå çíà÷åíèå 1, ìàêñèìàëüíîå 10
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            int[] arr = MyArray.CreateRandom();

            // Ïğîâåğÿåì äëèíó ìàññèâà
            Assert.AreEqual(5, arr.Length);
            // Ïğîâåğÿåì, ÷òî âñå ıëåìåíòû íàõîäÿòñÿ â çàäàííîì äèàïàçîíå
            foreach (int num in arr)
            {
                Assert.IsTrue(num >= 1 && num <= 10);
            }
        }

        [TestMethod]
        public void DeleteEvenNumbers_Test()
        {
            // Ñîçäàåì òåñòîâûé ìàññèâ
            int[] arr = { 1, 2, 3, 4, 5 };
            // Îæèäàåìûé ğåçóëüòàò ïîñëå óäàëåíèÿ ÷åòíûõ ıëåìåíòîâ
            int[] expected = { 2, 4 };

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            int[] result = MyArray.DeleteEvenNumbers(arr);

            // Ñğàâíèâàåì ïîëó÷åííûé ğåçóëüòàò ñ îæèäàåìûì
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteEvenNumbers_EmptyArray_Test()
        {
            // Òåñò äëÿ ïóñòîãî ìàññèâà
            int[] arr = { };

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            int[] result = MyArray.DeleteEvenNumbers(arr);

            // Ïğîâåğÿåì, ÷òî ğåçóëüòèğóşùèé ìàññèâ ïóñòîé
            Assert.AreEqual(0, result.Length);
        }


        [TestMethod]
        public void ConsoleTryParse_ValidInput_Test()
        {
            // Òåñò äëÿ êîğğåêòíîãî ââîäà
            string input = "123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            int result = MyArray.ConsoleTryParse("Ââåäèòå ÷èñëî:");

            // Ïğîâåğÿåì, ÷òî ğåçóëüòàò ñîîòâåòñòâóåò ââåäåííîìó ÷èñëó
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void ConsoleTryParse_InvalidInput_Test()
        {
            // Òåñò äëÿ íåêîğğåêòíîãî ââîäà, çàòåì êîğğåêòíîãî
            string input = "abc\n123";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            int result = MyArray.ConsoleTryParse("Ââåäèòå ÷èñëî:");

            // Ïğîâåğÿåì, ÷òî ìåòîä âåğíóë êîğğåêòíîå çíà÷åíèå ïîñëå íåêîğğåêòíîãî ââîäà
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void Print_Test()
        {
            // Òåñòîâûé ìàññèâ
            int[] arr = { 1, 2, 3 };

            // Ïåğåõâàòûâàåì âûâîä êîíñîëè
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            MyArray.Print(arr);

            // Îæèäàåìûé âûâîä
            string expectedOutput = "Ìàññèâ: {1, 2, 3}\r\n";
            // Ñğàâíèâàåì ôàêòè÷åñêèé âûâîä ñ îæèäàåìûì
            Assert.AreEqual(expectedOutput, writer.ToString());
        }


        [TestMethod]
        public void CreateConsole_NegativeLength_Test()
        {
            // Òåñò äëÿ ñëó÷àÿ, êîãäà ïîëüçîâàòåëü ââîäèò îòğèöàòåëüíóş äëèíó ìàññèâà
            string input = "-1\n3\n1\n2\n3";
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            // Âûçûâàåì òåñòèğóåìûé ìåòîä
            int[] arr = MyArray.CreateConsole();

            // Ïğîâåğÿåì, ÷òî ìàññèâ ñîçäàëñÿ ñ êîğğåêòíîé äëèíîé ïîñëå îøèáêè
            Assert.AreEqual(3, arr.Length);
            // Ïğîâåğÿåì çíà÷åíèÿ ıëåìåíòîâ
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
        }

        
    }
}