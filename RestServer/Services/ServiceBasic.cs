using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace RestServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                    ConcurrencyMode = ConcurrencyMode.Single,
                    IncludeExceptionDetailInFaults = true,
                    AutomaticSessionShutdown = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public string SayHello(string name)
        {
            string nombreARetornar;
            if (string.IsNullOrEmpty(name))
            {
                nombreARetornar = "Hello ....";
            }
            {
                nombreARetornar = name;
            }
            return string.Format("Hello {0}!", nombreARetornar);
        }

        public string SayHello2(string name, string sourcename)
        {
            string nombreARetornar, apellidoARetornar;
            if (string.IsNullOrEmpty(name))
            {
                nombreARetornar = "Parametro1Null";
            }
            {
                nombreARetornar = name;
            }

            if (string.IsNullOrEmpty(sourcename))
            {
                apellidoARetornar = "Parametro1Null";
            }
            {
                apellidoARetornar = name;
            }

            return string.Format("DosParametros p1:{0} p2:{1}", nombreARetornar, apellidoARetornar);
        }

        public string SayHello3(string name, string sourcename, string nickname)
        {
            WebOperationContext context = WebOperationContext.Current;
            string sitesId = context.IncomingRequest.Headers["HeaderKey"];

            var isValid = false;

            if (sitesId != null)
            {
                var ListSite = sitesId.Replace("[", "").Replace("]", "").Split(';');

                var siteValid = "5CBFC0B4-29AD-48FA-BCB7-B0ACCD13A568";


                foreach (var item in ListSite)
                {
                    if (item.ToUpper().Equals(siteValid))
                        isValid = true;
                }

            }
            if (!isValid)
            {
                context.OutgoingResponse.Headers.Add("ValidSegurity", "false");
                context.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                return System.Net.HttpStatusCode.Unauthorized.ToString();
            }


            string nombreARetornar;
            if (string.IsNullOrEmpty(name))
            {
                nombreARetornar = "persona";
            }
            {
                nombreARetornar = name;
            }

            context.OutgoingResponse.Headers.Add("ValidSegurity", "true");


            return string.Format("Hola {0}! ap: {1} apodo: {2}", nombreARetornar, sourcename, nickname);
        }
    }
}