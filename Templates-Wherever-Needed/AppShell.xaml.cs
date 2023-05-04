namespace Templates_Wherever_Needed;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Views.TemplatePage),typeof(Views.TemplatePage));
	}
}
