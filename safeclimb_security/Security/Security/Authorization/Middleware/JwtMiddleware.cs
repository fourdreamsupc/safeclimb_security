using safeclimb_security.Security.Security.Authorization.Handlers.Interfaces;

namespace safeclimb_security.Security.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var customerId = handler.ValidateToken(token);
            //if(customerId != null)
            //{
            //    context.Items["Customers"] = await customerService.GetByIdAsync(customerId.Value);
            //}

            await _next(context);
        }
    }
}