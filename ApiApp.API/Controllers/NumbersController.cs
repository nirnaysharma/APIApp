using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.API.Controllers
{
    [ApiController]
    public class NumbersController : ControllerBase
    {

        public NumbersController()
        {

        }

        //Endpoint 1
        /// <summary>
        /// The API method used to sum the comma seperated integers and check if it is prime number or not
        /// </summary>
        /// <param name="numbers">The comma seperated intefers</param>
        /// <returns>json object as string</returns>
        [HttpGet("/api/v1/multiple_number_prime")]
        public string IntegersPrimeOrNot(string numbers)
        {
            if (!string.IsNullOrEmpty(numbers))
            {
                int testVar;  // Ignored, just required for TryParse()
                bool isListOfInts = numbers.Split(',').All(s => int.TryParse(s, out testVar));
                if (isListOfInts)
                {
                    List<int> numbersList = numbers.Split(',').Select(int.Parse).ToList();
                    int sum = numbersList.Sum(x => Convert.ToInt32(x));
                    bool isPrime = chkIfPrime(sum);
                    string jsonObj = JsonConvert.SerializeObject(new Result { Sum = sum, IsPrime = isPrime });
                    return jsonObj;
                }
                else return "Input can only contain strings.";
            }
            return "";
        }

        //Endoint 2
        /// <summary>
        /// The API method which takes an integer as input, and returns information whether the sum is a prime number or not.
        /// </summary>
        /// <param name="number">The integer</param>
        /// <returns>json object as string</returns>
        [HttpGet("api/v1/single_number_prime")]
        public string SingleIntegerPrimeOrNot(int number)
        {
            if (number != 0)
            {
                int sum = 0;
                while (number != 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                bool isPrime = chkIfPrime(sum);
                string jsonObj = JsonConvert.SerializeObject(new Result { IsPrime = isPrime });
                return jsonObj;
            }
            return "";
        }

        /// <summary>
        /// The method checks if the number is prime or not.
        /// </summary>
        /// <param name="num">The number to check</param>
        /// <returns></returns>
        public static bool chkIfPrime(int num)
        {
            if (num < 2) return false; // A prime number is always greater than 1
            if (num == 2) return true; // 2 is prime
            if (num % 2 == 0) return false; // Even numbers except 2 are not prime

            /****** if your number is Odd and not equals to 2, 
               you have to check every numbers between 3 and the square of your number  *******/
            var boundary = (int)Math.Floor(Math.Sqrt(num)); // square of your number

            //increment i by 2 because you already checked that your number is Odd and therefore not divisible by an Even number
            for (int i = 3; i <= boundary; i += 2)
            {
                if (num % i == 0) return false; // the number can be divided by an other => COMPOSITE number
            }
            return true; // number at least equals to 3, divisible only by one or itself => PRIME number
        }
    }

    /// <summary>
    /// Result class to parse the result into object.
    /// </summary>
    public class Result
    {
        public int Sum { get; set; }

        public bool IsPrime { get; set; }
    }
}
