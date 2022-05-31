using AutoMapper;
using GeekShopping.ProductApi.Config;
using GeekShopping.ProductApi.Model.Context;
using GeekShopping.ProductApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi
{
    public static class ProductApiServicesRegistration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<PgsqlContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PgsqlConnectionString"), sqloption =>
                {
                    sqloption.EnableRetryOnFailure(
                        10, TimeSpan.FromSeconds(5), null);
                });
            });

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}