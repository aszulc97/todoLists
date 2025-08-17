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
        var listItem = _database.ListItems.SingleOrDefault(li => li.Id == listItemId);
        if (listItem == null)
            throw new Exception("List item not found");
        var isCorrectStatus = Enum.IsDefined(typeof(ListItemStatus), status);
        if (!isCorrectStatus)
            throw new Exception($"Status '{status}' is not defined");
        listItem.Status = status;
        await _database.SaveChangesAsync();
    }
}