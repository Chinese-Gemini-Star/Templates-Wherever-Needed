using Templates_Wherever_Needed.ViewModels;

namespace Templates_Wherever_Needed.Views;

public partial class TemplatePage : ContentPage
{
	public TemplatePage(TemplatePageViewModel templatePageViewModel)
	{
		InitializeComponent();
		BindingContext = templatePageViewModel;
    }
}