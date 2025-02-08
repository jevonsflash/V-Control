# VCheckBox

Selection unit in a multi-selection control

## Basic Usage

Basic usage of CheckBox.

![alt text](assets/image-35.png)

```xml
<control:VCheckBox Title="CHECKBOX LABEL"></control:VCheckBox>
```

Use the `IsChecked` property to set whether it is selected. This property supports two-way data binding.

![alt text](assets/recording-23.gif)

```xml
<control:VCheckBox Title="CHECKBOX LABEL" IsChecked="True"></control:VCheckBox>
```

## Disabled State

CheckBox in a disabled state.

Set the `IsEnabled` property to `False`.

![alt text](assets/image-36.png)

```xml
<control:VCheckBox Title="CHECKBOX LABEL"
                    IsEnabled="False"></control:VCheckBox>
```

## Indeterminate State

Set the `IsIndeterminate` property to `True` to indicate an indeterminate state for the CheckBox. Note: The `IsIndeterminate` property only changes the control's appearance and does not affect the `IsChecked` state.

![alt text](assets/recording-1.gif)

```xml
<control:VCheckBox Title="CHECKBOX LABEL"
                    IsIndeterminate="True"></control:VCheckBox>
```

## Changing Icons

Set the `IconText` property to specify an icon. The icon format can be a Unicode character or an icon name. The default value is `\uF068`.

![alt text](assets/image-37.png)

```xml
<control:VCheckBox Title="CHECKBOX LABEL"
                   IconText="&#xf00d;"
                   IsChecked="True"></control:VCheckBox>
```

## Custom Content

You can set the `ContentSlot` property to define custom content for the CheckBox. Setting this property overrides the default CheckBox icon.

CheckBox with an icon

![alt text](assets/image-38.png)

```xml
<control:VCheckBox Title="CHECKBOX LABEL">
    <control:VCheckBox.ContentSlot>
        <Image Source="aze.png"           
                HorizontalOptions="Center"
                VerticalOptions="Center"></Image>
    </control:VCheckBox.ContentSlot>
</control:VCheckBox>
