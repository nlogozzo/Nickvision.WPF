![Nuget](https://img.shields.io/nuget/v/Nickvision.WPF)

# Nickvision.WPF
A framework for creating Nickvision applications with WPF

# Features
- Custom controls (`ProgressDialog`, `NavigationBar`, `InfoBar`, `MessageBox`, and more)
- An update framework to keep track and notify users of new application versions and changes
  - Allows for automatically downloading and install the update from within an app
- Extensions methods to make working with WPF and other objects easier (`EnumExtensions`, `HttpClientExtensions`, and more)
- A full MVVM framework custom built for working with WPF and controls easier:
  - Support for Commands with `DelegateCommand` and `DelegateAsyncCommand`
  - Customs services: `IIOService`, `IProgressDialogService`, `IWindowService`, `IMessageBoxService`, and more
  - A `Messenger` class to support sending messages between ViewModels

# Sample
[NickvisionApp](https://github.com/nlogozzo/NickvisionApp)

Please refer to the sample app for an example on how to use this library.

# Nuget
[Nickvision.WPF](https://www.nuget.org/packages/Nickvision.WPF/)
