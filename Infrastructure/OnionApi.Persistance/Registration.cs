using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using OnionApi.Persistance.Context;

namespace OnionApi.Persistance
{
    public static class Registration
    {

        public static void AddPersistance(this IServiceCollection services, IConfiguration configuraiton)
        {

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuraiton.GetConnectionString("DefaultConnection")));

        }


    }
}
