using Templates_Wherever_Needed.ViewModels;

namespace Templates_Wherever_Needed.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutPageViewModel aboutPageViewModel)
	{
		InitializeComponent();
        BindingContext = aboutPageViewModel;
    }
}