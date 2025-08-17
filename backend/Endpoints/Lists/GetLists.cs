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
    public List<SimpleListDto> Get(
        [FromRoute] Guid userId)
    {
        var user = _database.Users.Include(u => u.Lists)
            .Single(u => u.Id == userId);
        return user.Lists.Select(l => new SimpleListDto(
            l.Id,
            l.Name
        )).ToList();
    }

    public record SimpleListDto(Guid Id, string Name);
}