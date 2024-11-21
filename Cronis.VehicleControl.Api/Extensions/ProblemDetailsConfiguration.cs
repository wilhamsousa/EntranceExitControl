using Hellang.Middleware.ProblemDetails;

namespace Cronis.VehicleControl.Api.Extensions
{
    public static partial class ProblemDetailsConfiguration
    {
        public static void AddProblemDetailsResponse(this IServiceCollection services)
        {
            services.AddProblemDetails(options =>
            {
                options.IncludeExceptionDetails = (ctx, ex) =>
                {
                    var env = ctx.RequestServices.GetRequireService<IHostEnvironment>();
                    return env.IsDevelopment() || env.IsStaging();
                };
            })
            .AddProblemDetailsConventions();
        }
    }
}
