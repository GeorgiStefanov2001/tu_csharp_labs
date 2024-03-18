using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrCSharp_lab2
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
    }
}
