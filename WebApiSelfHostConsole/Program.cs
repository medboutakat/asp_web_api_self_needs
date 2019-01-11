using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace WebApiSelfHostConsole
{


    public class Program
    {
        static void Main()
        {


            Console.WriteLine("Hello user: please enter tenant name or enter for default name ");
            string name=Console.ReadLine();
            Console.Title = "hELLO : " + name;

            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}