using System.ComponentModel;

namespace TripPlanner.Models;

public partial class Vacation : INotifyPropertyChanged
{
    public long ID 
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(ID));
        }
    }

    public string Name 
    {
        get => field ?? string.Empty;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or empty.");

            field = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public DateTimeOffset StartDate 
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(StartDate));
        }
    }

    public DateTimeOffset EndDate 
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(EndDate));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
