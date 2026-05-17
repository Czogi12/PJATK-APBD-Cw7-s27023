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
                  
                  opt.HasKey(ci => ci.Id);
                  
                  opt.Property(ci => ci.Abbreviation).HasColumnType("nvarchar").HasMaxLength(30);
                  opt.Property(ci => ci.Name).HasColumnType("nvarchar").HasMaxLength(150);
            });
      }

}