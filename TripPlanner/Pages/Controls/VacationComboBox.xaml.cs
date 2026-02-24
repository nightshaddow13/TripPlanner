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

        if (comboBox.SelectedItem is VacationInformationModel vacation && vacation.ID == 0)
            await Shell.Current.GoToAsync("newVacation");
    }
}