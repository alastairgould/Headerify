using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Headerify
{
    public class HeaderifyDelgateHandler : DelegatingHandler
    {
        private readonly HeaderifyOptions _headerifyOptions;

        public HeaderifyDelgateHandler(HeaderifyOptions generateToken)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
