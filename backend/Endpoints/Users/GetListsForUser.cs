using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Endpoints.Users;

public class GetListsForUser : UsersControllerBase
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
        var user = _database.Users.Include(u => u.Lists).Single(u => u.Id == userId);
        return user.Lists;
    }
}