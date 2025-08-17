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

    /// <summary>
    /// Returns a list of all To do lists for a given userId
    /// </summary>
    [HttpGet("user/{userId:guid}")]
    public List<SimpleListDto> Get(
        [FromRoute] Guid userId)
    {
        var user = _database.Users.Include(u => u.Lists)
            .SingleOrDefault(u => u.Id == userId);
        if (user == null)
            throw new Exception("User not found");
        return user.Lists.Select(l => new SimpleListDto(
            l.Id,
            l.Name
        )).ToList();
    }

    public record SimpleListDto(Guid Id, string Name);
}