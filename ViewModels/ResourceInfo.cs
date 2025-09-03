namespace WpfResourceList.ViewModels;

public class ResourceInfo
{
    public required object Key { get; set; }

    public required Type KeyType { get; set; }

    public required object? Resource { get; set; }

    public required Type? ResourceType { get; set; }

    public Type? TargetType { get; set; }
}
