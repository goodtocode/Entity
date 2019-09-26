using GoodToCode.Entity.Hosting.DELETEME;
using GoodToCode.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Person
{
    public class UpdateModel : PageModel
    {
        public const string ResultMessage = "Result";
        public const string ValidationSummaryMessage = "ValidationSummary";
        private readonly IHttpCrudService<PersonDto> crudService;

        [BindProperty]
        public PersonDto Person { get; set; }

        public UpdateModel(IConfiguration configuration, IHttpCrudService<PersonDto> crud)
        {
            crud.Uri = new System.Uri($@"{configuration["AppSettings:MyWebService"]}/Person");
            crudService = crud;
        }

        public async Task<IActionResult> OnGet(string id)
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

            Person = await crudService.UpdateAsync(Person);
            if (!Person.IsNew)
                TempData[ResultMessage] = "Successfully Updated";
            else
                TempData[ResultMessage] = "Failed to Update";

            return Page();
        }
    }
}