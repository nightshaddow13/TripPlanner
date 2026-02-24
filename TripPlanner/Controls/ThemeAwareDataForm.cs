using Syncfusion.Maui.DataForm;

namespace TripPlanner.Controls;

public partial class ThemeAwareDataForm : SfDataForm
{
    public ThemeAwareDataForm()
    {
        GenerateDataFormItem += OnGenerateDataFormItem;
        
        if (Application.Current != null)
        {
            Application.Current.RequestedThemeChanged += OnThemeChanged;
        }
    }

    private void OnGenerateDataFormItem(object? sender, GenerateDataFormItemEventArgs e)
    {
        if (e.DataFormItem != null)
        {
            var textColor = Application.Current?.RequestedTheme == AppTheme.Dark 
                ? Colors.White 
                : Colors.Black;
            
            e.DataFormItem.LabelTextStyle = new DataFormTextStyle { TextColor = textColor };
            e.DataFormItem.EditorTextStyle = new DataFormTextStyle { TextColor = textColor };
        }
    }

    private void OnThemeChanged(object? sender, AppThemeChangedEventArgs e)
    {
        var currentData = DataObject;
        DataObject = default!;
        DataObject = currentData;
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        
        // Unsubscribe when control is disposed
        if (Handler == null && Application.Current != null)
        {
            Application.Current.RequestedThemeChanged -= OnThemeChanged;
        }
    }
}