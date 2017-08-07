using System;

namespace RunRestServer
{
    class main
    {
        static void Main(string[] args)
        {
            var servirdor = new RestServer.ServerREST();
            var uri = "http://localhost:8089";
            Console.WriteLine("Rest server is starting");
            servirdor.Iniciar(uri);
            Console.WriteLine("Rest server was started on " + uri);
            Console.WriteLine("Check: " + uri + "GetDateTime");
            Console.WriteLine("Check: " + uri + "SayHello/name");
            Console.WriteLine("Check: " + uri + "SayHello2/name/sourcename");
            Console.WriteLine("Check: " + uri + "SayHello3?name=MyName&sourcename=Sourcename&nickname=MiNickname");


            Console.ReadLine();
        }
    }
}
