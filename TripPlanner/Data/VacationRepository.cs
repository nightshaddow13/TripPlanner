using SQLite;
using System.Collections.ObjectModel;
using TripPlanner.Models;

namespace TripPlanner.Data;

public class VacationRepository : IVacationRepository
{
    private readonly SQLiteAsyncConnection _connection;

    public ObservableCollection<Vacation> Vacation { get; set; } = [];

    public VacationRepository(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Vacation>> GetAllAsync()
    {
        return await _connection.Table<Vacation>().ToListAsync();
    }

    public async Task SaveAsync(Vacation vacation)
    {
        await _connection.InsertOrReplaceAsync(vacation);
    }
}
