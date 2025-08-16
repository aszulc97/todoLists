using Api.Database;
using Api.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Lists;

public class GetListById : ListsControllerBase
{
    private readonly ListsContext _database;

    public GetListById(ListsContext database)
    {
        _database = database;
    }

    [HttpGet("{listId:guid}", Name = "GetListsForUser")]
    public ListRecord Get(
        [FromRoute] Guid listId)
    {
        var list = _database.Lists.Single(l => l.Id == listId);
        return list;
    }
}