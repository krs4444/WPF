using HospitalLogic.Common;
using HospitalLogic.Model;

namespace HospitalLogic.ViewModel
{
    public class PatientViewModel : BindableBase
    {
        Patient _patient;

        public PatientViewModel(Patient patient)
        {
            _patient = patient;
        }

        public string FirstName { get { return _patient?.FirstName; } }

        public string LastName {  get { return _patient?.LastName; } }

        public int Weight { get { return (_patient?.Weight).GetValueOrDefault(0); } }

        public int Height { get { return (_patient?.Height).GetValueOrDefault(0); } }

        public int Age { get { return (_patient?.Age).GetValueOrDefault(0); } }

        public string FullName { get { return _patient?.FirstName + " " + _patient?.LastName; } }
    }
}
