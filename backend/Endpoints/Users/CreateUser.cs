using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Users;

public class CreateUser : UsersControllerBase
{
    private readonly ListsContext _database;

    public CreateUser(ListsContext database)
    {
        _database = database;
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    [HttpPost]
    public async Task<Guid> Create(
        [FromBody] string name
    )
    {
        var user = new UserRecord
        {
            Name = name
        };
        _database.Users.Add(user);
        await _database.SaveChangesAsync();
        return user.Id;
    }
}