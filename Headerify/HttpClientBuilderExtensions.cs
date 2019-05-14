using System;
using Microsoft.Extensions.DependencyInjection;

namespace Headerify
{
    public static class HttpClientBuilderExtensions
    {
        public static IHttpClientBuilder AddHeader(this IHttpClientBuilder builder, Action<HeaderifyOptions> configureHeaderify)
        {
            builder.AddHttpMessageHandler(serviceProvider =>
            {
                var options = new HeaderifyOptions();
                configureHeaderify.Invoke(options);
                return new HeaderifyDelgateHandler(options);
            });

            return builder;
        }
    }
}