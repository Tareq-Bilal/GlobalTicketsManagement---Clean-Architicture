using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.TicketManagement.Application
{
    public static class ApplicationServiceRegestration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        } 
    }
}
