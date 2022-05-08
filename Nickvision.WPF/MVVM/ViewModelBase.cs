namespace Nickvision.WPF.MVVM;

/// <summary>
/// A base class for other ViewModels.
/// </summary>
public class ViewModelBase : ObservableObject
{
    private string? _title;

    /// <summary>
    /// The title of the view.
    /// </summary>
    public string? Title
    {
        get => _title;

        set => SetProperty(ref _title, value);
    }
}