using Students.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell
{
    public class StudentViewModel
    {
        private ObservableCollection<Student> _students;

        public StudentViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            StudentRepo repo = new StudentRepo();
            Students = new ObservableCollection<Student>(repo.GetStudentsAsync().Result);
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
    }
}
