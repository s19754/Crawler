using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            if (args.Length < 1) throw new ArgumentNullException();
            var websiteUrl = args[0];
           

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(websiteUrl);
            Console.WriteLine(response);


            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);



            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var matchCollection = regex.Matches(content);

            var set = new HashSet<string>();

            foreach (var item in matchCollection)
            {
                set.Add(item.ToString());
            }

            foreach (var item in matchCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
