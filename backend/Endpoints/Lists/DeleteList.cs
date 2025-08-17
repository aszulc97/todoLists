using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Lists;

public class DeleteList : ListsControllerBase
{
    private readonly ListsContext _database;

    public DeleteList(ListsContext database)
    {
        _database = database;
    }

    [HttpDelete("{listId:guid}", Name = "DeleteList")]
    public async Task Delete(
        [FromRoute] Guid listId)

    {
        var list = _database.Lists.SingleOrDefault(l => l.Id == listId);
        if (list == null)
            throw new Exception("List not found");
        
        _database.Lists.Remove(list);
        await _database.SaveChangesAsync();
    }
}