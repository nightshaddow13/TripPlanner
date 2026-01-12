using System.Collections.ObjectModel;

namespace TripPlanner.PageModels.Components;

public class VacationComboBoxModel
{
    public ObservableCollection<VacationInformationModel> Vacations { get; set; } = [];

    //private readonly VacationRepository _repo = new();

    public VacationComboBoxModel()
    {
        // todo: call repository to get vacations
        //Vacations = _repo.Vacation
        //    .OrderBy(x => x.StartDate)
        //    .Select(x => new VacationInformationModel(x.ID, x.Name, x.StartDate)).ToObservableCollection();
        Vacations = [new(0, "Create New Vacation", DateTimeOffset.Now)];
    }
}
