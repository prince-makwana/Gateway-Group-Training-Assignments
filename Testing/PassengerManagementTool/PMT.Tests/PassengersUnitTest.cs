using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PMT.BAL.Interface;
using PMT.Models;
using PMT.WebApi.Controllers;
using Xunit;

namespace PMT.Tests
{
    public class PassengersUnitTest
    {
        private readonly Mock<IPassengerManager> _mockPassengerManager = new Mock<IPassengerManager>();
        private readonly PassengerController _passengerController;

        public PassengersUnitTest()
        {
            _passengerController = new PassengerController(_mockPassengerManager.Object);
        }

        //Add New Passenger
        [Fact]
        public void AddPassengerTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 3;
            passenger.FName = "Prince";
            passenger.LName = "Makwana";
            passenger.MobileNo = "9624614874";
            var res = _mockPassengerManager.Setup(x => x.AddPassengers(passenger)).Returns("Passenger Added Success1fully!");

            //Act
            var result = _passengerController.PostPassenger(passenger);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddPassengerTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            var res = _mockPassengerManager.Setup(x => x.AddPassengers(passenger)).Returns("Model is found null");

            //Act
            var result = _passengerController.PostPassenger(passenger);

            //Assert
            Assert.NotNull(result);
        }


        //Get List of all Passengers
        [Fact]
        public void GetAllPPassengersTestPass()
        {
            //Arrange
            var result = _mockPassengerManager.Setup(x => x.GetPassengers()).Returns(GetPassenger());

            //Act
            var actualResult = _passengerController.GetPassengers();

            //Assert
            Assert.Equal(2, actualResult.Count);
        }

        [Fact]
        public void GetAllPPassengersTestFail()
        {
            //Arrange
            var result = _mockPassengerManager.Setup(x => x.GetPassengers()).Returns(GetPassenger());

            //Act
            var actualResult = _passengerController.GetPassengers();

            //Assert
            Assert.NotEqual(4, actualResult.Count);
        }

        //Get User By Id
        [Fact]
        public void GetPassengerByIdTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 1;
            passenger.FName = "Prince";
            passenger.LName = "Makwana";
            passenger.MobileNo = "9624614874";
            var res = _mockPassengerManager.Setup(x => x.GetPassenger(passenger.ID)).Returns(passenger);

            //Act
            var result = _passengerController.GetPassenger(passenger.ID);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPassengerByIdTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            var res = _mockPassengerManager.Setup(x => x.GetPassenger(3)).Returns(passenger);

            //Act
            var result = _passengerController.GetPassenger(passenger.ID);

            //Assert
            Assert.Null(result);
        }

        //Update any existing Passenger
        [Fact]
        public void UpdatePassengerTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 1;
            passenger.FName = "iPrince";
            passenger.LName = "Makwana";
            passenger.MobileNo = "9426836645";
            var res = _mockPassengerManager.Setup(x => x.UpdatePassengers(1, passenger)).Returns("Passenger Updated Successfully!");

            //Act
            var result = _passengerController.UpdatePassenger(1, passenger);

            //Assert
            Assert.Equal("Passenger Updated Successfully!", result);
        }

        [Fact]
        public void UpdatePassengerTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            var res = _mockPassengerManager.Setup(x => x.UpdatePassengers(4, passenger)).Returns("Model is Found Null!");

            //Act
            var result = _passengerController.UpdatePassenger(4, passenger);

            //Assert
            Assert.NotEqual("Passenger Updated Successfully!", result);
        }

        //Delete any particular existing Passenger.
        [Fact]
        public void DeletePassengerTestPass()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 2;
            var res = _mockPassengerManager.Setup(x => x.DeletePassenger(passenger.ID)).Returns(true);

            //Act
            var result = _passengerController.DeletePassenger(passenger.ID);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeletePassengerTestFail()
        {
            //Arrange
            var passenger = new PassengerViewModel();
            passenger.ID = 4;
            var res = _mockPassengerManager.Setup(x => x.DeletePassenger(passenger.ID)).Returns(false);

            //Act
            var result = _passengerController.DeletePassenger(passenger.ID);

            //Assert
            Assert.False(result);
        }



        //Static List of Passengers
        private static List<PassengerViewModel> GetPassenger()
        {
            List<PassengerViewModel> users = new List<PassengerViewModel>()
            {
                new PassengerViewModel() {ID=1, FName="Prince", LName="Makwana", MobileNo="9624614874"},
                new PassengerViewModel() {ID=2, FName="Kushal", LName="Master", MobileNo="9999988888"},

            };
            return users;
        }

    }
}
