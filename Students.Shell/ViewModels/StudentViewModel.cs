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
    public class StudentViewModel
    {
        private ObservableCollection<Student> _students;
        private StudentRepo _repo;
        private Student _selectedStudent;

        public StudentViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            _repo = new StudentRepo();
            Students = new ObservableCollection<Student>(_repo.GetStudentsAsync().Result);
            DeleteCommand = new DelegateCommand(OnDelete, CanDelete);
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
                _students = value;
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
                _selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
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
    }
}
