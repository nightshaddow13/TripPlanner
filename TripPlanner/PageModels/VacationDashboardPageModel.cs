using CommunityToolkit.Mvvm.ComponentModel;
using TripPlanner.Data;
using TripPlanner.Models;

namespace TripPlanner.PageModels;

public partial class VacationDashboardPageModel : ObservableObject, IQueryAttributable
{
    private readonly IVacationRepository _repo;

    [ObservableProperty]
    private Vacation? _currentVacation;

    [ObservableProperty]
    private long _vacationId;

    public VacationDashboardPageModel(IVacationRepository repo)
    {
        _repo = repo;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("vacationId"))
        {
            long id = 0;

            // Handle both string and int/long types
            if (query["vacationId"] is string stringId)
            {
                long.TryParse(stringId, out id);
            }
            else if (query["vacationId"] is long longId)
            {
                id = longId;
            }
            else if (query["vacationId"] is int intId)
            {
                id = intId;
            }

            if (id > 0)
            {
                VacationId = id;
                await LoadVacationAsync(id);
            }
        }
    }

    private async Task LoadVacationAsync(long id)
    {
        try
        {
            var vacations = await _repo.GetAllAsync();
            CurrentVacation = vacations.FirstOrDefault(v => v.ID == id);
        }
        catch (Exception)
        {
            // Handle error - could show message to user
        }
    }
}