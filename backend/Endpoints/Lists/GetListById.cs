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
    public ListDto GetList(
        [FromRoute] Guid listId)
    {
        var list = _database.Lists.Include(l => l.Items).SingleOrDefault(l => l.Id == listId);
        if  (list == null)
            throw new Exception("List not found");
        return new ListDto(
            list.Id,
            list.Items.Select(li => new ListItemDto(
                li.Id,
                li.Title,
                li.Status
            ))
        );
    }

    public new record ListDto(Guid ListId, IEnumerable<ListItemDto> ListItems);

    public new record ListItemDto(Guid ListItemId, string Title, ListItemStatus Status);
}