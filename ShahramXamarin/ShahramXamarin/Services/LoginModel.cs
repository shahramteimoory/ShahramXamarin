using Newtonsoft.Json;
using ShahramXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShahramXamarin.Services
{
    public class LoginModel
    {
        private HttpClient _HttpClient;
        public LoginModel()
        {
            _HttpClient = new HttpClient();
            _HttpClient.BaseAddress = new Uri("https://localhost:44319/");
        }
        //public Task LoginAsync(User user)
        //{
        //    string jsonreq = JsonSerializer.Serialize(user);
        //    StringContent content = new StringContent(jsonreq, System.Text.Encoding.UTF8, "application/json");
        //    var res = _HttpClient.PostAsync("Auth/Login", content).Result;
        //}
    }
}
