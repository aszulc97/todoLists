using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Lists;

public class CreateList : ListsControllerBase
{
    private readonly ListsContext _database;

    public CreateList(ListsContext database)
    {
        _database = database;
    }

    [HttpPost(Name = "CreateList")]
    public async Task<Guid> Create(
        [FromBody] CreateListRequest request
    )
    {
        var list = new ListRecord
        {
            Name = request.Name,
            OwnerId = request.OwnerId
        };
        _database.Lists.Add(list);
        await _database.SaveChangesAsync();
        return list.Id;
    }

    public record CreateListRequest(
        Guid OwnerId,
        string Name
    );
}