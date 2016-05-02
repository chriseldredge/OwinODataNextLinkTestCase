using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ODataSample
{
    [TestFixture]
    class IntegrationTests
    {
        private IDisposable app;

        [TestFixtureSetUp]
        public void StartApp()
        {
            app = WebApp.Start<Startup>("http://localhost:9003/");
        }

        [TestFixtureTearDown]
        public void DisposeApp()
        {
            app.Dispose();
        }

        [Test]
        public async Task Test()
        {
            var res = await new HttpClient().PostAsync("http://localhost:9003/odata/Things(Thing1)/FindRelated()", new StringContent(""));
            var content = await res.Content.ReadAsStringAsync();

            var jObject = JObject.Parse(content);
            var nextLink = jObject["odata.nextLink"].Value<string>();

            Assert.That(nextLink, Is.EqualTo("http://localhost:9003/odata/Things(Thing1)/FindRelated()?$skip=4"));
        }
    }
}
