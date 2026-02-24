using TripPlanner.PageModels;

namespace TripPlanner.Pages;

public partial class VacationDashboardPage : ContentPage
{
    public VacationDashboardPage(VacationDashboardPageModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}