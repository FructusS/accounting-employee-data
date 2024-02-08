namespace AccountingEmployeeData.Desktop.ViewModels;

public abstract class BaseFormViewModel : BaseViewModel
{
    public string? ErrorMessage
    {
        get { return _errorMessage; }
        set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    public bool HasError
    {
        get { return _hasError; }
        set
        {
            _hasError = value;
            OnPropertyChanged();
        }
    }

    private bool _hasError;
    private string _errorMessage;

    public BaseFormViewModel()
    {
        
    }
}