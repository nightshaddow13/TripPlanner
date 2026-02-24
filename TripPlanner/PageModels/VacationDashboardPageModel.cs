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

    [ObservableProperty]
    private bool _hasVacations = true;

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
        else
        {
            // No vacation ID provided, load the first upcoming vacation
            await LoadFirstUpcomingVacationAsync();
        }
    }

    private async Task LoadVacationAsync(long id)
    {
        try
        {
            var vacations = await _repo.GetAllAsync();
            CurrentVacation = vacations.FirstOrDefault(v => v.ID == id);
            HasVacations = vacations.Any();
        }
        catch (Exception)
        {
            // Handle error
            HasVacations = false;
        }
    }

    private async Task LoadFirstUpcomingVacationAsync()
    {
        try
        {
            var vacations = await _repo.GetAllAsync();
            var today = DateTimeOffset.Now.Date;
            
            if (vacations.Any())
            {
                // Load the first upcoming vacation (soonest by start date)
                CurrentVacation = vacations
                    .Where(v => v.StartDate.Date >= today)
                    .OrderBy(v => v.StartDate)
                    .FirstOrDefault();
                
                VacationId = CurrentVacation?.ID ?? 0;
                HasVacations = CurrentVacation != null;
            }
            else
            {
                HasVacations = false;
            }
        }
        catch (Exception)
        {
            // Handle error
            HasVacations = false;
        }
    }

    public async Task InitializeAsync()
    {
        await LoadFirstUpcomingVacationAsync();
    }
}