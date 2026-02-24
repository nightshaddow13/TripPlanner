using SQLite;
using System.Collections.ObjectModel;
using TripPlanner.Models;

namespace TripPlanner.Data;

public class VacationRepository(SQLiteAsyncConnection connection) : IVacationRepository
{
    public ObservableCollection<Vacation> Vacation { get; set; } = [];

    public event EventHandler<Vacation>? VacationSaved;

    public async Task<IEnumerable<Vacation>> GetAllAsync()
    {
        return await connection.Table<Vacation>().ToListAsync();
    }

    public async Task SaveAsync(Vacation vacation)
    {
        if (vacation.ID == 0)
        {
            // Insert new vacation - SQLite will auto-increment the ID
            await connection.InsertAsync(vacation);
        }
        else
        {
            // Update existing vacation
            await connection.UpdateAsync(vacation);
        }
        VacationSaved?.Invoke(this, vacation);
    }
}
