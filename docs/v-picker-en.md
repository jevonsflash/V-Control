# VPicker

Selector Component.

## Basic Usage

![alt text](assets/image-101.png)

Use the `ItemsSource` property to bind the selector's data source, which should be an object bound to `IList<ValidatableObject<T>>`.

Use the `SelectedItem` property to bind the currently selected item.

```xml
<control:VPicker ItemsSource="{Binding SalutationList}"
                    DisplayPropertyName="Value"
                    SelectedItem="{Binding SelectedSalutation}"></control:VPicker>
```

Set the `DisplayPropertyName` property to specify the display attribute.

![alt text](assets/recording-32.gif)

```xml
<control:VPicker ItemsSource="{Binding SalutationList}"
                DisplayPropertyName="Id"
                IsPickerEnabled="False"
                SelectedItem="{Binding SelectedSalutation}"></control:VPicker>
```

## Placeholder Text

![alt text](assets/image-102.png)

Use the `PickerTitle` property to set the placeholder text.

```xml
<control:VPicker ItemsSource="{Binding SalutationList}"
                PickerTitle="Please select a salutation"
                DisplayPropertyName="Value"
                SelectedItem="{Binding SelectedSalutation}"></control:VPicker>
```

## Disabled State

![alt text](assets/image-103.png)

Use the `IsPickerEnabled` property to set whether the component is enabled.

```xml
<control:VPicker ItemsSource="{Binding SalutationList}"
                DisplayPropertyName="Value"
                IsPickerEnabled="False"
                SelectedItem="{Binding SelectedSalutation}"></control:VPicker>


```

