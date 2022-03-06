using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            var websiteUrl = args[0];
            Console.WriteLine(websiteUrl);

            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(websiteUrl);
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);



            var regex = new Regex(@"");
            var matchCollection = regex.Matches(content);

            foreach (var item in matchCollection)
            {

            }
        }
    }
}
