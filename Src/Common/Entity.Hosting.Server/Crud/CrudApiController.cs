//using System;
//using GoodToCode.Extensions.Configuration;
//using GoodToCode.Extensions.Net;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

//namespace GoodToCode.Entity.Hosting.Server
//{

//    /// <summary>
//    /// WebAPI CRUD controller to receive CRUD requests.
//    /// Complimented by HttpCrudService loaded into MVC IServiceCollection
//    /// Expects the following action/endpoint calls
//    ///   C - HttpPut(TDto item)
//    ///   R - HttpGet(string idOrKey)
//    ///   U - HttpPost(TDto item)
//    ///   D - HttpDelete(string idOrKey)
//    /// </summary>
//    public abstract class CrudApiController<TDto> : Controller
//    {
//        public const string ControllerName = "Person";
//        public const string ControllerRoute = "v4/Person";
//        public const string GetActionText = "Get Person";
//        public const string GetAction = "Get";
//        public const string PutAction = "Put";
//        public const string PostAction = "Post";
//        public const string DeleteAction = "Delete";

//        /// <summary>
//        /// Retrieves Person by Id
//        /// </summary>
//        /// <returns>Person that matches the Id, or initialized PersonDto for not found condition</returns>
//        [HttpGet(ControllerRoute + "/{key}")]
//        public IActionResult Get(string key)
//        {
//            var reader = new EntityReader<PersonInfo>();
//            var Person = new PersonInfo();

//            if (key.IsInteger())
//                Person = reader.GetById(key.TryParseInt32());
//            else
//                Person = reader.GetByKey(key.TryParseGuid());

//            return Ok(Person.CastOrFill<PersonDto>());
//        }

//        /// <summary>
//        /// Creates a new Person
//        /// </summary>
//        /// <returns></returns>
//        [HttpPut(ControllerRoute)]
//        public IActionResult Put([FromBody]PersonDto model)
//        {
//            var Person = model.CastOrFill<PersonInfo>();
//            Person = Person.Save();
//            return Ok(Person.CastOrFill<PersonDto>());
//        }

//        /// <summary>
//        /// Saves changes to a Person
//        /// </summary>
//        /// <param name="model">Full Person model worth of data with user changes</param>
//        /// <returns>PersonDto containing Person data</returns>
//        [HttpPost(ControllerRoute)]
//        public IActionResult Post([FromBody]PersonDto model)
//        {
//            var Person = model.CastOrFill<PersonInfo>();
//            Person = Person.Save();
//            return Ok(Person.CastOrFill<PersonDto>());
//        }

//        /// <summary>
//        /// Saves changes to a Person
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        [HttpDelete(ControllerRoute + "/{key}")]
//        public IActionResult Delete(string key)
//        {
//            var reader = new EntityReader<PersonInfo>();
//            var Person = new PersonInfo();

//            if (key.IsInteger())
//                Person = reader.GetById(key.TryParseInt32());
//            else
//                Person = reader.GetByKey(key.TryParseGuid());
//            Person = Person.Delete();

//            return Ok(Person.CastOrFill<PersonDto>());
//        }
//    }
//}

