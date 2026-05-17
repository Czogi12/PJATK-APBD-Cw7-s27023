using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s27023.Models;

namespace PJATK_APBD_Cw7_s27023.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
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
            opt.HasOne(c => c.ComponentManufacturer).WithMany(c => c.Components).HasForeignKey(c => c.ComponentManufacturersId);
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
    }
}