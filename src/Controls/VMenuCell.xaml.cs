using System.Windows.Input;

namespace VControl.Controls;

public partial class VMenuCell : ViewCell
{
    public VMenuCell()
    {
        InitializeComponent();
        if (MenuTextColor == default)
        {
            object textColor = default;
            Application.Current?.Resources.TryGetValue("OnSurface", out textColor);
            MenuTextColor = textColor as Color;
        }
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VMenuCell),
        default(ICommand),
        propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var menuCell = (VMenuCell)bindable;
            var oldcommand = (ICommand)oldvalue;
            if (oldcommand != null)
                oldcommand.CanExecuteChanged -= menuCell.OnCommandCanExecuteChanged;
        },
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var menuCell = (VMenuCell)bindable;
            var newcommand = (ICommand)newvalue;
            if (newcommand != null)
            {
                menuCell.IsEnabled = newcommand.CanExecute(menuCell.CommandParameter);
                newcommand.CanExecuteChanged += menuCell.OnCommandCanExecuteChanged;
            }
        }
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VMenuCell),
        default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var menuCell = (VMenuCell)bindable;
            if (menuCell.Command != null)
            {
                menuCell.IsEnabled = menuCell.Command.CanExecute(newvalue);
            }
        }
    );

    public static readonly BindableProperty MenuTextProperty = BindableProperty.Create(
        nameof(MenuText),
        typeof(string),
        typeof(VMenuCell),
        default(string)
    );
    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
        nameof(IconText),
        typeof(string),
        typeof(VMenuCell),
        default(string)
    );

    public static readonly BindableProperty MenuTextColorProperty = BindableProperty.Create(
        nameof(MenuTextColor),
        typeof(Color),
        typeof(VMenuCell),
        default
    );

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public object CommandParameter
    {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public string MenuText
    {
        get { return (string)GetValue(MenuTextProperty); }
        set { SetValue(MenuTextProperty, value); }
    }

    public string IconText
    {
        get { return (string)GetValue(IconTextProperty); }
        set { SetValue(IconTextProperty, value); }
    }

    public Color MenuTextColor
    {
        get { return (Color)GetValue(MenuTextColorProperty); }
        set { SetValue(MenuTextColorProperty, value); }
    }

    protected override void OnTapped()
    {
        base.OnTapped();

        if (!IsEnabled)
        {
            return;
        }

        Command?.Execute(CommandParameter);
    }

    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }
}
