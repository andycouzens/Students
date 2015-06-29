using Students.Data;
using Students.Shell.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell
{
    public class AddEditStudentViewModel : ValidatableBindableBase
    {
        private IStudentRepo _repo = new StudentRepo();

        public AddEditStudentViewModel()
        {
            CancelCommand = new DelegateCommand(OnCancel);
            SaveCommand = new DelegateCommand(OnSave, CanSave); 
        }
        private bool _EditMode;
        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableStudent _student;
        public SimpleEditableStudent Student
        {
            get { return _student; }
            set { SetProperty(ref _student, value); }
        }

        private Student _editingStudent = null;

        public void SetStudent(Student student)
        {
            _editingStudent = student;
            if (Student != null) Student.ErrorsChanged -= RaiseCanExecuteChanged;
            Student = new SimpleEditableStudent();
            Student.ErrorsChanged += RaiseCanExecuteChanged; 
            CopyStudent(student, Student);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void OnCancel()
        {
            Done();
        }
        private async void OnSave()
        {
            UpdateCustomer(Student, _editingStudent);
            if (EditMode)
                await _repo.UpdateStudentAsync(_editingStudent);
            else
                await _repo.AddStudentAsync(_editingStudent);
            Done();
        }

        private void UpdateCustomer(SimpleEditableStudent source, Student target)
        {
            target.FirstName = source.FirstName;
            target.Surname = source.Surname;
        }

        private bool CanSave()
        {
            return !Student.HasErrors;
        }

        private void CopyStudent(Student source, SimpleEditableStudent target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.FirstName = source.FirstName;
                target.Surname = source.Surname;
            }
        }
    }
}
