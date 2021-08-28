using APIApp.FrontEnd.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIApp.FrontEnd.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        //Method 1
        /// <summary>
        /// POST method that takes multiple integers as input, calculates the sum, and returns the sum including information whether the sum is a prime number or not.
        /// </summary>
        /// <param name="multipleNumber">Comma seperated integers as string</param>
        /// <returns>data received from API</returns>
        [HttpPost]
        public string MultipleNumberIsPrime(string multipleNumber)
        {
            string numbers = multipleNumber.TrimStart(',').TrimEnd(',');
            Uri domain = new Uri(Request.GetDisplayUrl());
            string topLevelUrl = string.Format(domain.Scheme + "://" + domain.Authority);
            string apiUrl = topLevelUrl + "/api/v1/multiple_number_prime?numbers=" + numbers;
            var client = new RestClient(apiUrl);
            try
            {
                //API call to the API method named IntegersPrimeOrNot
                var response = client.Execute<string>(new RestRequest());
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Data;
                }
            }
           catch(Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }

        //Method 1
        /// <summary>
        /// POST method that takes one integer as input, and returns information whether the sum is a prime number or not
        /// </summary>
        /// <param name="singleNumber">The single integer</param>
        /// <returns>data received from API</returns>
        [HttpPost]
        public string SingleNumberIsPrime(string singleNumber)
        {
            Uri domain = new Uri(Request.GetDisplayUrl());
            string topLevelUrl = string.Format(domain.Scheme + "://" + domain.Authority);
            string apiUrl = topLevelUrl + "/api/v1/single_number_prime?number=" + singleNumber;
            var client = new RestClient(apiUrl);
            try
            {
                //API call to the API method named SingleIntegerPrimeOrNot
                var response = client.Execute<string>(new RestRequest());
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }

        /// <summary>
        /// Combined method which checks both Method 1 and 2 in a single method. Input either a single integer or comma seperated integer and it checks if the sum is prime or not.
        /// </summary>
        /// <param name="numbers">Sigle integer or comma seperated integers</param>
        /// <returns>data received from API</returns>
        [HttpPost]
        public string CombinedMethod(string numbers)
        {
            numbers = numbers.TrimStart(',').TrimEnd(',');
            Uri domain = new Uri(Request.GetDisplayUrl());
            string topLevelUrl = string.Format(domain.Scheme + "://" + domain.Authority);
            string apiUrl = "";
            if (numbers.Contains(","))
                apiUrl = topLevelUrl + "/api/v1/multiple_number_prime?numbers=" + numbers;
            else
                apiUrl = topLevelUrl + "/api/v1/single_number_prime?number=" + numbers;

            var client = new RestClient(apiUrl);
            try
            {
                var response = client.Execute<string>(new RestRequest());
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }

    }


}
