using TripPlanner.Models;

namespace TripPlanner.PageModels;

public class NewVacationPageModel
{
    public Vacation Vacation { get; set; }

    public NewVacationPageModel()
    {
        Vacation = new();
    }
}
