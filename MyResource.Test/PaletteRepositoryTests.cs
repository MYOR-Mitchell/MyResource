using Microsoft.EntityFrameworkCore;
using MyResource.Data;
using MyResource.Data.Repositories;
using MyResource.Core.Palettes.Models;

public class PaletteRepositoryTests
{
    [Fact]
    public async Task AddGetDeleteGet_Series()
    {
        var options = new DbContextOptionsBuilder<MyResourceContext>()
            .UseInMemoryDatabase("PaletteWorkflowDb")
            .Options;

        using var context = new MyResourceContext(options);
        var repo = new PaletteRepository(context);

        var palette = new Palette {
            BaseClr = "#111",
            SectionClr = "#222",
            TextClr = "#333",
            SecondaryTextClr = "#444",
            AccentClr = "#555",
            LineClr = "#666",
            HoverClr = "#777",
            ShadowClr = "#888"
        };
        await repo.AddPaletteAsync(palette);

        var result = await repo.GetRandomPaletteAsync();
        Assert.NotNull(result);
        Assert.Equal("#111", result.BaseClr);

        var deleted = await repo.DeletePaletteAsync(result.PaletteId);
        Assert.True(deleted);

        var afterDelete = await repo.GetRandomPaletteAsync();
        Assert.Null(afterDelete);
    }


}