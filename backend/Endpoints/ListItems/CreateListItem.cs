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

    [HttpPost]
    public async Task<Guid> Create(
        [FromBody] CreateListItemRequest createListItemRequest
    )
    {
        var listItem = new ListItemRecord
        {
            ListId = createListItemRequest.ListId,
            Title = createListItemRequest.Title,
            Status = ListItemStatus.Todo
        };
        _database.Add(listItem);
        await _database.SaveChangesAsync();
        return listItem.Id;
    }

    public new record CreateListItemRequest(
        Guid ListId,
        string Title
    );
}