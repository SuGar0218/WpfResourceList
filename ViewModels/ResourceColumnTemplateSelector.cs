using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfResourceList.ViewModels;

internal class ResourceColumnTemplateSelector : DataTemplateSelector
{
    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        if (item is null)
            return DefaultCellTemplate;

        ResourceInfo info = (ResourceInfo) item;

        if (info.Resource is Color)
            return ColorCellTemplate;

        if (info.Resource is Brush)
            return BrushCellTemplate;

        if (info.KeyType == typeof(string) && ((string) info.Key).Contains("ToolBar") || info.Key is not null && (info.Key.ToString() ?? string.Empty).Contains("ToolBar"))
            return DefaultCellTemplate;

        if (info.Resource is Style style)
        {
            if (style.TargetType == typeof(Button))
                return ButtonStyleCellTemplate;

            if (style.TargetType == typeof(CheckBox))
                return CheckBoxStyleCellTemplate;

            if (style.TargetType == typeof(ComboBox))
                return ComboBoxStyleCellTemplate;

            if (style.TargetType == typeof(PasswordBox))
                return PasswordBoxStyleCellTemplate;

            if (style.TargetType == typeof(ProgressBar))
                return ProgressBarStyleCellTemplate;

            if (style.TargetType == typeof(RadioButton))
                return RadioButtonStyleCellTemplate;

            if (style.TargetType == typeof(ToggleButton))
                return ToggleButtonStyleCellTemplate;

            if (style.TargetType == typeof(TextBlock))
                return TextBlockStyleCellTemplate;

            if (style.TargetType == typeof(TextBox))
                return TextBoxStyleCellTemplate;

            if (style.TargetType == typeof(ScrollBar))
                return ScrollBarStyleCellTemplate;

            if (style.TargetType == typeof(DatePicker))
                return DatePickerStyleCellTemplate;

            if (style.TargetType == typeof(Calendar))
                return CalendarStyleCellTemplate;

            if (style.TargetType == typeof(Expander))
                return ExpanderStyleCellTemplate;

            if (style.TargetType == typeof(Menu))
                return MenuStyleCellTemplate;
        }

        return DefaultCellTemplate;
    }

    public DataTemplate? DefaultCellTemplate { get; set; }
    public DataTemplate? ColorCellTemplate { get; set; }
    public DataTemplate? BrushCellTemplate { get; set; }
    public DataTemplate? FontCellTemplate { get; set; }
    public DataTemplate? ButtonStyleCellTemplate { get; set; }
    public DataTemplate? CheckBoxStyleCellTemplate { get; set; }
    public DataTemplate? ComboBoxStyleCellTemplate { get; set; }
    public DataTemplate? PasswordBoxStyleCellTemplate { get; set; }
    public DataTemplate? ProgressBarStyleCellTemplate { get; set; }
    public DataTemplate? RadioButtonStyleCellTemplate { get; set; }
    public DataTemplate? ToggleButtonStyleCellTemplate { get; set; }
    public DataTemplate? TextBlockStyleCellTemplate { get; set; }
    public DataTemplate? TextBoxStyleCellTemplate { get; set; }
    public DataTemplate? ScrollBarStyleCellTemplate { get; set; }
    public DataTemplate? DatePickerStyleCellTemplate { get; set; }
    public DataTemplate? CalendarStyleCellTemplate { get; set; }
    public DataTemplate? ExpanderStyleCellTemplate { get; set; }
    public DataTemplate? MenuStyleCellTemplate { get; set; }
}
