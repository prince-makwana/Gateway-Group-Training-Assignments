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
            var inputString = "Upper";
            var outputString = "upper";
            // Act
            var newString = inputString.ChangeCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
    }
}
