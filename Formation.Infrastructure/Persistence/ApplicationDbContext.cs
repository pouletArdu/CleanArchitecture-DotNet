namespace Formation.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Author>()
            .Property(e => e.gender)
            .HasConversion(
                v => v.ToString(),
                v => (Gender)Enum.Parse(typeof(Gender), v));
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreationDate = DateTime.Now;
                    entry.Entity.ModificationDate = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModificationDate = DateTime.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}
