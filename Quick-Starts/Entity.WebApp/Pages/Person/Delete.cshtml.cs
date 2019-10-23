using GoodToCode.Framework.Hosting;
using GoodToCode.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Person
{
    public class DeleteModel : PageModel
    {
        public const string ResultMessage = "ResultMessage";
        public const string ValidationSummaryMessage = "Action resulted in...";
        private readonly IHttpCrudService<PersonDto> crudService;

        [BindProperty]
        public PersonDto Person { get; set; }

        public DeleteModel(IConfiguration configuration, IHttpCrudService<PersonDto> crud)
        {
            crudService = crud;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.TryParseGuid() != Defaults.Guid)
                Person = await crudService.ReadAsync(id.TryParseGuid());
            else
                Person = await crudService.ReadAsync(id.TryParseInt32());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await crudService.DeleteAsync(Person);
            if (result)
                TempData[ResultMessage] = "Successfully Deleted";
            else
                TempData[ResultMessage] = "Failed to Delete";

            return Page();
        }
    }
}