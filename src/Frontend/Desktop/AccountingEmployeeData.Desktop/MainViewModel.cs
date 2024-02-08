using System;
using AccountingEmployeeData.Desktop.Events;
using AccountingEmployeeData.Desktop.ViewModels;
using AccountingEmployeeData.Domain.Models;
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
        _eventAggregator.GetEvent<NavigateToEditEmployeeEvent>().Subscribe(NavigateToEditEmployee);
        _eventAggregator.GetEvent<NavigateToEmployeeListEvent>().Subscribe(NavigateToEmployeeList);
    }
//TODO мб переделать навигацию(статик стек с BaseViewModel)
    private void NavigateToEmployeeList()
    {
        CurrentPage = new EmployeeListViewModel(_eventAggregator);
    }

    public MainViewModel()
    {
        
    }
    private void NavigateToCreateEmployee()
    {
        CurrentPage = new EmployeeViewModel(_eventAggregator);
    }   
    private void NavigateToEditEmployee(Employee employee)
    {
        CurrentPage = new EmployeeViewModel(_eventAggregator, employee);
    }
}

