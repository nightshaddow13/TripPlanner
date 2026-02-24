using TripPlanner.PageModels;

namespace TripPlanner.Pages;

public partial class VacationDashboardPage : ContentPage
{
    private readonly VacationDashboardPageModel _viewModel;

    public VacationDashboardPage(VacationDashboardPageModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        // Initialize if no vacation is loaded yet
        if (_viewModel.CurrentVacation == null)
        {
            await _viewModel.InitializeAsync();
        }
    }
}