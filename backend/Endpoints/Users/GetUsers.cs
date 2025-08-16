using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Users;

[ApiController]
[Route("api/users")]
public class GetUsers : ControllerBase
{
    private readonly ListsContext _database;

    public GetUsers(ListsContext database)
    {
        _database = database;
    }

    [HttpGet(Name = "GetUsers")]
    public List<UserRecord> Get()
    {
        var users = _database.Users.ToList();
        return users;
    }
}