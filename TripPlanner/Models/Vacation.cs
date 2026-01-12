using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models;

[Table("Vacations")]
public class Vacation
{
    [PrimaryKey, AutoIncrement]
    [Bindable(false)]
    public long ID { get; set; }

    [DataType(DataType.Text)]
    [Required]
    [MinLength(5)]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTimeOffset StartDate { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTimeOffset EndDate { get; set; }
}
