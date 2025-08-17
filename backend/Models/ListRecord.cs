using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class ListRecord
{
    public Guid Id { get; set; }

    [MaxLength(150)] public required string Name { get; set; }

    public List<ListItemRecord> Items { get; set; } = [];
    public required Guid OwnerId { get; set; }
}

public class UserRecord
{
    public Guid Id { get; set; }

    [MaxLength(50)] public required string Name { get; set; }

    public List<ListRecord> Lists { get; set; } = [];
}

public class ListItemRecord
{
    public Guid Id { get; set; }

    [MaxLength(500)] public required string Title { get; set; }

    public ListItemStatus Status { get; set; }
    public Guid ListId { get; set; }
}

public enum ListItemStatus
{
    Todo,
    Done
}