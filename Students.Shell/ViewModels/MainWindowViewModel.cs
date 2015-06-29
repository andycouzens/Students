using Students.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell
{
    public class MainWindowViewModel : BindableBase
    {
        private StudentListViewModel _studentListViewModel = new StudentListViewModel();
        private EnrolmentListViewModel _enrolmentListViewModel = new EnrolmentListViewModel();
        private AddEditStudentViewModel _addEditStudentViewModel = new AddEditStudentViewModel(); 

        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            _studentListViewModel.ViewEnrolmentsRequested += NavToEnrolments;
            _studentListViewModel.EditStudentRequested += NavToEdit;
            _currentViewModel = _studentListViewModel;

            NavCommand = new DelegateCommand<string>(OnNav);
        }

        private void NavToEdit(Student obj)
        {
            _addEditStudentViewModel.SetStudent(obj);
            CurrentViewModel = _addEditStudentViewModel;
        }

        private void NavToEnrolments(int studentId)
        {
            _enrolmentListViewModel.StudentId = studentId;
            CurrentViewModel = _enrolmentListViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }

        public DelegateCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "enrolments":
                    CurrentViewModel = _enrolmentListViewModel;
                    break;
                default:
                    CurrentViewModel = _studentListViewModel;
                    break;
            }
        }
    }
}
