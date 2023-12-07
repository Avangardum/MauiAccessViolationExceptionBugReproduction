using System.Collections.ObjectModel;

namespace CSharpSandbox.Maui.ToDoList.Mvp;

public partial class ToDoListView : ContentPage
{
    private readonly ObservableCollection<ToDoItem> _items = new();

    public ToDoListView(ToDoListPresenter presenter)
    {
        InitializeComponent();
        presenter.InjectView(this);
        BindingContext = this;
        ItemsView.ItemsSource = _items;
    }

    public event EventHandler<ToDoItem>? ItemChanged;
    public event EventHandler? AddButtonClicked;

    public void SetItems(IEnumerable<ToDoItem> items)
    {
        _items.Clear();
        foreach (var item in items) _items.Add(item);
    }

    private void CheckBox_OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        var checkbox = (CheckBox) sender!;
        var item = (ToDoItem) checkbox.Parent.BindingContext!;
        ItemChanged?.Invoke(this, item);
    }

    private void AddButton_OnClicked(object? sender, EventArgs e)
    {
        AddButtonClicked?.Invoke(this, EventArgs.Empty);
    }
}