using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;
using TripPlanner.Models;

namespace TripPlanner.PageModels;

public partial class NewVacationPageModel : INotifyPropertyChanged
{
    private readonly IVacationRepository _repo;
    private Vacation _vacation;

    public NewVacationPageModel(IVacationRepository repo)
    {
        _repo = repo;
        _vacation = new();
        SubmitCmd = new RelayCommand(Submit);
        CancelCmd = new RelayCommand(Cancel);
    }

    public Vacation Vacation
    {
        get => _vacation;
        set
        {
            _vacation = value;
            OnPropertyChanged(nameof(Vacation));
        }
    }

    public ICommand SubmitCmd { get; }
    public ICommand CancelCmd { get; }

    private async void Submit()
    {
        try
        {
            await _repo.SaveAsync(Vacation);

            // Navigate to the vacation dashboard with the newly created vacation ID
            await Shell.Current.GoToAsync($"vacationDashboard?vacationId={Vacation.ID}");
        }
        catch (Exception ex)
        {
            //todo: handle exception
        }
    }

    private async void Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
