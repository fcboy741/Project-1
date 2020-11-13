using Student_Information_Management.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Student_Information_Management.ViewModel
{
    class NewStudentViewModel : BaseViewModel, IDataErrorInfo
    {
        private string _StudentID;
        private string _FirstName;
        private string _LastName;
        private DateTime _Brithday=DateTime.Now;
        private string _Gender;
        private string _Address;
        private string _Email;
        private List<string> _ListComboBox = new List<string> { "Item 1", "Item 2", "Item 3" };
        private string _SelectedClass;

        public NewStudentViewModel()
        {

            SaveCommand = new RelayCommand(o => Save(), o => !string.IsNullOrEmpty(StudentID) && !string.IsNullOrEmpty(FirstName)&&!string.IsNullOrEmpty(LastName));
            CancelCommand = new RelayCommand(o => Cancel(), o => !string.IsNullOrEmpty(StudentID) && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName));
        }

        public string StudentID { get => _StudentID; set => _StudentID = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public DateTime Brithday { get => _Brithday; set => _Brithday = value; }
        public string Gender { get => _Gender; set => _Gender = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Email { get => _Email; set => _Email = value; }
        public List<string> ListComboBox { get => _ListComboBox; set => _ListComboBox = value; }
        public string SelectedClass { get => _SelectedClass; set => _SelectedClass = value; }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (nameof(StudentID) == columnName)
                {
                    if (string.IsNullOrEmpty(StudentID))
                    {
                        result = "Name is mandatory";
                    }
                }
                if (nameof(FirstName) == columnName)
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        result = "Name is mandatory";
                    }
                }
                if (nameof(LastName) == columnName)
                {
                    if (string.IsNullOrEmpty(LastName))
                    {
                        result = "Name is mandatory";
                    }
                }
                return result;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        
        public ICommand SaveCommand { get; set; }

        public void Save()
        {
           
        }
        public ICommand CancelCommand { get; set; }
        

        public void Cancel()
        {

        }
        
    }
}
