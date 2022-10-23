using ChemQuizWeb.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using ChemQuizWeb.Core.Interfaces.Services;
using ChemQuizWeb.Infrastructure.Persistence.Repositories;
using ChemQuizWeb.Core.Interfaces.Repositories;

namespace ChemQuizWeb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGameService, GameService>();
            #endregion
            #region Repositories
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAvatarRepository, AvatarRepository>();
            #endregion

            return services;
        }
    }
}
