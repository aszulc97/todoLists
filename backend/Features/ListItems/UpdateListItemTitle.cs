using Api.Database;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.ListItems;

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
        //ensure user is allowed to do it
        var listItem = _database.ListItems.Single(li=>li.Id ==  listItemId);
        listItem.Title = title;
        await _database.SaveChangesAsync();
    }

}