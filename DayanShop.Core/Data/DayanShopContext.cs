﻿using DayanShop.Domains.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Core.Data;

public class DayanShopContext : IdentityDbContext<IdentityUser>
{
    public DayanShopContext(DbContextOptions<DayanShopContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ParentCategory> ParentCategories { get; set; }
    public DbSet<ChildCategory> ChildCategories { get; set; }
    public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
