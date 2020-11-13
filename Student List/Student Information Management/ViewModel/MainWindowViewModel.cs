using Student_Information_Management.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Student_Information_Management.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private string _SearchBox;
        private List<string> _ListClass = new List<string> { "18DTHQA1", "18DTHQA2", "18DTHQA3" };
        private string _SelectedClass;

        public MainWindowViewModel()
        {

            ResetCommand = new RelayCommand(o => Reset(), o => !string.IsNullOrEmpty(SearchBox)|| !string.IsNullOrEmpty(_SelectedClass));
            SearchCommand = new RelayCommand(o => Search(), o => !string.IsNullOrEmpty(SearchBox)|| !string.IsNullOrEmpty(_SelectedClass));
            MenuCommand = new RelayCommand(o => Menu());
            
            StudentService = new StudentService();
            StudentList = new ObservableCollection<Student>(StudentService.SearchStudent(new StudentSearchCriteria()));
        }


        public string SearchBox
        {
            get
            {
                return _SearchBox;

            }
            set
            {
                _SearchBox = value;
                
            }
        }
        public List<string> ListClass { get => _ListClass; set => _ListClass = value; }
        public string SelectedClass { get => _SelectedClass; set =>     _SelectedClass = value; }

        public ICommand ResetCommand { get; set; }
        public void Reset()
        {
            SearchBox = string.Empty;
            SelectedClass = null;
            StudentList.Clear();
            var result = StudentService.SearchStudent(new StudentSearchCriteria { SearchText = SearchBox, ClassName = SelectedClass });
            foreach (var item in result)
            {
                StudentList.Add(item);
            }
        }
        public ICommand SearchCommand { get; set; }

        public void Search()
        {
            StudentList.Clear();
            var result = StudentService.SearchStudent(new StudentSearchCriteria { SearchText = SearchBox ,ClassName =SelectedClass});
            foreach (var item in result)
            {
                StudentList.Add(item);
            }
        }
        public ICommand MenuCommand { get; set; }

        public void Menu()
        {
            Window window = new NewStudent();
            window.ShowDialog();
        }
        public StudentService StudentService { get; set; }

        public ObservableCollection<Student> StudentList { get; set; }
    }


}
