using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell.Model
{
    public class SimpleEditableStudent : ValidatableBindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _firstName;
        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _surname;
        [Required]
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }
    }
}
