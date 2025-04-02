using Microsoft.EntityFrameworkCore;
using MyResource.Core.Palettes.Models;
using MyResource.Core.ThoughtCatcher.Models;

namespace MyResource.Data;
public class MyResourceContext : DbContext
{
    public MyResourceContext(DbContextOptions<MyResourceContext> options)
        : base(options) { }

    public DbSet<Thought> Thoughts { get; set; }
    public DbSet<Palette> Palettes { get; set; }

}

