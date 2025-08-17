using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.ListItems;

public class UpdateListItemTitle : ListItemsControllerBase
{
    private readonly ListsContext _database;

    public UpdateListItemTitle(ListsContext database)
    {
        _database = database;
    }

    [HttpPut("{listItemId:guid}/title")]
    public async Task Update(
        [FromRoute] Guid listItemId,
        [FromBody] string title
    )
    {
        var listItem = _database.ListItems.SingleOrDefault(li => li.Id == listItemId);
        if (listItem == null)
            throw new Exception("List item not found");
        listItem.Title = title;
        await _database.SaveChangesAsync();
    }
}