using GoodToCode.Framework.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Event
{
    public class CreateModel : PageModel
    {
        public const string ResultMessage = "Result";
        public const string ValidationSummaryMessage = "ValidationSummary";
        private readonly IHttpCrudService<EventDto> crudService;

        [BindProperty]
        public EventDto Event { get; set; }

        public CreateModel(IConfiguration configuration, IHttpCrudService<EventDto> crud)
        {
            crudService = crud;
        }

        public IActionResult OnGet()
        {
            Event = new EventDto();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Event = await crudService.CreateAsync(Event);
            if (!Event.IsNew)
                TempData[ResultMessage] = "Successfully created";
            else
                TempData[ResultMessage] = "Failed to create";

            return Page();
        }
    }
}