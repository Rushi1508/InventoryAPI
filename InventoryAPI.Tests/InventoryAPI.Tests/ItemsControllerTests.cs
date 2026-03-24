using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Controllers;
using InventoryAPI.Data;
using InventoryAPI.Models;

namespace InventoryAPI.Tests;

public class ItemsControllerTests
{
    private static AppDbContext GetInMemoryDb()
    {
        var opts = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(opts);
    }

    [Fact]
    public async Task Create_ReturnsCreatedItem()
    {
        var db = GetInMemoryDb();
        var ctrl = new ItemsController(db);
        var dto = new CreateItemDto { Name = "Widget", Quantity = 10 };

        var result = await ctrl.Create(dto);

        var created = Assert.IsType<CreatedAtActionResult>(result.Result);
        var item = Assert.IsType<Item>(created.Value);
        Assert.Equal("Widget", item.Name);
        Assert.Equal(10, item.Quantity);
    }

    [Fact]
    public async Task GetById_NotFound_Returns404()
    {
        var db = GetInMemoryDb();
        var ctrl = new ItemsController(db);

        var result = await ctrl.GetById(999);

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Delete_RemovesItem()
    {
        var db = GetInMemoryDb();
        var ctrl = new ItemsController(db);
        db.Items.Add(new Item { Name = "Temp", Quantity = 1 });
        await db.SaveChangesAsync();

        var result = await ctrl.Delete(1);

        Assert.IsType<NoContentResult>(result);
        Assert.Empty(db.Items);
    }
}