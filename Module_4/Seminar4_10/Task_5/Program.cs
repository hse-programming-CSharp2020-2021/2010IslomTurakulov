using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var htmlText = await GetUrl("https://hse.ru/");
            foreach (Match match in Regex.Matches(htmlText, @"<img.*?src=(?<name>"".*?"").*?>"))
                Console.WriteLine(match.Groups["name"].Value);
        }

        private static async Task<string> GetUrl(string link) 
            => await (new HttpClient()).GetAsync(link).Result.Content.ReadAsStringAsync();
    }
}
