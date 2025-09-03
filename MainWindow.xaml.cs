using System.Windows;
using System.Windows.Controls;

using WpfResourceList.ViewModels;

namespace WpfResourceList;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ListResourceDictionary(ResourceDictionary dictionary, bool recursive = false)
    {
        foreach (object key in dictionary.Keys)
        {
            ViewModel.ResourceInfoList.Add(new ResourceInfo()
            {
                Key = key,
                KeyType = key.GetType(),
                Resource = Application.Current.Resources[key],
                ResourceType = Application.Current.Resources[key]?.GetType(),
                TargetType = Application.Current.Resources[key] is Style style ? style.TargetType : null
            });
        }
        if (recursive)
        {
            foreach (ResourceDictionary mergedDictionary in dictionary.MergedDictionaries)
            {
                ListResourceDictionary(mergedDictionary, true);
            }
        }
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is not null)
        {
            if (e.RemovedItems.Count > 0 && e.RemovedItems[0] is not null)
            {
                ResourceDictionary unselectedResourceDictionary = (ResourceDictionary) e.RemovedItems[0]!;
                Application.Current.Resources.MergedDictionaries
                    .Remove(Application.Current.Resources.MergedDictionaries
                    .First(ResourceDictionary => ResourceDictionary.Source.Equals(unselectedResourceDictionary.Source)));
            }
            ResourceDictionary selectedResourceDictionary = (ResourceDictionary) e.AddedItems[0]!;
            Application.Current.Resources.MergedDictionaries.Add(selectedResourceDictionary);
            ViewModel.ResourceInfoList = [];
            ListResourceDictionary(selectedResourceDictionary, recursive: true);
        }
    }
}