using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Headerify
{
    public class HeaderifyDelgateHandler : DelegatingHandler
    {
        private readonly HeaderifyOptions _headerifyOptions;

        public HeaderifyDelgateHandler(HeaderifyOptions headerifyOptions)
        {
            _headerifyOptions = headerifyOptions;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add(_headerifyOptions.HeaderName, _headerifyOptions.HeaderValue);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
