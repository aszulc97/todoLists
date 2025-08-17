using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Users;

public class GetUsers : UsersControllerBase
{
    private readonly ListsContext _database;

    public GetUsers(ListsContext database)
    {
        _database = database;
    }

    [HttpGet(Name = "GetUsers")]
    public List<UserDto> Get()
    {
        var users = _database.Users.ToList();
        return users.Select(u=> new UserDto(u.Id, u.Name)).ToList();
    }
    
    public record UserDto(Guid Id, string Name);
}