using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestServer
{
    public class ServerREST
    {
        private WebServiceHost host;

        public void Iniciar(string uriString)
        {
            try
            {
                var service = new Service();
                host = new WebServiceHost(service, new Uri(uriString));

                host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
                host.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                throw;
            }
        }

        public void Detener()
        {
            host.Close();
        }
    }
}