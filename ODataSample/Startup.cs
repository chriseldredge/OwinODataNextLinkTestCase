using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ODataTest;
using Owin;

namespace ODataSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Thing>("Things");

            var action = modelBuilder.Entity<Thing>().Action("FindRelated");
            action.ReturnsCollectionFromEntitySet<Thing>("Things");

            var model = modelBuilder.GetEdmModel();

            configuration.Routes.MapODataServiceRoute("OData", "odata", model);

            app.UseWebApi(configuration);
        }
    }
}
