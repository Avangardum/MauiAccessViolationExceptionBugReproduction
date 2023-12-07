using Microsoft.Extensions.Logging;

namespace CSharpSandbox.Maui.ToDoList.Mvp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .AddCustomServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder AddCustomServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<ToDoListView>();
        builder.Services.AddSingleton<ToDoListPresenter>();
        builder.Services.AddSingleton<ToDoListService>();
        builder.Services.AddTransient<AddToDoItemView>();
        builder.Services.AddTransient<AddToDoItemPresenter>();
        return builder;
    }
}