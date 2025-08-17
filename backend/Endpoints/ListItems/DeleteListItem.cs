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
        var listItem = _database.ListItems.SingleOrDefault(li => li.Id == listItemId);
        if (listItem == null)
            throw new Exception("List item not found");
        _database.ListItems.Remove(listItem);
        await _database.SaveChangesAsync();
    }
}