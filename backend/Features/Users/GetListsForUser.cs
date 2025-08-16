using Api.Database;
using Api.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Lists;

public class GetListsForUser : ListsControllerBase
{
    private readonly ListsContext _database;

    public GetListsForUser(ListsContext database)
    {
        _database = database;
    }

    [HttpGet("{userId:guid}/lists", Name = "GetListsForUser")]
    public List<ListRecord> Get(
        [FromQuery] Guid userId)
    {
        var lists = _database.Lists.Where(l => l.Owner.Id == userId).ToList();
        return lists;
    }
}