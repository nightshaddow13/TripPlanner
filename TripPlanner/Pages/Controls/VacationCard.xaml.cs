using CommunityToolkit.Maui;

namespace TripPlanner.Pages.Controls;

public partial class VacationCard : ContentView
{
	public static readonly BindableProperty IsSelectedProperty =
		BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(ContentView), propertyChanged: OnIsSelectedChanged);

	public bool IsSelected
	{
		get => (bool)GetValue(IsSelectedProperty);
		set => SetValue(IsSelectedProperty, value);
	}

	private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is VacationCard vacationCard && newValue is bool isSelected)
		{
			vacationCard.UpdateBorderColor(isSelected);
		}
    }

    public VacationCard()
	{
		InitializeComponent();

		UpdateBorderColor(false);
	}

	private void UpdateBorderColor(bool isSelected)
	{
		Border border = (Border)Content;
		border.Stroke = isSelected ? Colors.Orange : Colors.Transparent;
		border.Shadow.Brush = isSelected ? Colors.Orange : Colors.Transparent;
    }
}