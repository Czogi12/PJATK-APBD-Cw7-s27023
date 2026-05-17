using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s27023.Models;

namespace PJATK_APBD_Cw7_s27023.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<PC> PCs { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ComponentType>(opt =>
        {
            opt.ToTable("ComponentTypes");

            opt.Property(ct => ct.Abbreviation).HasColumnType("nvarchar").HasMaxLength(30);
            opt.Property(ct => ct.Name).HasColumnType("nvarchar").HasMaxLength(150);
        });

        modelBuilder.Entity<Component>(opt =>
        {
            opt.ToTable("Components");

            opt.HasKey(c => c.Code);

            opt.Property(c => c.Code).HasColumnType("char").HasMaxLength(10);
            opt.Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(300);

            opt.HasOne(c => c.ComponentType).WithMany(c => c.Components).HasForeignKey(c => c.ComponentTypesId);
            opt.HasOne(c => c.ComponentManufacturer).WithMany(c => c.Components)
                .HasForeignKey(c => c.ComponentManufacturersId);
        });

        modelBuilder.Entity<ComponentManufacturer>(opt =>
        {
            opt.ToTable("ComponentManufacturers");

            opt.Property(cm => cm.Abbreviation).HasColumnType("nvarchar").HasMaxLength(30);
            opt.Property(cm => cm.FullName).HasColumnType("nvarchar").HasMaxLength(300);
            opt.Property(cm => cm.FoundationDate).HasColumnType("date");
        });

        modelBuilder.Entity<PCComponent>(opt =>
        {
            opt.ToTable("PCComponents");

            opt.HasKey(pcc => new { pcc.PCId, pcc.ComponentCode });

            opt.Property(pcc => pcc.ComponentCode).HasColumnType("char").HasMaxLength(10);

            opt.HasOne(pcc => pcc.Component).WithMany(c => c.PCComponents).HasForeignKey(pcc => pcc.ComponentCode);
            opt.HasOne(pcc => pcc.Pc).WithMany(pc => pc.PCComponents).HasForeignKey(pcc => pcc.PCId);
        });

        modelBuilder.Entity<PC>(opt =>
        {
            opt.ToTable("PCs");

            opt.Property(pc => pc.Name).HasColumnType("nvarchar").HasMaxLength(50);
            opt.Property(pc => pc.Weight).HasColumnType("float(5)");
            opt.Property(pc => pc.CreatedAt).HasColumnType("datetime");
        });


        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        );

        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer
            {
                Id = 1, Abbreviation = "INTC", FullName = "Intel Corporation",
                FoundationDate = new DateOnly(1968, 7, 18)
            },
            new ComponentManufacturer
            {
                Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices, Inc.",
                FoundationDate = new DateOnly(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 3, Abbreviation = "NVDA", FullName = "NVIDIA Corporation",
                FoundationDate = new DateOnly(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 4, Abbreviation = "CORS", FullName = "Corsair Memory, Inc.",
                FoundationDate = new DateOnly(1994, 1, 1)
            }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component
            {
                Code = "CPU-I9-13K", Name = "Intel Core i9-13900K",
                Description = "24-core, 32-thread desktop CPU, 5.8 GHz boost",
                ComponentTypesId = 1, ComponentManufacturersId = 1
            },
            new Component
            {
                Code = "CPU-R9-79X", Name = "AMD Ryzen 9 7950X",
                Description = "16-core, 32-thread desktop CPU, 5.7 GHz boost",
                ComponentTypesId = 1, ComponentManufacturersId = 2
            },
            new Component
            {
                Code = "GPU-RTX409", Name = "NVIDIA GeForce RTX 4090",
                Description = "Flagship GPU with 24 GB GDDR6X memory",
                ComponentTypesId = 2, ComponentManufacturersId = 3
            },
            new Component
            {
                Code = "GPU-RX79XT", Name = "AMD Radeon RX 7900 XTX",
                Description = "High-end GPU with 24 GB GDDR6 memory",
                ComponentTypesId = 2, ComponentManufacturersId = 2
            },
            new Component
            {
                Code = "RAM-CV032G", Name = "Corsair Vengeance DDR5-6000 32GB",
                Description = "2x16GB DDR5 RGB memory kit",
                ComponentTypesId = 3, ComponentManufacturersId = 4
            }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC
            {
                Id = 1, Name = "Gaming Beast X", Weight = 12.5, Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5
            },
            new PC
            {
                Id = 2, Name = "Office Mini Pro", Weight = 4.2, Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12
            },
            new PC
            {
                Id = 3, Name = "Workstation Elite", Weight = 18.0, Warranty = 60,
                CreatedAt = new DateTime(2026, 3, 20, 10, 15, 0), Stock = 3
            }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "CPU-I9-13K", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU-RTX409", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RAM-CV032G", Amount = 2 },
            new PCComponent { PCId = 2, ComponentCode = "CPU-R9-79X", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "RAM-CV032G", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "CPU-I9-13K", Amount = 2 },
            new PCComponent { PCId = 3, ComponentCode = "GPU-RX79XT", Amount = 1 }
        );
    }
}