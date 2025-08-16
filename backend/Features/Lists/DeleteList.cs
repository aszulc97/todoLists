using Api.Database;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Lists;

public class DeleteList : ListsControllerBase
{
    private readonly ListsContext _database;

    public DeleteList(ListsContext database)
    {
        _database = database;
    }
    
    [HttpDelete("{listId:guid}", Name="DeleteList")]
    public async Task Delete(
        [FromRoute] Guid listId)

    {
        var list = _database.Lists.Single(l=>l.Id == listId);
        _database.Lists.Remove(list);
        await _database.SaveChangesAsync();
    }
    
}