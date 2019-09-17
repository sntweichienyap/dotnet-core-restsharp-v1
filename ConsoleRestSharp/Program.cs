using System;
using static System.Console;
using RestSharp;
using System.Net;

namespace ConsoleRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallGetValues();

            //CallAuth();

            CallLazada();

            ReadLine();
        }

        static void CallGetValues()
        {
            var client = new RestClient("http://emulatelazadaapi.azurewebsites.net");
            var request = new RestRequest("api/values");

            var response = client.Get(request);
            var content = response.Content;

            WriteLine(content);
        }

        static void CallAuth()
        {
            var client = new RestClient("http://emulatelazadaapi.azurewebsites.net");
            var request = new RestRequest("api/auth");

            var authRequest = new LazadaAuthRequest() { username = "sntuser", password="abc123"};
            request.AddJsonBody(authRequest);

            var response = client.Post<LazadaAuthResponse>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                WriteLine(content);
            }
            else
            {
                var content = response.Content;
                WriteLine("API RESPONSE FAIL");
                WriteLine("API RESPONSE FAIL");
                WriteLine("API RESPONSE FAIL");
                WriteLine();
                WriteLine(content);
            }
        }

        static void CallLazada()
        {
            var client = new RestClient("http://emulatelazadaapi.azurewebsites.net");
            var request = new RestRequest("api/lazada");

            var statusUpdateRequest = new LazadaStatusUpdateRequest() { tracking_number="abc123"};
            request.AddQueryParameter("token", "qwerrttuuyiiytit");
            request.AddJsonBody(statusUpdateRequest);

            var response = client.Post<LazadaStatusUpdateResponse>(request);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {              
                WriteLine("Success");
            }
            else
            {
                var content = response.Content;
                WriteLine("API RESPONSE FAIL");
                WriteLine("API RESPONSE FAIL");
                WriteLine("API RESPONSE FAIL");
                WriteLine();
                WriteLine(content);
            }
        }

        //--------------------
        public class LazadaStatusUpdateRequest
        {
            public string tracking_number { get; set; }
        }

        public class LazadaStatusUpdateResponse
        {
            public string message { get; set; }
            public string status_code { get; set; }
        }

        //--------------------
        public class LazadaAuthRequest
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class LazadaAuthResponse
        {
            public string token { get; set; }
            public string message { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}
