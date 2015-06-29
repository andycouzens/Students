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
    public class EnrolmentListViewModel : BindableBase
    {
        private ObservableCollection<Enrolment> _enrolments;
        private EnrolmentRepo _repo;
        private int _studentId;

        public async void LoadEnrolments(int studentId)
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            _repo = new EnrolmentRepo();
            Enrolments = new ObservableCollection<Enrolment>(await _repo.GetEnrolmentsAsync(studentId));
        }

        public ObservableCollection<Enrolment> Enrolments
        {
            get
            {
                return _enrolments;
            }
            set
            {
                SetProperty(ref _enrolments, value);
            }
        }

        public int StudentId
        {
            get
            {
                return _studentId;
            }
            set
            {
                SetProperty(ref _studentId, value);
                LoadEnrolments(_studentId);
            }
        }
    }
}
