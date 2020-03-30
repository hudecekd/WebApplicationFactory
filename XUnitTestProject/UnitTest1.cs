using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TestWebApplication;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var factory = new WebApplicationFactory<TestWebApplication.Startup>();

            factory = factory.WithWebHostBuilder(builder =>
            {
                // Set same environment for SUT as is configured for test project.
                builder.UseEnvironment("Testing");
            });

            var client = factory.CreateClient(); // StartupTesting constructor is called twice.

            var person = new PersonDto();
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(person), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/persons", content);
        }
    }
}
