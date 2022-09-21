using DmsTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Data
{
    public class DmsContext: IdentityDbContext<AppUser>
    {
        public DmsContext() 
        { 
        }
        public DmsContext(DbContextOptions<DmsContext> options) :base(options)
        {  
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
           


            base.OnModelCreating(builder);
        }
    }
}
