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
        // Add default "Create New" option
        Vacations.Add(new VacationInformationModel(0, "Create New Vacation", DateTimeOffset.Now));
    }

    public async Task LoadVacationsAsync()
    {
        try
        {
            var vacations = await _repo.GetAllAsync();
            
            // Clear existing items except the "Create New" option
            var createNewOption = Vacations.FirstOrDefault();
            Vacations.Clear();
            
            if (createNewOption != null)
            {
                Vacations.Add(createNewOption);
            }

            // Add vacations from repository
            foreach (var vacation in vacations.OrderBy(x => x.StartDate))
            {
                Vacations.Add(new VacationInformationModel(vacation.ID, vacation.Name, vacation.StartDate));
            }
        }
        catch (Exception)
        {
            // Handle exception - vacations will remain with just the "Create New" option
        }
    }
}
