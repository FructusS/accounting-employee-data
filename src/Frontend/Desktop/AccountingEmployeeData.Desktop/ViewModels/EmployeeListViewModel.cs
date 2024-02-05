using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingEmployeeData.Desktop.Services;
using AccountingEmployeeData.Domain.Models;
using Newtonsoft.Json;
using Prism.Events;

namespace AccountingEmployeeData.Desktop.ViewModels;

public class EmployeeListViewModel : BaseViewModel
{

    private List<Employee> _employeeList;

    public List<Employee> EmployeeList
    {
        get => _employeeList;
        set
        {
            _employeeList = value;
            OnPropertyChanged();
        }
    }

    public EmployeeListViewModel()
    { 
        LoadEmployeeList();
    }
    
    private async void LoadEmployeeList()
    {
        using (var httpClient = HttpService.GetHttpClient())
        {
           var response = await httpClient.GetAsync("Employee");
           if (response.IsSuccessStatusCode)
           {
               var employeeList = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());

               EmployeeList = employeeList;

           }
        }
    }
}