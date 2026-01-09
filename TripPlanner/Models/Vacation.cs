using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models;

public partial class Vacation : INotifyPropertyChanged
{
    [Bindable(false)]
    public long ID 
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(ID));
        }
    }

    [DataType(DataType.Text)]
    [Required]
    [MinLength(5)]
    public string Name 
    {
        get => field ?? string.Empty;
        set
        {
            //if (string.IsNullOrEmpty(value))
            //    throw new ArgumentException("Name cannot be null or empty.");

            field = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    [DataType(DataType.Date)]
    [Required]
    public DateTimeOffset StartDate 
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(StartDate));
        }
    }

    [DataType(DataType.Date)]
    [Required]
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
