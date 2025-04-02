using MyResource.Core.WordSearch.Interfaces;
using MyResource.Core.WordSearch.Logic;
using MyResource.Core.WordSearch.Logic.Grid;
using MyResource.Core.WordSearch.Logic.Locations;


namespace MyResource.API.DependencyInjection
{
    public static class WordSearchDI
    {
        public static IServiceCollection AddWordSearchDI(this IServiceCollection services)
        {
            services.AddScoped<ICreatePuzzle, CreatePuzzle>();

            services.AddScoped<CreateEmptyGrid>();
            services.AddScoped<AssignStartPoint>();
            services.AddScoped<AssignWordCoordinates>();
            services.AddScoped<CheckBoundary>();
            services.AddScoped<FillEmptyGrid>();
            services.AddScoped<SetLocations>();
            services.AddScoped<TryWordPlacement>();

            services.AddScoped<Random>();

            return services;
        }
    }

}
