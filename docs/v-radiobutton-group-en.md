# VRadioButtonGroup

Used to display multiple options and allow the user to select a single option.

## Basic Usage

Basic usage

Use the `ItemsSource` and `SelectedItem` properties to bind data and the selected item.

The bound data source objects must include `Value` and `Icon`.

![alt text](assets/image-52.png)

```xml
<control:VRadioButtonGroup ItemsSource="{Binding InspTypeList2}"
                            SelectedItem="{Binding InspType}">
```

CodeBehind

```csharp
InspTypeList2 = new ObservableCollection<IRadioButtonModel>()
{
    new RadioButtonModel() { Id = "1", Value = "Booking" },
    new RadioButtonModel() { Id = "2", Value = "Reports" },
    new RadioButtonModel() { Id = "3", Value = "Documents" }
};
```

## With Icons

Bind the `Icon` property of the data source object to set an icon.  
Icons should be in Unicode format or specified by name.

![alt text](assets/image-53.png)

CodeBehind

```csharp
InspTypeList = new ObservableCollection<IRadioButtonModel>()
{
    new RadioButtonModel()
    {
        Id = "1",
        Value = "Booking",
        Icon = "\uF0eb",
    },
    new RadioButtonModel()
    {
        Id = "2",
        Value = "Reports",
        Icon = "\uE4f0",
    },
    new RadioButtonModel()
    {
        Id = "3",
        Value = "Documents",
        Icon = "\uF15b",
    },
};
```

## Disabled State

Disable the control by setting the `IsEnabled` property to `False`.

![alt text](assets/image-54.png)

![alt text](assets/image-55.png)

## Layout Direction

Set the `RadioButtonGroupDirection` property to control the layout direction. The default is horizontal.

Available directions:

* Horizontal - Horizontal
* Vertical - Vertical

![alt text](assets/image-56.png)

```xml
<control:VRadioButtonGroup ItemsSource="{Binding InspTypeList}"
                            RadioButtonGroupDirection="Vertical"></control:VRadioButtonGroup>
```
