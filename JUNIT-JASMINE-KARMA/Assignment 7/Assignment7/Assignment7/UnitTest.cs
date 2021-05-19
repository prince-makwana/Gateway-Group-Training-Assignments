using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Assignment7
{
    public class Tests
    {
        private TestFunctions _testFunctions;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _testFunctions = new TestFunctions();
        }

        /// <summary>
        /// Positive Test Case for Sum Of First N Numbers
        /// </summary>
        [Test]
        public void SumOfFirstNNumbers_Test_Positive()
        {
            // Act
            int result = _testFunctions.SumOfFirstNNumbers(20);

            // Assert
            Assert.AreEqual(210, result);
        }

        /// <summary>
        /// Negative Test Case for Sum Of First N Numbers
        /// </summary>
        [Test]
        public void SumOfFirstNNumber_Test_Negative()
        {
            // Act
            int result = _testFunctions.SumOfFirstNNumbers(20);

            // Assert
            Assert.AreNotEqual(420, result);
        }

        /// <summary>
        /// Day Selection Switch Case Example
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="day"></param>
        [TestCase(1, "Monday")]
        [TestCase(2, "Tuesday")]
        [TestCase(3, "Wednesday")]
        [TestCase(10, "Invalid Day")]
        public void DaySelection_Test(int choice, string day)
        {
            //Act
            string result = _testFunctions.DaySelection(choice);

            //Assert
            Assert.AreEqual(day, result);
        }

        /// <summary>
        /// SmallNumber If Else Example
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="small"></param>
        [TestCase(1, 2, 1)]
        [TestCase(-1, 2, -1)]
        public void SmallNumber_Test(int a, int b, int small)
        {
            //Act
            int result = _testFunctions.SmallNumber(a, b);

            //Assert
            Assert.AreEqual(small, result);
        }

        /// <summary>
        /// SizeOfList Positive Test Case
        /// </summary>
        [Test]
        public void SizeOfList_Test_Positive()
        {
            // Act
            int result = _testFunctions.SizeOfList();

            // Assert
            Assert.AreEqual(7, result);
        }

        /// <summary>
        /// SizeOfList Negative Test Case
        /// </summary>
        [Test]
        public void SizeOfList_Test_Negative()
        {
            // Act
            int result = _testFunctions.SizeOfList();

            // Assert
            Assert.AreNotEqual(30, result);
        }

        /// <summary>
        /// Consonant Count example For loop
        /// </summary>
        /// <param name="name"></param>
        /// <param name="consonantCount"></param>
        [TestCase("Prince Makwana", 9)]
        [TestCase("Dhruvin", 5)]
        public void CountConsonants_Test(string name, int consonantCount)
        {
            //Act
            int result = _testFunctions.CountConsonants(name);

            //Assert
            Assert.AreEqual(consonantCount, result);
        }

        /// <summary>
        /// Null Reference Exception
        /// </summary>
        [Test]
        public void NullReferenceException_Test()
        {
            //Act
            var exceptionResult = Assert.Throws<NullReferenceException>(() => _testFunctions.NullReferenceException(null));

            //Assert
            Assert.AreEqual("Null Reference Exception", exceptionResult.Message);
        }

        /// <summary>
        /// Divide By Zero Exception
        /// </summary>
        [Test]
        public void DivideByZero_Test()
        {
            //Act
            var exceptionResult = Assert.Throws<DivideByZeroException>(() => _testFunctions.DivideByZero(12, 0));

            //Assert
            Assert.AreEqual("Divide By Zero Exception", exceptionResult.Message);
        }


        /// <summary>
        /// Array Index Out Of Bound Exception
        /// </summary>
        [Test]
        public void ArrayIndexOutOfBound_Test()
        {
            //Act
            var exceptionResult = Assert.Throws<IndexOutOfRangeException>(() => _testFunctions.ArrayIndexOutOfBound());

            //Assert
            Assert.AreEqual("Array Index out of Bound", exceptionResult.Message);
        }

        /// <summary>
        /// PassMessage Async Example Positive Test Case
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PassMessageAsync_Test_Positive()
        {
            var result = await _testFunctions.PassMessage("Hello World");
            Assert.IsNotEmpty(result);
        }

        /// <summary>
        /// PassMessage Async Example Positive Test Case
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PassMessageAsync_Test_Negative()
        {
            var result = await _testFunctions.PassMessage(null);
            Assert.IsNull(result);
        }
    }
}