namespace Заявки_на_доработку_ПО.Classes
{
    using Microsoft.EntityFrameworkCore;

    public class SoftwareTicketsContext : DbContext
    {
        public SoftwareTicketsContext(DbContextOptions<SoftwareTicketsContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Software> Software { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.ПО)
                .WithMany(b => b.Заявки)
                .HasForeignKey(p => p.IdПО);

           
            modelBuilder.Entity<Ticket>().ToTable("Заявки");
            modelBuilder.Entity<Software>().ToTable("ПО");
        }
    }

}
