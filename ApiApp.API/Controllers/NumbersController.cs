using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
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
                List<int> numbersList = numbers.Split(',').Select(int.Parse).ToList();
                int sum = numbersList.Sum(x => Convert.ToInt32(x));
                bool isPrime = chkIfPrime(sum);
                string jsonObj = JsonConvert.SerializeObject(new Result { Sum = sum, IsPrime = isPrime });
                return jsonObj;
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
           if(number != 0)
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
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
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
