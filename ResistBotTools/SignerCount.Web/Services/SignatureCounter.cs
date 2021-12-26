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
        private HtmlDocument _page;

        public SignatureCounter(ICustomRestClient restClient)
        {
            _client = restClient;
        }

        public async Task<int> GetTotalCount()
        {
            var signerCounts = await GetSignerCountsByPetitionElement();

            // Rather than invest time in trying to isolate this, we will just deduct it's single signer
            return signerCounts.Sum() - 1;
        }

        public async Task<int> GetCountOnDayIndex(int index)
        {
            var signerCounts = await GetSignerCountsByPetitionElement();

            var yesterdayElements = signerCounts.ToList().GetRange(index, 2);

            return yesterdayElements.Sum();
        }

        private async Task<IEnumerable<int>> GetSignerCountsByPetitionElement()
        {
            await GetPage();

            var elements = _page
                .DocumentNode
                .Descendants()
                .Where(node => node.OuterHtml.Contains("<p class=\"Petition_signCount") && node.Name == "p");

            return elements.Select(element => int.Parse(element.InnerHtml));
        }

        private async Task GetPage()
        {
            if (_page == null || !_page.DocumentNode.HasChildNodes)
            {
                var request = new RestRequest(new Uri("https://resist.bot/go/jdmac020"));
                var response = _client.MakeCall(request);
                var content = _client.GetResponseContent(await response);

                HtmlDocument page = new HtmlDocument();
                page.LoadHtml(content);

                _page = page;
            }
        }
    }
}
