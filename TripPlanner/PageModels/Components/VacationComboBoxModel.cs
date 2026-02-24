using System.Collections.ObjectModel;
using TripPlanner.Data;
using TripPlanner.Models;

namespace TripPlanner.PageModels.Components;

public class VacationComboBoxModel
{
    private readonly IVacationRepository _repo;

    public ObservableCollection<VacationInformationModel> Vacations { get; set; } = [];

    public VacationComboBoxModel(IVacationRepository repo)
    {
        _repo = repo;
        
        // Subscribe to vacation saved event
        _repo.VacationSaved += OnVacationSaved;
    }

    private async void OnVacationSaved(object? sender, Vacation vacation)
    {
        // Reload all vacations from database
        await LoadVacationsAsync();
    }

    public async Task LoadVacationsAsync()
    {
        try
        {
            var vacations = await _repo.GetAllAsync();
            var today = DateTimeOffset.Now.Date;
            
            // Clear existing items
            Vacations.Clear();

            // Add upcoming vacations ordered by StartDate ascending (soonest first)
            var upcomingVacations = vacations
                .Where(x => x.StartDate.Date >= today)
                .OrderBy(x => x.StartDate);

            foreach (var vacation in upcomingVacations)
            {
                Vacations.Add(new VacationInformationModel(vacation.ID, vacation.Name, vacation.StartDate));
            }
            
            // Always add "Create New" option at the end
            Vacations.Add(new VacationInformationModel(0, "Create New Vacation", DateTimeOffset.Now));
        }
        catch (Exception)
        {
            // Handle exception - ensure "Create New" option is available
            Vacations.Clear();
            Vacations.Add(new VacationInformationModel(0, "Create New Vacation", DateTimeOffset.Now));
        }
    }
}
