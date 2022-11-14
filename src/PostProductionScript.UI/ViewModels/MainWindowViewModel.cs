using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;

using PostProductionScript.Models.ScriptModels;

namespace PostProductionScript.UI.ViewModels
{
  public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
  {
    private TimecodeScript _script = new TimecodeScript();

    public TimecodeScript Script
    {
      get => _script;
      set
      {
        if (Script == value) return;

        _script = value;
        OnPropertyChanged(nameof(Script));
      }
    }

    public string Greeting => "Welcome to Avalonia!";

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword

    public event PropertyChangedEventHandler? PropertyChanged;

#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}