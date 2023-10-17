using Core.Interfaces.ISecurityService;
using Microsoft.Net.Http.Headers;

namespace APIs.Middlewares
{
    public class TokenDecryptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;
        public TokenDecryptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            _logger = loggerFactory.CreateLogger<TokenDecryptionMiddleware>();
        }

        public async Task Invoke(HttpContext context, ISecurityService securityService)
        {
            var accessToken = context.Request.Headers[HeaderNames.Authorization];

            if (!string.IsNullOrEmpty(accessToken.ToString()))
            {
                //bearer token
                var tokenData = accessToken.ToString().Split(' ');
                var token = securityService.DecryptCipherText(tokenData[1]);

                context.Request.Headers[HeaderNames.Authorization] = tokenData[0] + ' ' + token;
            }

            await next(context);

        }


    }
}
