using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Task_2
{
    class Program
    {
        static async Task Main()
        {
            var htmlText = await HtmlText();

            Console.WriteLine($"Скачали ответ: {htmlText.Length} символов");

            NewMethod(htmlText);
        }

        private static void NewMethod(string htmlText)
        {
            // Находим все подстроки, подходящие по шаблону:
            MatchCollection linksCollection = Regex.Matches(htmlText,
                @" href=""\/wiki\/(?<name>[a-zA-z0-9%]+)""");

            foreach (Match link in linksCollection)
                Console.WriteLine($"{HttpUtility.UrlDecode(link.Groups["name"].Value)} : {HttpUtility.UrlDecode(link.ToString())}");
        }

        private static async Task<string> HtmlText()
        {
            using HttpClient client = new HttpClient();
            var wikiLink = "https://en.wikipedia.org/wiki/Main_Page";
            var response = await client.GetAsync(wikiLink);
            string htmlText = await response.Content.ReadAsStringAsync();
            return htmlText;
        }
    }
}
