using Microsoft.AspNetCore.Builder;

namespace Hemen.Infrastructure.Exceptions;
public static class GlobalExceptionHandlerRegistrationExt {
    public static IApplicationBuilder UseRequestCulture(
        this IApplicationBuilder builder) {
        return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}
