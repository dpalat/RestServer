using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestServer
{
    [ServiceContract(Name = "Service")]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetDateTime",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetDateTime();

        [OperationContract]
        [WebGet(UriTemplate = "/SayHello/{name}",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string SayHello(string name);

        [OperationContract]
        [WebGet(UriTemplate = "/SayHello2/{name}/{sourcename}",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string SayHello2(string name, string sourcename);

        [OperationContract]
        [WebGet(UriTemplate = "/SayHello3?name={name}&sourcename={sourcename}&nickname={nickname}",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string SayHello3(string name, string sourcename, string nickname);
    }
}