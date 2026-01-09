using Syncfusion.Maui.Inputs;
using System.Windows.Input;
using TripPlanner.Models;
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
            await Navigation.PushAsync(new NewVacationPage());
    }
}