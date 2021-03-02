using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Assignment2.ConsoleApp.ExtensionClasses;

namespace Assignment2.Tests
{
    public class StringOperationTest
    {
        [Fact]
        public void Test_ChangeCase()
        {
            // Arrange
            var inputString = "Prince";
            var outputString = "prince";
            // Act
            var newString = inputString.ChangeCase();
            // Assert
            Assert.Equal(newString, outputString);
        }

        [Fact]
        public void Test_ChangeToTitleCase()
        {
            // Arrange
            var inputString = "Gateway GROup oF CompaniEs";
            var outputString = "Gateway Group Of Companies";
            // Act
            var newString = inputString.ChangeToTitleCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_IsLowerCaseString()
        {
            // Arrange
            var inputString = "prince";
            // Act
            var newString = inputString.IsLowerCaseString();
            // Assert
            Assert.True(newString);
        }
        [Fact]
        public void Test_IsUpperCaseString()
        {
            // Arrange
            var inputString = "PRINCE";
            // Act
            var newString = inputString.IsUpperCaseString();
            // Assert
            Assert.True(newString);
        }
        [Fact]
        public void Test_DoCapitalize()
        {
            // Arrange
            var inputString = "prince";
            var outputString = "Prince";
            // Act
            var newString = inputString.DoCapitalize();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Theory]
        [InlineData("123", true)]
        [InlineData("123c", false)]
        public void Test_IsValidNumericValue(string inputString, bool result)
        {
            // Arrange

            // Act
            var newString = inputString.IsValidNumericValue();
            // Assert
            Assert.Equal(newString, result);
        }
        [Fact]
        public void Test_RemoveLastCharacter()
        {
            // Arrange
            var inputString = "Prince Makwana";
            var outputString = "Prince Makwan";
            // Act
            var newString = inputString.RemoveLastCharacter();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_WordCount()
        {
            // Arrange
            var inputString = "Prince Makwana";
            var count = 2;
            // Act
            var newString = inputString.WordCount();
            // Assert
            Assert.Equal(newString, count);
        }
        [Fact]
        public void Test_StringToInteger()
        {
            // Arrange
            var inputString = "123";
            var output = 123;
            // Act
            var newString = inputString.StringToInteger();
            // Assert
            Assert.Equal(newString, output);
        }
    }
}
