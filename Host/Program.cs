using System;
using WcfServices;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                YFService.Open();
                Console.WriteLine("开启服务成功");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}
