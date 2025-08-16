namespace Api.Database.Models;

public class ListRecord
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<ListItemRecord> Items { get; set; } = [];
    public UserRecord Owner { get; set; }
}

public class UserRecord
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}

public class ListItemRecord
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public ListItemStatus Status { get; set; }
    public Guid ListId { get; set; }
}

public enum ListItemStatus
{
    Todo,
    Done
}