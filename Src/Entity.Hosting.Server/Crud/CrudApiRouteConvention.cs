using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;

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
        private List<KeyValuePair<Type, string>> typesAndRoutes = new List<KeyValuePair<Type, string>>();

        /// <summary>
        /// Applys the route convention
        /// </summary>
        /// <param name="controller"></param>
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                controller.ControllerName = genericType.Name;
            }
        }
    }
}

