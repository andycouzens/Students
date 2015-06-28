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
    public class EnrolmentListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Enrolment> _enrolments;
        private EnrolmentRepo _repo;

        public EnrolmentListViewModel()
        {
        }

        public async void LoadEnrolments()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            _repo = new EnrolmentRepo();
            Enrolments = new ObservableCollection<Enrolment>(await _repo.GetEnrolmentsAsync());
        }

        public ObservableCollection<Enrolment> Enrolments
        {
            get
            {
                return _enrolments;
            }
            set
            {
                if (_enrolments != value)
                {
                    _enrolments = value;
                    OnPropertyChanged("Enrolments");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
