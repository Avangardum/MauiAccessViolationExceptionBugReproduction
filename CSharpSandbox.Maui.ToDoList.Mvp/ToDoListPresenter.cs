namespace CSharpSandbox.Maui.ToDoList.Mvp;

public class ToDoListPresenter
{
    private readonly ToDoListService _service;
    private ToDoListView _view = null!;
    private bool _isProcessingServiceEvent;

    public ToDoListPresenter(ToDoListService service)
    {
        _service = service;
    }
    
    public void InjectView(ToDoListView view)
    {
        _view = view;
        Initialize();
    }

    private void Initialize()
    {
        _service.ItemsChanged += ServiceOnItemsChanged;
        _view.ItemChanged += ViewOnItemChanged;
        _view.AddButtonClicked += ViewOnAddButtonClicked;
    }

    private void ServiceOnItemsChanged(object? sender, EventArgs e)
    {
        _isProcessingServiceEvent = true;
        _view.SetItems(_service.Items);
        _isProcessingServiceEvent = false;
    }

    private void ViewOnItemChanged(object? sender, ToDoItem item)
    {
        // When we update the view on service event, the view can raise an event that we don't want to process
        // to avoid infinite loop of service updating the view and view updating the service.
        if (_isProcessingServiceEvent) return; 
        _service.UpdateItem(item);
    }

    private void ViewOnAddButtonClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddToDoItemView));
    }
}