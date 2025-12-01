using TripPlanner.Models;
using TripPlanner.PageModels;

namespace TripPlanner.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}