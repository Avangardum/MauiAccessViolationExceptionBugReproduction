namespace CSharpSandbox.Maui.ToDoList.Mvp;

public partial class AddToDoItemView : ContentPage
{
    public event EventHandler? AddButtonClicked;
    public event EventHandler? CancelButtonClicked;
    
    public AddToDoItemView(AddToDoItemPresenter presenter)
    {
        InitializeComponent();
        presenter.InjectView(this);
    }

    public string ItemName => _itemNameEditor.Text;

    private void AddButton_OnClicked(object? sender, EventArgs e)
    {
        AddButtonClicked?.Invoke(this, EventArgs.Empty);
    }

    private void CancelButton_OnClicked(object? sender, EventArgs e)
    {
        CancelButtonClicked?.Invoke(this, EventArgs.Empty);
    }
}