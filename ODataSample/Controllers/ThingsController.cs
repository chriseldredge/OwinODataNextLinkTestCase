using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;

namespace ODataTest.Controllers
{
    public class ThingsController : EntitySetController<Thing, string>
    {
        private static readonly List<Thing> _things;

        static ThingsController()
        {
            _things = new List<Thing>();
            for (var i = 0; i < 1111; i++)
            {
                _things.Add(new Thing {Id="Thing" + i});
            }
        }

        public override IQueryable<Thing> Get()
        {
            return _things.AsQueryable();
        }

        protected override Thing GetEntityByKey(string key)
        {
            return _things.SingleOrDefault(t => t.Id == key);
        }

        [EnableQuery(PageSize = 4)]
        [HttpPost]
        public IEnumerable<Thing> FindRelated([FromODataUri] string key)
        {
            return _things;
        }
    }
}