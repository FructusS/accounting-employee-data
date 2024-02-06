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
    
    
    private readonly IEventAggregator _eventAggregator;
    public MainViewModel(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        CurrentPage = new EmployeeListViewModel(_eventAggregator);

        _eventAggregator.GetEvent<NavigateToCreateEmployeeEvent>().Subscribe(NavigateToCreateEmployee);
    }

    public MainViewModel()
    {
        
    }
    private void NavigateToCreateEmployee()
    {
        CurrentPage = new EmployeeViewModel(_eventAggregator);
    }   
    private void NavigateToEditEmployee()
    {
        CurrentPage = new EmployeeViewModel(_eventAggregator, null);
    }
}

