using EmployeesAPI.Middleware;

namespace EmployeesAPI.Extensions
{
    public static class GlobalExceptionHandling
    {
        public static IApplicationBuilder UseGlobalExeptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        }            
    }
}