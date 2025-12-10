using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MMABooksEFClasses;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BreweryHomepageEFClasses.Models;

public partial class BitsContext : DbContext
{
    public BitsContext()
    {
    }

    public BitsContext(DbContextOptions<BitsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<AppConfig> AppConfigs { get; set; }

    public virtual DbSet<Style> Styles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    // Set this up to protect my password for my database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = ConfigDB.GetMySqlConnectionString();

        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PRIMARY");

            entity.ToTable("account");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .HasColumnName("contact_name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasColumnName("phone");
            entity.Property(e => e.SalesPersonName)
                .HasMaxLength(100)
                .HasColumnName("sales_person_name");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .HasColumnName("state");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .HasColumnName("zipcode");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("address");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("state");
            entity.Property(e => e.StreetLine1)
                .HasMaxLength(100)
                .HasColumnName("street_line_1");
            entity.Property(e => e.StreetLine2)
                .HasMaxLength(100)
                .HasColumnName("street_line_2");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(50)
                .HasColumnName("zipcode");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.AddressTypeId).HasName("PRIMARY");

            entity.ToTable("address_type");

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.Property(e => e.AddressTypeId).HasColumnName("address_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AppConfig>(entity =>
        {
            entity.HasKey(e => e.BreweryId).HasName("PRIMARY");

            entity.ToTable("app_config");

            entity.Property(e => e.BreweryId)
                .ValueGeneratedNever()
                .HasColumnName("brewery_id");
            entity.Property(e => e.BreweryLogo)
                .HasMaxLength(50)
                .HasColumnName("brewery_logo");
            entity.Property(e => e.BreweryName)
                .HasMaxLength(200)
                .HasColumnName("brewery_name");
            entity.Property(e => e.Color1)
                .HasMaxLength(10)
                .HasColumnName("color_1");
            entity.Property(e => e.Color2)
                .HasMaxLength(10)
                .HasColumnName("color_2");
            entity.Property(e => e.Color3)
                .HasMaxLength(10)
                .HasColumnName("color_3");
            entity.Property(e => e.ColorBlack)
                .HasMaxLength(10)
                .HasColumnName("color_black");
            entity.Property(e => e.ColorWhite)
                .HasMaxLength(10)
                .HasColumnName("color_white");
            entity.Property(e => e.DefaultUnits)
                .HasMaxLength(50)
                .HasDefaultValueSql("'metric'")
                .HasColumnName("default_units");
            entity.Property(e => e.HomePageBackgroundImage)
                .HasMaxLength(50)
                .HasColumnName("home_page_background_image");
            entity.Property(e => e.HomePageText)
                .HasMaxLength(5000)
                .HasColumnName("home_page_text");
        });


        modelBuilder.Entity<Style>(entity =>
        {
            entity.HasKey(e => e.StyleId).HasName("PRIMARY");

            entity.ToTable("style");

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.Property(e => e.StyleId).HasColumnName("style_id");
            entity.Property(e => e.AbvMax).HasColumnName("abv_max");
            entity.Property(e => e.AbvMin).HasColumnName("abv_min");
            entity.Property(e => e.CarbMax).HasColumnName("carb_max");
            entity.Property(e => e.CarbMin).HasColumnName("carb_min");
            entity.Property(e => e.CategoryLetter)
                .HasMaxLength(50)
                .HasColumnName("category_letter");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.CategoryNumber)
                .HasMaxLength(50)
                .HasColumnName("category_number");
            entity.Property(e => e.ColorMax).HasColumnName("color_max");
            entity.Property(e => e.ColorMin).HasColumnName("color_min");
            entity.Property(e => e.Examples)
                .HasMaxLength(2000)
                .HasColumnName("examples");
            entity.Property(e => e.FgMax).HasColumnName("fg_max");
            entity.Property(e => e.FgMin).HasColumnName("fg_min");
            entity.Property(e => e.IbuMax).HasColumnName("ibu_max");
            entity.Property(e => e.IbuMin).HasColumnName("ibu_min");
            entity.Property(e => e.Ingredients)
                .HasMaxLength(2000)
                .HasColumnName("ingredients");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(5000)
                .HasColumnName("notes");
            entity.Property(e => e.OgMax).HasColumnName("og_max");
            entity.Property(e => e.OgMin).HasColumnName("og_min");
            entity.Property(e => e.Profile)
                .HasMaxLength(5000)
                .HasColumnName("profile");
            entity.Property(e => e.StyleGuide)
                .HasMaxLength(50)
                .HasColumnName("style_guide");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("supplier");

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(50)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactFirstName)
                .HasMaxLength(50)
                .HasColumnName("contact_first_name");
            entity.Property(e => e.ContactLastName)
                .HasMaxLength(50)
                .HasColumnName("contact_last_name");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .HasColumnName("note");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .HasColumnName("website");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
