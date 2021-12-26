using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SignerCount.Web.Services;

namespace SignerCount.Web.Pages
{
    public class IndexModel : PageModel
    {
        public int TotalSignatures { get; private set; }
        public int YesterdayCount { get; private set; }
        public int DayBeforeYesterdayCount { get; private set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly SignatureCounter _counter;

        public IndexModel(ILogger<IndexModel> logger, ICustomRestClient client)
        {
            _logger = logger;
            _counter = new SignatureCounter(client);
        }

        public async Task OnGet()
        {
            var total = _counter.GetTotalCount();
            var yesterday = _counter.GetCountOnDayIndex(2);
            var dayBeforeYesterday = _counter.GetCountOnDayIndex(4);

            TotalSignatures = await total;
            YesterdayCount = await yesterday;
            DayBeforeYesterdayCount = await dayBeforeYesterday;
        }
    }
}
