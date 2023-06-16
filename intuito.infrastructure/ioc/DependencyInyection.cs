using intuito.application.interfaces.repositories;
using intuito.infrastructure.data.repositories;
using intuito.infrastructure.data.repositories.billboard;
using intuito.infrastructure.data.repositories.booking;
using intuito.infrastructure.data.repositories.movie;
using intuito.infrastructure.data.repositories.room;
using intuito.infrastructure.data.repositories.seat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Reflection;

namespace intuito.infrastructure.ioc
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var builderConnection = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));
            var password = configuration.GetConnectionString("Contra");
            builderConnection.Password = password;

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomerRestRepository, CustomerRepository>();
            services.AddScoped<IMovieRestRepository, MovieRepository>();
            services.AddScoped<IRoomRestRepository, RoomRepository>();
            services.AddScoped<ISeatRestRepository, SeatRepository>();
            services.AddScoped<IBillboardRestRepository, BillboardRepository>();
            services.AddScoped<IBookingRestRepository, BookingRepository>();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builderConnection.ConnectionString);
                }, ServiceLifetime.Transient
            );

            return services;

        }
    }
}

