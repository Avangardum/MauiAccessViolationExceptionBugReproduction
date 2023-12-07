namespace CSharpSandbox.Maui.ToDoList.Mvp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(AddToDoItemView), typeof(AddToDoItemView));
    }
}