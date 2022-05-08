using System.Collections.Generic;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A collection of services.
/// </summary>
public class ServiceCollection
{
    private readonly List<IService> _services;

    /// <summary>
    /// Constructs a ServiceCollection.
    /// </summary>
    public ServiceCollection() => _services = new List<IService>();

    /// <summary>
    /// Adds a service to the collection.
    /// </summary>
    /// <param name="service">The service instance</param>
    /// <typeparam name="T">The type of the service</typeparam>
    /// <returns>False is the collection already contains a service of type T. Else true (meaning the service was added to the collection)</returns>
    public bool AddService<T>(T service) where T : IService
    {
        foreach (var s in _services)
        {
            if (s is T)
            {
                return false;
            }
        }
        _services.Add(service);
        return true;
    }

    /// <summary>
    /// Gets a service from the collection.
    /// </summary>
    /// <typeparam name="T">The type of the service</typeparam>
    /// <returns>The service that matches the type. Null if no match</returns>
    public T? GetService<T>() where T : IService
    {
        foreach (var service in _services)
        {
            if (service is T serviceAsT)
            {
                return serviceAsT;
            }
        }
        return default(T);
    }
}
