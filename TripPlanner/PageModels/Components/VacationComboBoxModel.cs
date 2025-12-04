using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using TripPlanner.Models;

namespace TripPlanner.PageModels.Components;

public class VacationComboBoxModel
{
    public ObservableCollection<VacationInformationModel> Vacations { get; set; } = [];

    private readonly VacationRepository _repo = new();

    public VacationComboBoxModel()
    {
        Vacations = _repo.Vacation
            .OrderBy(x => x.StartDate)
            .Select(x => new VacationInformationModel(x.ID, x.Name, x.StartDate)).ToObservableCollection();
        Vacations.Add(new(0, "Create New Vacation", DateTimeOffset.Now));
    }
}
