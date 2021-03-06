using HtmlAgilityPack;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignerCount
{
    public interface ICustomRestClient
    {
        Task<IRestResponse> MakeCall(IRestRequest request);
        string GetResponseContent(IRestResponse response);
    }
}