using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.ListItems;

public class DeleteListItem : ListItemsControllerBase
{
    private readonly ListsContext _database;

    public DeleteListItem(ListsContext database)
    {
        _database = database;
    }

    [HttpDelete("{listItemId}")]
    public async Task Delete([FromRoute] Guid listItemId)
    {
        var listItem = _database.ListItems.Single(li => li.Id == listItemId);
        _database.ListItems.Remove(listItem);
        await _database.SaveChangesAsync();
    }
}