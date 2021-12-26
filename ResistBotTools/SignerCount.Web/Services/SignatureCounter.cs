using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignerCount.Web.Services
{
    public class SignatureCounter
    {
        private ICustomRestClient _client;

        public SignatureCounter(ICustomRestClient restClient)
        {
            _client = restClient;
        }

        public async Task<int> GetTotalCount()
        {
            var request = new RestRequest(new Uri("https://resist.bot/go/jdmac020"));
            var response = _client.MakeCall(request);
            var content = _client.GetResponseContent(await response);

            HtmlDocument page = new HtmlDocument();
            page.LoadHtml(content);

            var elements = page
                .DocumentNode
                .Descendants()
                .Where(node => node.OuterHtml.Contains("<p class=\"Petition_signCount") && node.Name == "p");

            var signCounts = elements.Select(element => int.Parse(element.InnerHtml));

            // Rather than invest time in trying to isolate this, we will just deduct it's single signer
            return signCounts.Sum() - 1;
        }

        public async Task<int> GetPreviousDayCount()
        {
            var request = new RestRequest(new Uri("https://resist.bot/go/jdmac020"));
            var response = _client.MakeCall(request);
            var content = _client.GetResponseContent(await response);

            HtmlDocument page = new HtmlDocument();
            page.LoadHtml(content);

            var elements = page
                .DocumentNode
                .Descendants()
                .Where(node => node.OuterHtml.Contains("<p class=\"Petition_signCount") && node.Name == "p");

            var signCounts = elements.Select(element => int.Parse(element.InnerHtml));

            var yesterdayElements = signCounts.ToList().GetRange(2, 2);

            // Rather than invest time in trying to isolate this, we will just deduct it's single signer
            return yesterdayElements.Sum();
        }
    }
}
