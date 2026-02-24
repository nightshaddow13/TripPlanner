using Syncfusion.Maui.Inputs;
using TripPlanner.Data;
using TripPlanner.PageModels.Components;

namespace TripPlanner.Pages.Controls;

public partial class VacationComboBox : ContentView
{
    private VacationComboBoxModel? _viewModel;

    public VacationComboBox()
    {
        InitializeComponent();
        
        // Auto-initialize with repository from DI
        if (Application.Current?.Handler?.MauiContext?.Services != null)
        {
            var repo = Application.Current.Handler.MauiContext.Services.GetService<IVacationRepository>();
            if (repo != null)
            {
                _viewModel = new VacationComboBoxModel(repo);
                BindingContext = _viewModel;
                
                // Load data when control is loaded
                Loaded += OnLoaded;
            }
        }
    }

    private async void OnLoaded(object? sender, EventArgs e)
    {
        Loaded -= OnLoaded; // Unsubscribe to prevent multiple loads
        await LoadDataAsync();
        
        // Select the first vacation after loading
        if (_viewModel?.Vacations.Count > 0)
        {
            comboBox.SelectedIndex = 0;
        }
    }

    public void SetViewModel(VacationComboBoxModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    public async Task LoadDataAsync()
    {
        if (_viewModel != null)
        {
            await _viewModel.LoadVacationsAsync();
        }
    }

    private async void OnSelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        var comboBox = (SfComboBox) sender;

        if (comboBox.SelectedItem is VacationInformationModel vacation)
        {
            if (vacation.ID == 0)
            {
                // Navigate to create new vacation
                await Shell.Current.GoToAsync("newVacation");
            }
            else
            {
                // Navigate to vacation dashboard
                await Shell.Current.GoToAsync($"vacationDashboard?vacationId={vacation.ID}");
            }
        }
    }
}