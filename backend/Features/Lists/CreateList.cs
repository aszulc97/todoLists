using Api.Database;
using Api.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Lists;

public class CreateList : ListsControllerBase
{
    private readonly ListsContext _database;

    public CreateList(ListsContext database)
    {
        _database = database;
    }

    [HttpPost(Name = "CreateList")]
    public async Task<Guid> Create(
        [FromBody] Guid ownerId,
        [FromBody] string name
    )
    {
        var owner = _database.Users.Single(u => u.Id == ownerId);
        var list = new ListRecord
        {
            Name = name,
            Owner = owner
        };
        _database.Lists.Add(list);
        await _database.SaveChangesAsync();
        return list.Id;
    }
}