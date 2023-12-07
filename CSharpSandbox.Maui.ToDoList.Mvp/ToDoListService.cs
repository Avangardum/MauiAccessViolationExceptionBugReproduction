using System.Collections.Immutable;

namespace CSharpSandbox.Maui.ToDoList.Mvp;

public class ToDoListService
{
    public event EventHandler? ItemsChanged; 
    
    private readonly List<ToDoItem> _items = new();

    public IReadOnlyList<ToDoItem> Items => _items.Select(i => i with { }).ToImmutableList();

    public void AddItem(ToDoItem item)
    {
        _items.Add(item);
        ItemsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UpdateItem(ToDoItem item)
    {
        var targetItem = _items.Single(i => i.Id == item.Id);
        targetItem.Name = item.Name;
        targetItem.IsDone = item.IsDone;
        ItemsChanged?.Invoke(this, EventArgs.Empty);
    }
}