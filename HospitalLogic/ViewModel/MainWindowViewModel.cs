using HospitalLogic.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLogic.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public event EventHandler Loaded;

        public MainWindowViewModel()
        {
            Patients = new ObservableCollection<PatientViewModel>();
            Patients.CollectionChanged += Patients_CollectionChanged;
        }

        private void Patients_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
#warning Will cause UI performance issue when large amount of Patients are loaded
            OnPropertyChanged("AverageHeight");
        }

        public ObservableCollection<PatientViewModel> Patients { get; private set; }

        public async Task InitializeHospital()
        {
            Patients.Clear();

            (await PatientDataSource.GetPatientsAsync()).ForEach(p => Patients.Add(new PatientViewModel(p)));

            Loaded?.Invoke(this, EventArgs.Empty);
        }

        private PatientViewModel _currentPatient;
        public PatientViewModel CurrentPatient
        {
            get { return _currentPatient; }

            set
            {
                _currentPatient = value;
                OnPropertyChanged();
            }
        }

        public double? AverageHeight
        {
            get
            {
                var averageWeight = Patients?.Average(p => p.Weight);

                return Patients?.Where(p => p.Weight > averageWeight).Average(p => p.Height);
            }
        }
    }
}
