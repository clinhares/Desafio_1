using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desafio1
{
    class Program
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando...");

            Buscar().GetAwaiter().GetResult();
        }

        private static async Task Buscar()
        {
            var htmlTask = HttpClient.GetStringAsync("http://www.hiper.com.br");

            ServicePointManager.ServerCertificateValidationCallback =(sender, certificate, chain, sslPolicyErrors) => true;

            var html = await htmlTask;

            var count = Regex.Matches(html, @"Hiper").Count;

            Console.WriteLine($"Quantidade: {count}");

            Console.Read();
        }
    }
}
