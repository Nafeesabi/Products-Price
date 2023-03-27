using Microsoft.EntityFrameworkCore;

namespace Category.Models;

public class WebContext : DbContext
{
    public WebContext(DbContextOptions<WebContext> options)
        : base(options)
    {
    }

    public DbSet<WebItems> WebItems { get; set; } = null!;
}
