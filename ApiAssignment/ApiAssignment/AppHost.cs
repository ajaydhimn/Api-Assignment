using ApiAssignment.ServiceInterface;
using ApiAssignment.ServiceModel;
using Funq;
using MongoDB.Driver;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Validation;
using System.Configuration;

namespace ApiAssignment
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("ApiAssignment", typeof(CarService).Assembly) { }

        public override void Configure(Container container)
        {
            //Enabling DebugMode enables the stack trace of exceptions in Response
            SetConfig(new HostConfig { DebugMode = false });

            //Register all the request validator in the accesmbly
            container.RegisterValidators(typeof(QueryCarValidator).Assembly);
            var mongoDatabase = new MongoClient(ConfigurationManager.AppSettings.Get("mongo:ConnectionString"))
                            .GetDatabase(ConfigurationManager.AppSettings.Get("mongo:DatabaseName"));

            container.AddSingleton<IMongoDatabase>(mongoDatabase);
            container.RegisterAs<CarDbService, ICarDbService>();

            //Config. Validation for Request Models
            Plugins.Add(new ValidationFeature());
            Plugins.Add(new SwaggerFeature());
        }
    }
}