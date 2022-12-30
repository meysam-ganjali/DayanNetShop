﻿using DayanShop.Application.FacadePattern.FSDCategory;
using DayanShop.Application.FacadePattern.FSDCategoryAttr;
using DayanShop.Application.FacadePattern.FSDProduct;
using DayanShop.Application.StoreServices.Commands.Category;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DayanShop.Application.IOC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFSDPatternCategory, FsdPatternCategory>();
        services.AddScoped<IFSDCategoryAttribute, FSDCategoryAttribute>();
        services.AddScoped<IFSDProduct, FSDProduct>();
    }
}