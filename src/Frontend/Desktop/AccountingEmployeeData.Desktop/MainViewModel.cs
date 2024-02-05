using System;
using AccountingEmployeeData.Desktop.Events;
using AccountingEmployeeData.Desktop.ViewModels;
using Prism.Events;

namespace AccountingEmployeeData.Desktop;

public class MainViewModel : BaseViewModel
{
    
    private BaseViewModel _currentPage;
    public BaseViewModel CurrentPage
    {
        get { return _currentPage; }
        set
        {
            _currentPage = value;
            OnPropertyChanged();
        }
    }
    
    public MainViewModel()
    {
        CurrentPage = new EmployeeListViewModel();
    }
}