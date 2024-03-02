using Newtonsoft.Json;
using ShahramXamarin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ShahramXamarin.Services
{
    public class Customers
    {
        private HttpClient _HttpClient;
        private const string Customer_File = "CustomersFile.json";

        public static List<Customer> CustomerFile { get; set; }
        public Customers()
        {
            _HttpClient = new HttpClient();
            _HttpClient.BaseAddress = new Uri("https://localhost:44319/");
            CustomerFile = new List<Customer>();
        }
        public async Task<List<Customer>> GetAll()
        {
            var customerraw = await _HttpClient.GetStringAsync("Customer/");
            var serilizer = new JsonSerializer();
            using (var treader=new StringReader(customerraw))
            {
                using (var JReader = new JsonTextReader(treader))
                {
                    var Customers = serilizer.Deserialize<List<Customer>>(JReader);
                    return Customers;
                }
            }
        }
        public void SaveCustomer()
        {
            if (CustomerFile!=null)
            {
                var path = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), Customer_File);;
                using (var swriter=new StreamWriter(path))
                {
                    using (var jwriter=new JsonTextWriter(swriter))
                    {
                        JsonSerializer.CreateDefault().Serialize(jwriter, CustomerFile);
                    }
                }
            }
        }

        public void LoadCustomers()
        {
            var path = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), Customer_File); ;
            if (File.Exists(path))
            {
                using (var reader=new StreamReader(path))
                {
                    using (var json=new JsonTextReader(reader))
                    {
                        try
                        {
                            CustomerFile = JsonSerializer.CreateDefault().Deserialize<List<Customer>>(json);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                       
                    }
                }
            }
        }
    }
}
