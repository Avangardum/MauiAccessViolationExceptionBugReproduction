using System.Diagnostics;

namespace CSharpSandbox.Maui.ToDoList.Mvp;

public class AddToDoItemPresenter
{
    private readonly ToDoListService _service;
    private AddToDoItemView _view = null!;

    public AddToDoItemPresenter(ToDoListService service)
    {
        _service = service;
    }

    public void InjectView(AddToDoItemView view)
    {
        _view = view;
        Initialize();
    }
    
    private void Initialize()
    {
        _view.AddButtonClicked += ViewOnAddButtonClicked;
        _view.CancelButtonClicked += ViewOnCancelButtonClicked;
    }

    private void ViewOnAddButtonClicked(object? sender, EventArgs e)
    {
        var item = new ToDoItem { Id = Guid.NewGuid(), Name = _view.ItemName, IsDone = false };
        _service.AddItem(item);
        GoBack();
    }

    private void ViewOnCancelButtonClicked(object? sender, EventArgs e)
    {
        GoBack();
    }

    private void GoBack()
    {
        Shell.Current.Navigation.PopAsync();
    }
}