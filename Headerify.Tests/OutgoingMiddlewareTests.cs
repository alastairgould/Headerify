using System.Net.Http;
using System.Threading.Tasks;
using Headerify.TestServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace Headerify.Tests
{
    public class OutgoingMiddlewareTests : IClassFixture<WebApplicationFactory<Headerify.TestServer.Startup>>
    {
        private readonly WebApplicationFactory<Headerify.TestServer.Startup> _factory;
        private readonly CaptureHeader captureHeader;
        private const string TestHeaderName = "TestHeader";

        public OutgoingMiddlewareTests(WebApplicationFactory<Headerify.TestServer.Startup> factory)
        {
            captureHeader = new CaptureHeader(TestHeaderName);

            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<CaptureHeader>(captureHeader);
                });
            });
        }

        [Fact]
        public async Task Given_A_HttpClient_With_Bearer_Token_Middlewear_When_The_Request_Is_Made_Then_The_Server_Should_Receive_A_Authorization_Header()
        {
            const string testHeaderValue = "TestValue";

            var client = CreateClient(new HeaderifyOptions
            {
                HeaderName = TestHeaderName,
                HeaderValue = testHeaderValue
            });

            await client.GetAsync("api/test");

            Assert.Single(captureHeader.LastValue, testHeaderValue);
        }

        private HttpClient CreateClient(HeaderifyOptions options)
        {
            var authMiddleware = new HeaderifyDelgateHandler(options);
            return _factory.CreateDefaultClient(authMiddleware);
        }
    }
}