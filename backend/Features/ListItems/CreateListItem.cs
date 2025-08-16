using Api.Database;
using Api.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.ListItems;

public class CreateListItem : ListItemsControllerBase
{
    private readonly ListsContext _database;

    public CreateListItem(ListsContext database)
    {
        _database = database;
    }

    [HttpPost]
    public async Task<Guid> Create(
        [FromBody] Guid listId,
        [FromBody] string title
    )
    {
        var listItem = new ListItemRecord
        {
            ListId = listId,
            Title = title,
            Status = ListItemStatus.Todo
        };
        _database.Add(listItem);
        await _database.SaveChangesAsync();
        return listItem.Id;
    }
}