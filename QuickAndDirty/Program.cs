using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace QuickAndDirty
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();



        }

        static void printGUID(string guid)
        {
            Console.WriteLine(guid);
            
        }

        static async Task<string> GetProductAsync(string path)
        {
            string product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }
            return product;
        }


        static async Task<string> GetAllData(VehicleQueryComplete Query, string URL)
        {
            string product = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(URL, Query);
            
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }
            return product;
        }
        

        static async Task<string> GetByPost(VehicleQuery Query, string URL)
        {
            string product = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(URL, Query);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }
            return product;
        }


        static async Task RunAsync()
        {
           
            client.BaseAddress = new Uri("https://api.lotlocate.com/REST");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                VehicleQuery test = new VehicleQuery (1, "1", 20, "REDACTED", "REDACTED");
                VehicleQueryComplete test2 = new VehicleQueryComplete(1, "7123", "REDACTED", "REDACTED");
                string url = "https://api.lotlocate.com/REST/api/QueryLocationDatabase";
                string guid = await GetByPost(test, url);
                printGUID(guid);
                url = "https://api.lotlocate.com/REST/api/GetAllDataRegarding";
                string result = await GetAllData(test2, url);
                printGUID(result);



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.ReadLine();
        }
    }
}
