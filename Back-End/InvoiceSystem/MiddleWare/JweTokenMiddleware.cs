//using BussinesLayer.Interfaces.Token;

//namespace InvoiceSystem.MiddleWare
//{
//    public class JweTokenMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly IServiceProvider _serviceProvider;

//        public JweTokenMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
//        {
//            _next = next;
//            _serviceProvider = serviceProvider;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
//            if (authHeader != null && authHeader.StartsWith("Bearer "))
//            {
//                var token = authHeader.Substring("Bearer ".Length).Trim();
//                if (!string.IsNullOrEmpty(token))
//                {
//                    try
//                    {
//                        // Resolve ITokenService from the current scope
//                        var tokenService = context.RequestServices.GetRequiredService<ITokenService>();

//                        var claimsPrincipal = tokenService.Validate(token, out bool isExpired);
//                        if (!isExpired)
//                        {
//                            context.User = claimsPrincipal;
//                        }
//                    }
//                    catch
//                    {
//                        // optional: handle exception or reject
//                    }
//                }
//            }

//            await _next(context);
//        }
//    }


//}
