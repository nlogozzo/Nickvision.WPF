namespace Nickvision.WPF.MVVM;

/// <summary>
/// A base class for other ViewModels.
/// </summary>
public class ViewModelBase : ObservableObject
{
    /// <summary>
    /// The title of the view.
    /// </summary>
    public string? Title { get; set; }
}