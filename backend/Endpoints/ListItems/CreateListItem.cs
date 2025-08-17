using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.ListItems;

public class CreateListItem : ListItemsControllerBase
{
    private readonly ListsContext _database;

    public CreateListItem(ListsContext database)
    {
        _database = database;
    }

    /// <summary>
    /// Adds a new item to an existing To do list
    /// </summary>
    [HttpPost]
    public async Task<Guid> Create(
        [FromBody] CreateListItemRequest createListItemRequest
    )
    {
        var list = _database.Lists.SingleOrDefault(l => l.Id == createListItemRequest.ListId);
        if (list == null)
            throw new Exception("List not found");
        var listItem = new ListItemRecord
        {
            ListId = list.Id,
            Title = createListItemRequest.Title,
            Status = ListItemStatus.Todo
        };
        _database.Add(listItem);
        await _database.SaveChangesAsync();
        return listItem.Id;
    }

    public record CreateListItemRequest(
        Guid ListId,
        string Title
    );
}