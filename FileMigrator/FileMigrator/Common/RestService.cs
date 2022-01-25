using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using FileMigrator.Helpers;

namespace FileMigrator.Helpers
{
    public class RestService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private string _AcumaticaBaseURL = "";
        private string _Endpoint = "";

        public RestService(string thisAcumaticaBaseURL, string thisEndPoint)
        {
            _httpClient = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                })
            {
                BaseAddress = new Uri(thisAcumaticaBaseURL + thisEndPoint),
                DefaultRequestHeaders =
                {
                    Accept = { MediaTypeWithQualityHeaderValue.Parse("text/json") }
                }
            };

            _AcumaticaBaseURL = thisAcumaticaBaseURL;
            _Endpoint = thisEndPoint;
        }

        void IDisposable.Dispose()
        {
            _httpClient.Dispose();
        }

        public string Login(string thisUsername, string thisPassword, string thisCompany, string thisBranch)
        {
            string credentialsAsString = JsonConvert.SerializeObject(new
            {
                name = thisUsername,
                password = thisPassword,
                company = thisCompany,
                branch = thisBranch
            });

            var response = _httpClient.PostAsync(_AcumaticaBaseURL + "/entity/auth/login", new StringContent(credentialsAsString, Encoding.UTF8, "application/json")).Result;

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return "OK";
                }
                else
                {
                    return "UNAUTHORISED";
                }
            }
            else
            {
                return "BAD REQUEST";
            }
        }

        public void Logout()
        {
            _httpClient.PostAsync(_AcumaticaBaseURL + "/entity/auth/logout", new ByteArrayContent(new byte[0])).Wait();
        }

        public string Put(string entityName, string entity, string parameters)
        {

            var response = _httpClient.PutAsync(_httpClient.BaseAddress + entityName + '?' + parameters, new StringContent(entity, Encoding.UTF8, "application/json")).Result;

            if (!response.IsSuccessStatusCode)
            {
                //response.Content.ReadAsStringAsync().Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            else return response.Content.ReadAsStringAsync().Result;

        }

        public string Get(string entityName, string parameters)
        {

            var response = _httpClient.GetAsync(_httpClient.BaseAddress + entityName + "?" + parameters).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("HTTP request failed:" + response.ReasonPhrase);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                return null;
            }
            else return response.Content.ReadAsStringAsync().Result;
        }

        public string GetByKeys(string entityName, string keys, string parameters)
        {
            var response = _httpClient.GetAsync(_httpClient.BaseAddress + entityName + "/" + keys + "?" + parameters).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("HTTP request failed:" + response.ReasonPhrase);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                return null;
            }
            else return response.Content.ReadAsStringAsync().Result;
        }

        public void Delete(string entityName, string keys)
        {
            var response = _httpClient.DeleteAsync(_httpClient.BaseAddress + entityName + "/" + keys).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("HTTP request failed:" + response.ReasonPhrase);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
        }

        public Stream GetFile(string href)
        {
            var response = _httpClient.GetAsync(href).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("HTTP request failed:" + response.ReasonPhrase);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                return null;
            }
            else return response.Content.ReadAsStreamAsync().Result;
        }

        public string PutFile(string entityName, string keys, string fileName, Stream file)
        {
            var response = _httpClient.PutAsync(_httpClient.BaseAddress + entityName + "/" + keys + "/files/" + fileName, new StreamContent(file)).Result;

            if (!response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else return response.Content.ReadAsStringAsync().Result;

            /*
            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("HTTP request failed:" + response.ReasonPhrase);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }*/
        }

        public string Post(string entityName, string actionName, string entityAndParameters)
        {
            var response = _httpClient
                .PostAsync(_httpClient.BaseAddress + entityName + "/" + actionName, new StringContent(entityAndParameters, Encoding.UTF8, "application/json")).Result;
            
            //If an error occurs in Acumatica ERP, contains the error message.
            var content = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();

            var dt = DateTime.Now;
            while (true)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NoContent:
                        return "No content";
                    case HttpStatusCode.Accepted:
                        if ((DateTime.Now - dt).Seconds > 30)
                            throw new TimeoutException();
                        Thread.Sleep(500);
                        response = _httpClient.GetAsync(response.Headers.Location).Result.EnsureSuccessStatusCode();
                        continue;
                    default:
                        throw new InvalidOperationException("Invalid process result: " + response.StatusCode);
                }
            }                
        }
    }
}
