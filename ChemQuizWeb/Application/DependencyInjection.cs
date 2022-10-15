using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Services.Implementations;
using ChemQuizWeb.Services;
using Microsoft.Extensions.DependencyInjection;
using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Services;

namespace ChemQuizWeb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IService<Avatar>, AvatarService>();
            services.AddScoped<IService<Category>, CategoryService>();
            services.AddScoped<IGameService, GameService>();

            return services;
        }
    }
}
