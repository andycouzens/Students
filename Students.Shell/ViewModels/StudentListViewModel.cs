using Students.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students.Shell
{
    public class StudentListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students;
        private StudentRepo _repo;
        private Student _selectedStudent;

        public StudentListViewModel()
        {
            DeleteCommand = new DelegateCommand(OnDelete, CanDelete);
        }

        public async void LoadStudents()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            _repo = new StudentRepo();
            Students = new ObservableCollection<Student>(await _repo.GetStudentsAsync());
        }

        public DelegateCommand DeleteCommand
        {
            get;
            private set;
        }

        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                if (_students != value)
                {
                    _students = value;
                    OnPropertyChanged("Students");
                }
            }
        }

        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    OnPropertyChanged("SelectedStudent");
                }
            }
        }

        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            return SelectedStudent != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
