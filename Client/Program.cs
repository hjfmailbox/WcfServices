using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestNormalWCF();

            TestWebRequest();

            Console.ReadKey();
        }

        private static void TestNormalWCF()
        {
            try
            {
                WebHttpBinding binding = new WebHttpBinding();
                string baseAddress = "http://localhost:8730/yfservices/REST/CreateUser";
                EndpointAddress endpoint = new EndpointAddress(baseAddress);

                using (YFServiceClient client = new YFServiceClient(binding, endpoint))
                {
                    client.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                    var user = client.CreateUser();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void TestWebRequest()
        {
            try
            {
                string address = "http://localhost:8730/yfservices/REST/CreateUser";
                WebRequest request = WebRequest.Create(address);
                WebResponse ws = request.GetResponse();
                StreamReader responseStream = new StreamReader(ws.GetResponseStream());
                string response = responseStream.ReadToEnd();
                responseStream.Close();
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
