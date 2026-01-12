namespace TripPlanner.Pages;

public partial class NewVacationPage : ContentPage
{
	private readonly NewVacationPageModel _model;

	public NewVacationPage(NewVacationPageModel model)
	{
		InitializeComponent();
		_model = model;
		BindingContext = _model;
	}

    private void OnSaveClicked(object sender, EventArgs e)
    {
		var isValid = dataForm.Validate();

		if (isValid)
			_model.SubmitCmd.Execute(_model.Vacation);
    }
}