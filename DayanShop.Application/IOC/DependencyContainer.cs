using DayanShop.Application.StoreServices.Commands.Category;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DayanShop.Application.IOC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICreateParentCategory, CreateParentCategory>();
    }
}