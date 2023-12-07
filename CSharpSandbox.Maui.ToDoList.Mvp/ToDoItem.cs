namespace CSharpSandbox.Maui.ToDoList.Mvp;

public record ToDoItem
{
    public required Guid Id { get; init; }
    public required string Name { get; set; }
    public bool IsDone { get; set; }
}