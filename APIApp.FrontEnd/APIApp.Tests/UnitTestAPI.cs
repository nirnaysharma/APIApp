using System;
using System.Collections.Generic;
using System.Text;
using ApiApp.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace APIApp.Tests
{
    [TestClass]
    public class UnitTestAPI
    {
        /// <summary>
        /// Checks if the Integer is prime or not.  Should return false.
        /// </summary>
        [TestMethod]
        public void TestNumberIsPrimeOrNotFalse()
        {
            var controller = new NumbersController();
            var result = controller.SingleIntegerPrimeOrNot(22);
            var returnObj = JsonConvert.DeserializeObject<Result>(result);
            Assert.AreEqual(returnObj.IsPrime, false);
        }

        /// <summary>
        /// Checks if the Integer is prime or not. Should return true.
        /// </summary>
        [TestMethod]
        public void TestNumberIsPrimeOrNotTrue()
        {
            var controller = new NumbersController();
            var result = controller.SingleIntegerPrimeOrNot(11);
            var returnObj = JsonConvert.DeserializeObject<Result>(result);
            Assert.AreEqual(returnObj.IsPrime, true);
        }

        /// <summary>
        /// Checks if the sum of integers is prime or not. Should return false and 66 as sum
        /// </summary>
        [TestMethod]
        public void IntegersPrimeOrNotFalse()
        {
            var controller = new NumbersController();
            var result = controller.IntegersPrimeOrNot("11, 22, 33");
            var returnObj = JsonConvert.DeserializeObject<Result>(result);
            Assert.AreEqual(returnObj.IsPrime, false);
            Assert.AreEqual(returnObj.Sum, 66);
        }

        /// <summary>
        /// Checks if the sum of integers is prime or not. Should return true and 89 as sum
        /// </summary>
        [TestMethod]
        public void IntegersPrimeOrNotTrue()
        {
            var controller = new NumbersController();
            var result = controller.IntegersPrimeOrNot("11, 22, 56");
            var returnObj = JsonConvert.DeserializeObject<Result>(result);
            Assert.AreEqual(returnObj.IsPrime, true);
            Assert.AreEqual(returnObj.Sum, 89);
        }

        /// <summary>
        /// Checks if the sum of integers is prime or not. Should return true and 89 as sum. It should also remove the last comma and not crash.
        /// </summary>
        [TestMethod]
        public void IntegersPrimeOrNotExtraTrailingComma()
        {
            var controller = new NumbersController();
            var result = controller.IntegersPrimeOrNot("11, 22, 56,");
            var returnObj = JsonConvert.DeserializeObject<Result>(result);
            Assert.AreEqual(returnObj.IsPrime, true);
            Assert.AreEqual(returnObj.Sum, 89);
        }

        /// <summary>
        /// Checks if the sum of integers is prime or not. Should return true and 89 as sum. It should also remove the first comma and not crash.
        /// </summary>
        [TestMethod]
        public void IntegersPrimeOrNotExtraStartingComma()
        {
            var controller = new NumbersController();
            var result = controller.IntegersPrimeOrNot(",11, 22, 56");
            var returnObj = JsonConvert.DeserializeObject<Result>(result);
            Assert.AreEqual(returnObj.IsPrime, true);
            Assert.AreEqual(returnObj.Sum, 89);
        }

        /// <summary>
        /// Checks if the sum of integers is prime or not. Should return true and 89 as sum. It should also remove the first and last comma and not crash.
        /// </summary>
        [TestMethod]
        public void IntegersPrimeOrNotExtraStartingAndTrailingComma()
        {
            var controller = new NumbersController();
            var result = controller.IntegersPrimeOrNot(",11, 22, 56,");
            var returnObj = JsonConvert.DeserializeObject<Result>(result);
            Assert.AreEqual(returnObj.IsPrime, true);
            Assert.AreEqual(returnObj.Sum, 89);
        }
       
    }

  
}
