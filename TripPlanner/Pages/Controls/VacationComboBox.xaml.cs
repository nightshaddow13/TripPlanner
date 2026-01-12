using Syncfusion.Maui.Inputs;
using TripPlanner.PageModels.Components;

namespace TripPlanner.Pages.Controls;

public partial class VacationComboBox : ContentView
{
	public VacationComboBox()
	{
		InitializeComponent();
	}

	private async void OnSelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
	{
		var comboBox = (SfComboBox) sender;

		if (comboBox.SelectedItem is VacationInformationModel vacation && vacation.ID == 0)
			await Shell.Current.GoToAsync("newVacation");
    }
}