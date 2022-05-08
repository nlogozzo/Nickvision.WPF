using System;
using System.Collections.ObjectModel;

namespace Nickvision.WPF.Extensions;

/// <summary>
/// Extension methods for Enum.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Creates an ObservableCollection of the enum type with the enum values added to the list.
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <returns>An ObservableCollection of the enum type with the enum values added to the list</returns>
    public static ObservableCollection<T> GetObservableCollection<T>() where T : Enum
    {
        var observableCollection = new ObservableCollection<T>();
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            observableCollection.Add(value);
        }
        return observableCollection;
    }
}