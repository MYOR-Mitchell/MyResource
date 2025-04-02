using Microsoft.EntityFrameworkCore;
using MyResource.Core.Features.ThoughtCatcher.Models;
using MyResource.Core.Features.Palettes.Models;

public class MyResourceContext : DbContext
{
    public MyResourceContext(DbContextOptions<MyResourceContext> options)
        : base(options) { }

    public DbSet<Thought> Thoughts { get; set; }
    public DbSet<Palette> Palettes { get; set; }

}

