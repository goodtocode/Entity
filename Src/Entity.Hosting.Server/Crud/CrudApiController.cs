using GoodToCode.Framework.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoodToCode.Entity.Hosting.Server
{
    /// <summary>
    /// WebAPI CRUD controller to receive CRUD requests.
    /// Complimented by HttpCrudService loaded into MVC IServiceCollection
    /// Expects the following action/endpoint calls
    ///   C - HttpPut(TDto item)
    ///   R - HttpGet(string idOrKey)
    ///   U - HttpPost(TDto item)
    ///   D - HttpDelete(string idOrKey)
    /// </summary>
    [Route("crud/[Controller]")]
    public abstract class CrudApiController<TEntity> : ControllerBase where TEntity : ActiveRecordEntity<TEntity>, new()
    {
        //https://www.strathweb.com/2018/04/generic-and-dynamically-generated-controllers-in-asp-net-core-mvc/


        /// <summary>
        /// Name of the controller and path part
        /// </summary>
        public string ControllerName  => typeof(TEntity).Name;

        /// <summary>
        /// Path part inbetween domain and controller name
        /// I.e. http:/www.domain.com/RootPathPart/ControllerName
        /// </summary>
        public string RootPathPart = "api";

        /// <summary>
        /// Path part to the controller
        /// </summary>
        public string ControllerRoute => $"{RootPathPart}/{ControllerName}";

        /// <summary>
        /// Exposed endpoint name for HTTP_GET
        /// </summary>
        public const string GetAction = "Get";

        /// <summary>
        /// Exposed endpoint name for HTTP_PUT
        /// </summary>
        public const string PutAction = "Put";

        /// <summary>
        /// Exposed endpoint name for HTTP_POST
        /// </summary>
        public const string PostAction = "Post";

        /// <summary>
        /// Exposed endpoint name for HTTP_DELETE
        /// </summary>
        public const string DeleteAction = "Delete";

        /// <summary>
        /// Retrieves Person by Id
        /// </summary>
        /// <returns>Person that matches the Id, or initialized PersonDto for not found condition</returns>
        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            //var reader = new EntityReader<PersonInfo>();
            //var Person = new PersonInfo();

            //Person = reader.GetByIdOrKey(key);

            //return Ok(Person.CastOrFill<PersonDto>());
            return Ok();
        }

        /// <summary>
        /// Creates a new Person
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]TEntity model)
        {
            //var Person = model.CastOrFill<PersonInfo>();
            //Person = Person.Save();
            //return Ok(Person.CastOrFill<PersonDto>());
            return Ok();
        }

        /// <summary>
        /// Saves changes to a Person
        /// </summary>
        /// <param name="model">Full Person model worth of data with user changes</param>
        /// <returns>PersonDto containing Person data</returns>
        [HttpPost]
        public IActionResult Post([FromBody]TEntity model)
        {
            //var Person = model.CastOrFill<PersonInfo>();
            //Person = Person.Save();
            //return Ok(Person.CastOrFill<PersonDto>());
            return Ok();
        }

        /// <summary>
        /// Saves changes to a Person
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            //var reader = new EntityReader<PersonInfo>();
            //var Person = new PersonInfo();

            //Person = reader.GetByIdOrKey(key);
            //Person = Person.Delete();

            //return Ok(Person.CastOrFill<PersonDto>());
            return Ok();
        }
    }
}

