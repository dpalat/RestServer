using System;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace RestServer
{
    public class ServerREST
    {
        WebServiceHost host;
        public void Iniciar(string uriString)
        {
            try
            {
                var service = new Service();
                this.host = new WebServiceHost(service, new Uri(uriString));

                this.host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
                this.host.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                throw;
            }
        }

        public void Detener()
        {
            this.host.Close();
        }
    }
}