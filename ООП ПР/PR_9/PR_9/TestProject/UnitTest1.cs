using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_9;

namespace TestsProject
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Time_Constructor_PositiveMinutes()
        {
            // Arrange
            int minutes = 120;

            // Act
            Time time = new Time(minutes);

            // Assert
            Assert.AreEqual(2, time.GetHours());
            Assert.AreEqual(0, time.GetMinutes());
        }

        [TestMethod]
        public void Time_Constructor_NegativeMinutes()
        {
            // Arrange
            int minutes = -60;

            // Act
            Time time = new Time(minutes);

            // Assert
            Assert.AreEqual(0, time.GetHours());
            Assert.AreEqual(0, time.GetMinutes()); // Negative time should become 0:00
        }

        [TestMethod]
        public void Time_Constructor_HoursAndMinutes_Positive()
        {
            // Arrange
            int hours = 1;
            int minutes = 30;

            // Act
            Time time = new Time(hours, minutes);

            // Assert
            Assert.AreEqual(1, time.GetHours());
            Assert.AreEqual(30, time.GetMinutes());
        }

        public void Time_Constructor_Reference()
        {
            // Arrange
            int hours = 1;
            int minutes = 30;

            // Act
            Time time1 = new Time(hours, minutes);
            Time time2 = new Time(time1);

            // Assert
            Assert.AreEqual(time2.GetAllMinutes(), time1.GetAllMinutes());
        }


        [TestMethod]
        public void Time_GetAllMinutes_Positive()
        {
            // Arrange
            Time time = new Time(1, 30);

            // Act
            int totalMinutes = time.GetAllMinutes();

            // Assert
            Assert.AreEqual(90, totalMinutes);
        }




        [TestMethod]
        public void Time_IncrementOperator()
        {
            // Arrange
            Time time = new Time(1, 30);

            // Act
            time++;

            // Assert
            Assert.AreEqual(1, time.GetHours());
            Assert.AreEqual(31, time.GetMinutes());
        }

        [TestMethod]
        public void Time_DecrementOperator_Positive()
        {
            // Arrange
            Time time = new Time(1, 30);

            // Act
            time--;

            // Assert
            Assert.AreEqual(1, time.GetHours());
            Assert.AreEqual(29, time.GetMinutes());
        }

        // TODO: Test Decrement Operator when minutes goes below zero (should reduce hours)


        [TestMethod]
        public void Time_SubtractionOperator()
        {
            // Arrange
            Time time1 = new Time(2, 30);
            Time time2 = new Time(1, 15);

            // Act
            Time result = time1 - time2;

            // Assert
            Assert.AreEqual(1, result.GetHours());
            Assert.AreEqual(15, result.GetMinutes());
        }

        // TODO: Test Subtraction Operator when result is negative (should handle correctly)



        [TestMethod]
        public void Time_GreaterThanOperator()
        {
            // Arrange
            Time time1 = new Time(2, 30);
            Time time2 = new Time(1, 15);

            // Act
            bool result = time1 > time2;

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Time_LessThanOperator()
        {
            // Arrange
            Time time1 = new Time(1, 15);
            Time time2 = new Time(2, 30);

            // Act
            bool result = time1 < time2;

            // Assert
            Assert.IsTrue(result);
        }



        public void Time_ToString()
        {
            // Arrange: создаем Time
            Time time = new Time(1, 3);

            // Act: получаем строковое представление Time
            string timeArrayString = time.ToString();

            // Assert: проверяем, что строка содержит ожидаемые значения
            StringAssert.Contains(timeArrayString, "1:03");


        }




    }



    [TestClass]
    public class TimeArrayTests
    {
        [TestMethod]
        public void TimeArray_Constructor_WithArray()
        {
            // Arrange
            Time[] times = new Time[] { new Time(1, 100), new Time(2, -100) };

            // Act
            TimeArray timeArray = new TimeArray(times);

            // Assert
            Assert.AreEqual(2, timeArray.Count);
            Assert.AreEqual(times[0].GetAllMinutes(), timeArray[0].GetAllMinutes());
            Assert.AreEqual(times[1].GetAllMinutes(), timeArray[1].GetAllMinutes());
        }


        [TestMethod]
        public void TimeArray_Indexer_Get()
        {
            // Arrange
            Time[] times = new Time[] { new Time(1, 0), new Time(2, 0) };
            TimeArray timeArray = new TimeArray(times);

            // Act
            Time time = timeArray[0];

            // Assert
            Assert.AreEqual(times[0].GetAllMinutes(), time.GetAllMinutes());
        }


        [TestMethod]
        public void TimeArray_Indexer_Set()
        {
            TimeArray timeArray = new TimeArray(2);

            timeArray[1] = new Time(3, 0);
            Time time = new Time(3, 0);

            Assert.AreEqual(timeArray[1].GetAllMinutes(), time.GetAllMinutes());
        }
        // TODO: Test TimeArray Indexer Set


        [TestMethod]
        public void TimeArray_Constructor_MinMaxLen()
        {
            int min = 50;
            int max = 100;
            int len = 50;

            TimeArray timeArray = new TimeArray(min, max, len);

            for (int i = 0; i < len; i++)
            {
                Assert.IsTrue(timeArray[i].GetAllMinutes() <= max && timeArray[i].GetAllMinutes() >= min);
            }

        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TimeArray_Check_Exceptions()
        {
            // Arrange: создаем TimeArray с двумя значениями времени
            Time[] times = new Time[] { new Time(1, 3), new Time(2, 50) };
            TimeArray timeArray = new TimeArray(times);

            Time time = times[2];
        }



        [TestMethod]
        public void TimeArray_ToString()
        {
            // Arrange: создаем TimeArray с двумя значениями времени
            Time[] times = new Time[] { new Time(1, 3), new Time(2, 50) };
            TimeArray timeArray1 = new TimeArray(times);

            TimeArray timeArray2 = new TimeArray();

            // Act: получаем строковое представление TimeArray
            string timeArrayString1 = timeArray1.ToString();
            string timeArrayString2 = timeArray2.ToString();

            // Assert: проверяем, что строка содержит ожидаемые значения
            StringAssert.Contains(timeArrayString1, "1-е значение времени: 1:03");
            StringAssert.Contains(timeArrayString1, "2-е значение времени: 2:50");
            StringAssert.Contains(timeArrayString2, "");


        }
    }
}