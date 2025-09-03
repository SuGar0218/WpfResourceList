using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;

namespace WpfResourceList.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial ObservableCollection<ResourceInfo> ResourceInfoList { get; set; }
}
