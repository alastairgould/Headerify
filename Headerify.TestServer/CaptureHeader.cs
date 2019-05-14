using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Headerify.TestServer
{
    public class CaptureHeader
    {
        public StringValues LastValue { get; private set; }

        private readonly string _headerToCapture;

        public CaptureHeader(string headerToCapture) => _headerToCapture = headerToCapture;

        public void Capture(HttpRequest request) => LastValue = request.Headers[_headerToCapture];
    }
}