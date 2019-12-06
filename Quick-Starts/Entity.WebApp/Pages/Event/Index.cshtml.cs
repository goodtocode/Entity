using GoodToCode.Framework.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Event
{
    public class IndexModel : PageModel
    {
        public const string ResultMessage = "Result";
        public const string ValidationSummaryMessage = "ValidationSummary";
        private readonly IHttpQueryService<EventDto> queryService;

        [BindProperty]
        public EventDto Criteria { get; set; }
        [BindProperty]
        public List<EventDto> Results { get; set; }

        public IndexModel(IConfiguration configuration, IHttpQueryService<EventDto> query)
        {
            queryService = query;
        }

        public IActionResult OnGet()
        {
            Criteria = new EventDto();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var query = $"{Criteria.Key}/{Criteria.Name}/{Criteria.Description}/";
            Results = await queryService.QueryAsync(query);
            TempData[ResultMessage] = $"{Results.Count} matches found";

            return Page();
        }
    }
}