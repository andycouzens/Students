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
    public class StudentListViewModel : BindableBase
    {
        private ObservableCollection<Student> _students;
        private StudentRepo _repo;
        private Student _selectedStudent;

        public event Action<int> ViewEnrolmentsRequested;
        public event Action<Student> AddStudentRequested;
        public event Action<Student> EditStudentRequested;

        public StudentListViewModel()
        {
            DeleteCommand = new DelegateCommand(OnDelete, CanDelete);
            ViewEnrolmentsCommand = new DelegateCommand<Student>(OnViewEnrolments);
            EditStudentCommand = new DelegateCommand<Student>(OnEditStudent);
            //ClearSearchCommand = new RelayCommand(OnClearSearch);
        }

        private void OnViewEnrolments(Student student)
        {
            if (ViewEnrolmentsRequested != null)
                ViewEnrolmentsRequested(student.Id);
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

        public DelegateCommand<Student> EditStudentCommand
        {
            get;
            private set;
        }
        
        public DelegateCommand<Student> ViewEnrolmentsCommand
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
                SetProperty(ref _students, value);
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
                SetProperty(ref _selectedStudent, value);
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

        private void OnAddStudent()
        {
            if (AddStudentRequested != null)
                AddStudentRequested(new Student());

        }
        private void OnEditStudent(Student stud)
        {
            if (EditStudentRequested != null)
                EditStudentRequested(stud);
        }
    }
}
