using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DwollaExercise.Test
{
    [TestFixture]
    public class InputTest
    {
        [Test]
        public void Input_EnterRealCity_ReturnTemperature()
        {
            //Arrange
            string strRealCity = "Kuantan";
            bool expected = true;
            bool actual;
            API apiTest = new API(strRealCity);

            //Act - Retrieve data from API
            Task<string> callTask = Task.Run(() => apiTest.CallWebAPI());
            callTask.Wait();
            actual = callTask.Result.Contains("The temperature in ");

            //Assert - Checks if the actual result is as expected
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Input_EnterFakeCity_ReturnInvalid()
        {
            string strFakeCity = "Fake Lake Citadel";
            string expected = "Invalid city name. \n";
            string actual;
            API apiTest = new API(strFakeCity);

            Task<string> callTask = Task.Run(() => apiTest.CallWebAPI());
            callTask.Wait();
            actual = callTask.Result;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Input_EnterNumbers_ReturnInvalid()
        {
            string strNumbers = "289243";
            string expected = "Invalid city name. \n";
            string actual;
            API apiTest = new API(strNumbers);

            Task<string> callTask = Task.Run(() => apiTest.CallWebAPI());
            callTask.Wait();
            actual = callTask.Result;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Input_EnterEmpty_ReturnInvalid()
        {
            string strEmpty = "";
            string expected = "Invalid city name. \n";
            string actual;
            API apiTest = new API(strEmpty);

            Task<string> callTask = Task.Run(() => apiTest.CallWebAPI());
            callTask.Wait();
            actual = callTask.Result;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Input_EnterNull_ReturnInvalid()
        {
            string expected = "Invalid city name. \n";
            string actual;
            API apiTest = new API(null);

            Task<string> callTask = Task.Run(() => apiTest.CallWebAPI());
            callTask.Wait();
            actual = callTask.Result;

            Assert.AreEqual(actual, expected);
        }
    }
}
