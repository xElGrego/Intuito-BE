using intuito.application.interfaces.services;
using intuito.application.services;
using Microsoft.Extensions.DependencyInjection;
 

namespace veterinaria.yara.application.ioc
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, InfoCustomerRepository>();
            services.AddScoped<IMovieRepository, InfoMovieRepository>();
            services.AddScoped<IRoomRepository, InfoRoomRepository>();
            services.AddScoped<ISeatRepository, InfoSeatRepository>();
            services.AddScoped<IBilboardRepository, InfoBillboardRepository>();
            services.AddScoped<IBookingRepository, InfoBookingRepository>();
            services.AddScoped<IGreeterRepository, InfoGreeterRepository>();
            services.AddScoped<IUserRepository, InfoUserRepository>();
            return services;
        }
    }
}
