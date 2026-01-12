namespace TripPlanner.Pages;

public partial class NewVacationPage : ContentPage
{
	public NewVacationPage(NewVacationPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}