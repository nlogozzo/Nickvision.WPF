using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nickvision.WPF.MVVM;

/// <summary>
/// An INotifyPropertyChanged implemented object.
/// </summary>
public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    protected bool SetProperty<T>(ref T prop, T value, [CallerMemberName] string? name = null)
    {
        if (EqualityComparer<T>.Default.Equals(prop, value))
        {
            return false;
        }
        prop = value;
        OnPropertyChanged(name);
        return true;
    }
}