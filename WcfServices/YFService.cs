using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfServices.Models;

namespace WcfServices
{
    [ServiceBehavior(
        IncludeExceptionDetailInFaults = true, 
        AddressFilterMode = AddressFilterMode.Any)]
    public class YFService : IYFService
    {
        public static void Open()
        {
            string baseAddress = "http://localhost:8730/yfservices/";

            ServiceHost host = null;
            try
            {
                host = new ServiceHost(typeof(YFService), new Uri(baseAddress));
                var endpoint = host.AddServiceEndpoint(typeof(IYFService), new WebHttpBinding(), "REST");
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                var smBeh = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true
                };
                host.Description.Behaviors.Add(smBeh);
                host.Open();
            }
            catch (Exception e)
            {
                if (host != null) host.Abort();
                if (e is AddressAccessDeniedException ex)
                {
                    throw new AddressAccessDeniedException("拒绝访问，请以管理员身份运行程序!", ex);
                }
                else
                {
                    throw new Exception("打开wcf服务失败", e);
                }
            }
        }

        public User CreateUser()
        {
            User user = new User()
            {
                Id = new Random().Next(1, 10),
                UserName = "userName",
                CreateDate = DateTime.Now
            };

            return user;
        }
    }
}
