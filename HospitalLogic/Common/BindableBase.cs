using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HospitalLogic.Common
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T variable, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(variable, value))
                return false;

            variable = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
