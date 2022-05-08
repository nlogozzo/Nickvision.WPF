using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nickvision.WPF.MVVM.Commands;

/// <summary>
/// A bindable command.
/// </summary>
/// <typeparam name="T">The type of a parameter</typeparam>
public class DelegateAsyncCommand<T> : ObservableObject, ICommand
{
    private readonly Func<T?, Task> _execute;
    private readonly Func<bool>? _canExecute;
    private bool _isExecuting;

    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Constructs a DelegateAsyncCommand.
    /// </summary>
    /// <param name="execute">The async method to execute</param>
    /// <param name="canExecute">The conditions for the command to be executable</param>
    public DelegateAsyncCommand(Func<T?, Task> execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
        IsExecuting = false;
    }

    /// <summary>
    /// If the async method is currently being executed.
    /// </summary>
    public bool IsExecuting
    {
        get => _isExecuting;

        set
        {
            _isExecuting = value;
            RaiseCanExecuteChanged();
        }
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
    public bool CanExecute(object? parameter) => !IsExecuting && (_canExecute == null || _canExecute());

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
    public async void Execute(object? parameter)
    {
        IsExecuting = true;
        await ExecuteAsync((T?)parameter);
        IsExecuting = false;
    }

    /// <summary>
    /// Executes the command asynchronously 
    /// </summary>
    /// <param name="parameter">The parameter to pass to the execute delegate</param>
    private async Task ExecuteAsync(T? parameter) => await _execute(parameter);
}