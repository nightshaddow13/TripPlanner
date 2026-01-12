using TripPlanner.Models;

namespace TripPlanner.Data;

public interface IVacationRepository
{
    Task SaveAsync(Vacation vacation);
}
