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
        GenerateVacation();
    }

    private void GenerateVacation()
    {
        Vacation =
        [
            new Vacation
            {
                ID = 1,
                Name = "Summer Trip to Italy",
                StartDate = new DateTimeOffset(new DateTime(2024, 6, 15)),
                EndDate = new DateTimeOffset(new DateTime(2024, 6, 30))
            },
            new Vacation
            {
                ID = 2,
                Name = "Winter Skiing in Switzerland",
                StartDate = new DateTimeOffset(new DateTime(2024, 12, 20)),
                EndDate = new DateTimeOffset(new DateTime(2025, 1, 5))
            },
            new Vacation
            {
                ID = 3,
                Name = "Spring Break in Japan",
                StartDate = new DateTimeOffset(new DateTime(2024, 3, 10)),
                EndDate = new DateTimeOffset(new DateTime(2024, 3, 20))
            }
        ];
    }

    public async Task SaveAsync(Vacation vacation)
    {
        await _connection.InsertOrReplaceAsync(vacation);
    }
}
