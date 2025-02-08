# VCheckBoxGroup

A collection of CheckBoxButton elements used to implement multi-selection or single-selection functionality.

## Basic Usage

Use the `ItemsSource` property to bind data.

The `SelectedItems` and `SelectedItem` properties are used to retrieve the selected data.

![alt text](assets/recording-26.gif)

```xml
<control:VCheckBoxGroup ItemsSource="{Binding CityList}"/>
```

ViewModel:

```csharp
CityList = new ObservableCollection<string>()
{
    "Austin",
    "Washington",
    "Denver",
    "Chicago",
    "Seattle",
    "New York",
    "Los Angeles",
};
```

Set the `DisplayPropertyName` property to specify the display property.

```xml
<control:VCheckBoxGroup DisplayPropertyName="Title" 
                        ItemsSource="{Binding CityList}"/>
```

## Single Selection

Set the `IsSingleSelection` property to `True`.

![alt text](assets/recording-27.gif)

```xml
<control:VCheckBoxGroup ItemsSource="{Binding CityList}"
                        IsSingleSelection="True" />
```

## Remove Button

Use the `HasRemove` property to show or hide the remove button.

![alt text](assets/image-88.png)

```xml
<control:VCheckBoxGroup ItemsSource="{Binding CityList}"
                        HasRemove="True"  />
```

## Change Orientation

Use the `Direction` property to change the display orientation of the checkboxes. The default is `Row`.

Available orientations:

* Column - Stacked vertically.
* ColumnReverse - Stacked vertically in reverse order.
* Row - Stacked horizontally.
* RowReverse - Stacked horizontally in reverse order.

Vertical stacking:

![alt text](assets/image-92.png)

```xml
<control:VCheckBoxGroup ItemsSource="{Binding CityList}"
                        HeightRequest="200"
                        Direction="Column" />
```

Reverse horizontal stacking:

![alt text](assets/image-91.png)

```xml
<control:VCheckBoxGroup ItemsSource="{Binding CityList}"
                        Direction="RowReverse" />
```

## Disabled State

Make checkboxes unavailable.

Set the `Enabled` property to `False`.

![alt text](assets/image-89.png)

```xml
<control:VCheckBoxGroup ItemsSource="{Binding CityList}"
                        IsEnabled="False" />
```

## Hide Clear Button

The clear button is used to remove all selected items. If it is not needed, set the `HasClear` property to `False`.

![alt text](assets/image-90.png)

```xml
<control:VCheckBoxGroup ItemsSource="{Binding CityList}"
                        HasClear="False" />