using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Endpoints.Lists;

public class GetListById : ListsControllerBase
{
    private readonly ListsContext _database;

    public GetListById(ListsContext database)
    {
        _database = database;
    }

    [HttpGet("{listId:guid}")]
    public ListRecord GetList(
        [FromRoute] Guid listId)
    {
        var list = _database.Lists.Include(l=>l.Items).Single(l => l.Id == listId);
        return list;
    }
}