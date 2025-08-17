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

/// <summary>
/// Creates a new To do list with a given user as an owner
/// </summary>
    [HttpPost(Name = "CreateList")]
    public async Task<Guid> Create(
        [FromBody] CreateListRequest request
    )
    {
        var user = _database.Users.SingleOrDefault(u => u.Id == request.OwnerId);
        if (user == null)
            throw new Exception("User not found");

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