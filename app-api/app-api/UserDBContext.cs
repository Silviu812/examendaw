using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Utilizatori { get; set; }
    public DbSet<Comanda> Comenzi { get; set; }
    public DbSet<Produs> Produse { get; set; }
    public DbSet<ProdusComanda> ProduseComanda { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProdusComanda>()
            .HasKey(pc => new { pc.ComandaId, pc.ProdusId });

        // Alte configurări necesare
    }
}
