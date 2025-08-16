using Api.Database;
using Api.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Lists;

[ApiController]
[Route("api/lists")]
public class GetLists : ControllerBase
{
    private readonly ListsContext _database;

    public GetLists(ListsContext database)
    {
        _database = database;
    }

    [HttpGet(Name = "GetListsForUser")]
    public async Task<List<ListRecord>> Get(
        [FromBody] Guid userId)
    {
        return [];
    }
}