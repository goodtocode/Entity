using GoodToCode.Entity.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Person
{
    public class IndexModel : PageModel
    {
        public const string ResultMessage = "Result";
        public const string ValidationSummaryMessage = "ValidationSummary";
        private readonly IHttpQueryService<PersonDto> queryService;

        [BindProperty]
        public PersonDto Criteria { get; set; }
        [BindProperty]
        public List<PersonDto> Results { get; set; }

        public IndexModel(IConfiguration configuration, IHttpQueryService<PersonDto> query)
        {
            queryService = query;
        }

        public IActionResult OnGet()
        {
            Criteria = new PersonDto();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var query = $"{Criteria.Key}/{Criteria.FirstName}/{Criteria.LastName}/";
            Results = await queryService.QueryAsync(query);
            TempData[ResultMessage] = $"{Results.Count} matches found";

            return Page();
        }
    }
}