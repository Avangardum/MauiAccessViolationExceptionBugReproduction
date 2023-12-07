namespace CSharpSandbox.Maui.ToDoList.Mvp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);
        window.MinimumHeight = window.MaximumHeight = 500;
        window.MinimumWidth = window.MaximumWidth = 300;
        return window;
    }
}