using Microsoft.EntityFrameworkCore;

public class KitapciContext : DbContext
{
    public KitapciContext(DbContextOptions<KitapciContext> options) : base(options) { }

    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Siparis> Siparisler { get; set; }
    public DbSet<Kategori> Kategoriler { get; set; }
}
