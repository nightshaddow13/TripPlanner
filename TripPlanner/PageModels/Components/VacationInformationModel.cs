namespace TripPlanner.PageModels.Components;

public class VacationInformationModel
{
    public long ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset StartDate { get; set; }

    public VacationInformationModel(long id, string name, DateTimeOffset startDate)
    {
        ID = id;
        Name = name;
        StartDate = startDate;
    }

    public VacationInformationModel()
    {
        
    }
}
