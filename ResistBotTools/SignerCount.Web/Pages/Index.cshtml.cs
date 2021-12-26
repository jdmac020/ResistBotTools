using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SignerCount.Web.Services;

namespace SignerCount.Web.Pages
{
    public class IndexModel : PageModel
    {
        public int TotalSignatures { get; private set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly SignatureCounter _counter;

        public IndexModel(ILogger<IndexModel> logger, ICustomRestClient client)
        {
            _logger = logger;
            _counter = new SignatureCounter(client);
        }

        public async Task OnGet()
        {
            TotalSignatures = await _counter.GetPage();
        }
    }
}
