using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            if (args.Length < 1) throw new ArgumentNullException("Parameter 0 cannot be null.");
            var websiteUrl = args[0];

            Regex rgx = new Regex("^(http|https|ftp)\\://([a-zA-Z0-9\\.\\-]+(\\:[a-zA-Z0-9\\.&amp;%\\$\\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\\-]+\\.)*[a-zA-Z0-9\\-]+\\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\\:[0-9]+)*(/($|[a-zA-Z0-9\\.\\,\\?\\'\\\\+&amp;%\\$#\\=~_\\-]+))*$");

            Match match = rgx.Match(args[0]);
            if (!match.Success) throw new ArgumentException("URL not valid: " + args[0]);

            var httpClient = new HttpClient();

            try
            {

                var response = await httpClient.GetAsync(websiteUrl);

                var content = await response.Content.ReadAsStringAsync();



                var regex = new Regex(@"[a-zA-Z0-9+._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+");
                MatchCollection matchCollection = regex.Matches(content);

                HashSet<string> set = new HashSet<string>();

                if (Convert.ToBoolean(matchCollection.Count))
                {
                    foreach (var el in matchCollection)
                    {
                        set.Add(el.ToString());
                    }

                    foreach (var hashh in set)
                    {
                        Console.WriteLine(hashh);
                    }
                }
                else
                {
                    Console.WriteLine("Nie znaleziono adresów email.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Błąd w czasie pobierania strony");
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}
