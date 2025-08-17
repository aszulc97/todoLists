using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Endpoints.Lists;

public class GetLists : ListsControllerBase
{
    private readonly ListsContext _database;

    public GetLists(ListsContext database)
    {
        _database = database;
    }

    [HttpGet("user/{userId:guid}")]
    public List<ListRecord> Get(
        [FromRoute] Guid userId)
    {
        var user = _database.Users.Include(u => u.Lists).Single(u => u.Id == userId);
        return user.Lists;
    }
}