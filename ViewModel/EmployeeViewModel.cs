using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Exercise01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Exercise01.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        //Role of ViewModel
        private Employee _employee;
        private string _fullName; //variable for data conversion

        public EmployeeViewModel()
        {
            //Initialize a sample employee model. Coordination with Model
            _employee = new Employee { FirstName = "John", LastName = "Doe"};

            //UI Thread Management
            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            //Collections
            Employees = new ObservableCollection<Employee>()
            {
                new Employee {FirstName = "Jane", LastName = "Smith", Position = "Scrum Master", Department = "IT", IsActive = true},
                new Employee {FirstName = "Juan", LastName = "Dela Cruz", Position = "Full-Stack Developer", Department = "IT", IsActive = true},
                new Employee {FirstName = "Pedro", LastName = "Penduko", Position = "Senior Back-End Developer", Department = "IT", IsActive = true},
                new Employee {FirstName = "Sandra", LastName = "Reyes", Position = "Senior Front-End Developer", Department = "IT", IsActive = true},
                new Employee {FirstName = "Chloe", LastName = "Morales", Position = "Junior Back-End Developer", Department = "IT", IsActive = true},
                new Employee {FirstName = "Jaimie", LastName = "Santos", Position = "Junior Front-End Developer", Department = "IT", IsActive = true},
            };
        }

        //Setting collections in public
        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        //UI Thread Management
        public ICommand LoadEmployeeDataCommand { get; }

        //Two-way Data Binding and Data Conversion
        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_employee.FirstName} {_employee.LastName}"; //Data conversion
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}