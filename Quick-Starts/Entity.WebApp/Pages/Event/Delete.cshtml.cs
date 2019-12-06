using GoodToCode.Framework.Hosting;
using GoodToCode.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Event
{
    public class DeleteModel : PageModel
    {
        public const string ResultMessage = "ResultMessage";
        public const string ValidationSummaryMessage = "Action resulted in...";
        private readonly IHttpCrudService<EventDto> crudService;

        [BindProperty]
        public EventDto Event { get; set; }

        public DeleteModel(IConfiguration configuration, IHttpCrudService<EventDto> crud)
        {
            crudService = crud;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.TryParseGuid() != Defaults.Guid)
                Event = await crudService.ReadAsync(id.TryParseGuid());
            else
                Event = await crudService.ReadAsync(id.TryParseInt32());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await crudService.DeleteAsync(Event);
            if (result)
                TempData[ResultMessage] = "Successfully Deleted";
            else
                TempData[ResultMessage] = "Failed to Delete";

            return Page();
        }
    }
}