using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace GoodToCode.Entity.Hosting.Server
{
    /// <summary>
    /// Adds feature
    /// Example usage: 
    ///   public void ConfigureServices(IServiceCollection services) {
    ///      services.
    ///          AddMvc(o => o.Conventions.Add(
    ///              new CrudApiControllerRouteConvention()
    ///          )).
    ///          ConfigureApplicationPartManager(m =>
    ///              m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()
    ///          ));}
    /// </summary>
    public class CrudApiControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        private List<CrudApiInfo> typesAndRoutes = new List<CrudApiInfo>();

        /// <summary>
        /// Constructor
        /// </summary>
        public CrudApiControllerFeatureProvider() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="routeToBind"></param>
        public CrudApiControllerFeatureProvider(Type entityType, string routeToBind)
        {
            typesAndRoutes.Add(new CrudApiInfo(entityType, routeToBind));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerTypesAndRoutes"></param>
        public CrudApiControllerFeatureProvider(List<CrudApiInfo> controllerTypesAndRoutes)
        {
            typesAndRoutes.AddRange(controllerTypesAndRoutes);
        }

        /// <summary>
        /// Adds the type and controller, without the Generic aspect of CrudApiController
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="feature"></param>
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var item in typesAndRoutes)
            {
                feature.Controllers.Add(
                    typeof(CrudApiController<>).MakeGenericType(item.Key).GetTypeInfo()
                );
            }
        }
    }
}

namespace GoodToCode.Entity.Hosting.Server
{
    /// <summary>
    /// Route convetion adding route to controller
    /// Example usage: 
    ///   public void ConfigureServices(IServiceCollection services) {
    ///      services.
    ///          AddMvc(o => o.Conventions.Add(
    ///              new CrudApiControllerRouteConvention()
    ///          )).
    ///          ConfigureApplicationPartManager(m =>
    ///              m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()
    ///          ));}
    /// </summary>
    public class CrudApiControllerRouteConvention : IControllerModelConvention
    {
        private List<CrudApiInfo> typesAndRoutes = new List<CrudApiInfo>();

        /// <summary>
        /// Constructor
        /// </summary>
        public CrudApiControllerRouteConvention() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="routeToBind"></param>
        public CrudApiControllerRouteConvention(Type entityType, string routeToBind)
        {
            typesAndRoutes.Add(new CrudApiInfo(entityType, routeToBind));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerTypesAndRoutes"></param>
        public CrudApiControllerRouteConvention(List<CrudApiInfo> controllerTypesAndRoutes)
        {
            typesAndRoutes.AddRange(controllerTypesAndRoutes);
        }

        /// <summary>
        /// Applys the route convention
        /// </summary>
        /// <param name="controller"></param>
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                // Method 1 - Default
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                controller.ControllerName = genericType.Name;

                // Method 2 - Route["api/Entity"]
                controller.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"api/{genericType.Name}")),
                });
            }
        }
    }
}

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
        /// <summary>
        /// Name of the controller and path part
        /// </summary>
        public string ControllerName => typeof(TEntity).Name;

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
        /// Retrieves item by Id
        /// </summary>        
        /// <param name="key"></param>
        /// <returns>Person that matches the Id, or initialized PersonDto for not found condition</returns>
        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            var reader = new EntityReader<TEntity>();
            var item = reader.GetByIdOrKey(key);
            return Ok(item);
        }

        /// <summary>
        /// Creates a new item
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
        /// Saves changes to a item
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
        /// Saves changes to a item
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

namespace GoodToCode.Entity.Hosting.Server
{
    /// <summary>
    /// Crud Controller and Route information
    /// </summary>
    public class CrudApiInfo
    {
        /// <summary>
        /// Type representing the CrudApiController
        ///     
        /// </summary>
        public Type CrudType { get; set; }

        /// <summary>
        /// Route associated with this type
        /// </summary>
        public string CrudRoute { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CrudApiInfo() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="routeToBind"></param>
        public CrudApiInfo(Type entityType, string routeToBind)
        {
            CrudType = entityType;
            CrudRoute = routeToBind;
        }
    }
}

