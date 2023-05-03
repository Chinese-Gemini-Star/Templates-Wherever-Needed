using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using Templates_Wherever_Needed.ViewModels;

namespace Templates_Wherever_Needed.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();
        BindingContext = mainPageViewModel;
        mainPageViewModel.Init();
    }
}

