using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignerCount.Web.Services
{
    public class CustomRestClient : ICustomRestClient
    {
        public string GetResponseContent(IRestResponse response)
        {
            return response.Content;
        }

        public async Task<IRestResponse> MakeCall(IRestRequest request)
        {
            var client = new RestClient();
            return await client.ExecuteGetAsync(request);
        }
    }
}
