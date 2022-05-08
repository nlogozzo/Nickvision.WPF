using System;
using System.Windows.Input;

namespace Nickvision.WPF.MVVM.Commands;

/// <summary>
/// A bindable command.
/// </summary>
/// <typeparam name="T">The type of a parameter</typeparam>
public class DelegateCommand<T> : ObservableObject, ICommand
{
    private readonly Action<T?> _execute;
    private readonly Func<bool>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Constructs a DelegateCommand.
    /// </summary>
    /// <param name="execute">The method to execute</param>
    /// <param name="canExecute">The conditions for the command to be executable</param>
    public DelegateCommand(Action<T?> execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    /// <summary>
    /// CanExecute but as a property
    /// </summary>
    public bool IsExecutable => CanExecute(null);

    /// <summary>
    /// Returns whether or not the command can execute or not
    /// </summary>
    /// <param name="parameter">Unused</param>
    /// <returns>True if the command can execute, else false</returns>
    public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

    /// <summary>
    /// Signal that the conditions for the command to be executable might have changed. 
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        OnPropertyChanged("IsExecutable");
    }

    /// <summary>
    /// Executes the command
    /// </summary>
    /// <param name="parameter">The parameter to pass to the execute delegate</param>
    public void Execute(object? parameter) => _execute((T?)parameter);
}