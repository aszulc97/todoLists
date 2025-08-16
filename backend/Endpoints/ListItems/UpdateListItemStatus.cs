using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.ListItems;

public class UpdateListItemStatus : ListItemsControllerBase
{
    private readonly ListsContext _database;

    public UpdateListItemStatus(ListsContext database)
    {
        _database = database;
    }

    [HttpPut("{listItemId:guid}/status")]
    public async Task Update(
        [FromRoute] Guid listItemId,
        [FromBody] ListItemStatus status
    )
    {
        //ensure user is allowed to do it
        var listItem = _database.ListItems.Single(li => li.Id == listItemId);
        listItem.Status = status;
        await _database.SaveChangesAsync();
    }
}