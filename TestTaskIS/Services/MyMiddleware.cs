using TestTaskIS.Models;

namespace TestTaskIS.Services
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private MyContext _con;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, MyContext con)
        {
            _con = con;
            string authHeader = context.Request.Headers["userid"];
            if (authHeader != null)
            {

                User user = _con.Users.FirstOrDefault(it => it.id == Guid.Parse(authHeader));
                var s = context.Request.Method;
                if (user != null && user.isValid)
                {
                    if (s == "GET" && user.perms.Contains(Permissions.read) || s == "POST" && user.perms.Contains(Permissions.create))
                    {
                        await _next(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        return;
                    }
                }
                else context.Response.StatusCode = 401; return;

            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 426; //Unauthorized
                return;
            }
        }
    }
}
