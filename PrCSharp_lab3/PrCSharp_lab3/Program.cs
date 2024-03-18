using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrCSharp_lab3
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            int choice = -1;

            Console.WriteLine("1) Exercise 1");
            Console.WriteLine("2) Exercise 2");
            Console.WriteLine("3) Exercise 3");
            Console.WriteLine("4) Quit");

            Console.Write("Select option: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter an ipv4 address: ");
                    string ipv4 = Console.ReadLine();
                    await SomethingLikeWhois(ipv4);
                    break;
                case 2:
                    await CurrentLocalTime();
                    break;
                case 3:
                    Console.Write("Enter a keyword to omit when searching for news articles: ");
                    string keyword = Console.ReadLine();
                    await Scraper(keyword);
                    break;
                case 4:
                    break;
                default:
                    throw new ArgumentException("Wrong option selected");
            }
        }

        static async Task SomethingLikeWhois(string ip)
        {
            string SiteUrl = "https://ipapi.co/" + ip + "/country/";

            try
            {
                HttpResponseMessage response = await client.GetAsync(SiteUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task CurrentLocalTime()
        {
            string timeSourceUrl = "https://www.timeanddate.com/worldclock/bulgaria/sofia";

            var response = await client.GetByteArrayAsync(timeSourceUrl);
            String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            source = WebUtility.HtmlDecode(source);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(source);

            List<string> neededHtmlIds = new List<string> { "ctdat", "ct" };
            List<HtmlNode> neededNodes = new List<HtmlNode>();

            foreach(var id in neededHtmlIds)
            {
                HtmlNode node = htmlDoc.DocumentNode.Descendants().Where
                (x => (x.Name == "span" && x.Attributes["id"] != null &&
                x.Attributes["id"].Value.Equals(id))).ToList().First();
                neededNodes.Add(node);
            }

            Console.WriteLine(neededNodes[0].InnerText + " " + neededNodes[1].InnerText);
        }

        static async Task Scraper(string keywordToSkip)
        {
            string url = "https://www.mediapool.bg/news";

            var response = await client.GetByteArrayAsync(url);
            String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            source = WebUtility.HtmlDecode(source);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(source);

            List<HtmlNode> articles = htmlDoc.DocumentNode.Descendants().Where
                (x => (x.Name == "article" && x.Attributes["id"] != null)).ToList();

            foreach(var article in articles)
            {
                if(article.Descendants().Where(
                    x => (x.Name == "a" && x.Attributes["href"] != null &&
                    x.Attributes["href"].Value.Contains(keywordToSkip))).ToList().Count != 0){
                    continue;
                }


                var title = article.Descendants().Where
                    (x => (x.Name == "h2" && x.Attributes["class"] != null &&
                    x.Attributes["class"].Value.Equals("c-article-item__title"))).ToList();

                var dateTime = article.Descendants().Where
                    (x => (x.Name == "time" && x.Attributes["class"] != null &&
                    x.Attributes["class"].Value.Equals("c-article-item__date"))).ToList();

                if (title.Count != 0 && dateTime.Count != 0)
                {
                    Console.WriteLine(title[0].InnerText + " - " + dateTime[0].InnerText);
                }
            }
        }
    }
}
