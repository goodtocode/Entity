using GoodToCode.Entity.Hosting;
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace GoodToCode.Entity.Test
{
    [TestClass]
    public class HttpCrudTests
    {
        private static IOptions<HttpCrudOptions> _options;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", false)
            //    .Build();
            // configuration.GetSection("HttpCrudEndpoints").Bind(optionsData);
            var optionsData = new HttpCrudOptions() { new HttpCrudOption() { Type = "PersonDto", Url = "https://entities-for-webapi.azurewebsites.net/v4/PersonSearch" } };
            _options = Options.Create<HttpCrudOptions>(optionsData);
        }

        [TestMethod]
        public void HttpCrudOptions_Construction()
        {
            var service = new HttpCrudService<PersonDto>(_options);
            Assert.IsTrue(!string.IsNullOrEmpty(service.TypeName));
            Assert.IsTrue(service.Uri != Defaults.Uri);
        }
    }
}
