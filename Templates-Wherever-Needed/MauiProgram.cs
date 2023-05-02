using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Templates_Wherever_Needed.Views;
using Templates_Wherever_Needed.ViewModels;

namespace Templates_Wherever_Needed;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>().UseMauiCommunityToolkit().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("ChaoZiSheJiYingJianFan.ttf", "ChaoZiSheJiYingJianFan");
                fonts.AddFont("YeZiGongChangChuanQiuShaXingKai.ttf", "YeZiGongChangChuanQiuShaXingKai");
            });
        builder.Services.AddScoped<AboutPage,AboutPageViewModel>();
        builder.Services.AddScoped<MainPage,MainPageViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
