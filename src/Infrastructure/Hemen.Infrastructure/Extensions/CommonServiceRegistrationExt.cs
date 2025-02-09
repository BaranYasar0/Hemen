using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hemen.Infrastructure.Extensions;
public static class CommonServiceRegistrationExt {

    public static IServiceCollection AddCommonServices(this IServiceCollection services, Type assembly) {
        services.AddHttpContextAccessor();
        services.AddMediatR(conf => {
            conf.RegisterServicesFromAssemblyContaining(assembly);
        });

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);

        return services;
    }
}
