# VCheckableCollection

A collection of selectable options for implementing multi-selection or single-selection functionality.

## Basic Usage

Use the `ItemsSource` and `SelectedItems` properties to bind data and selected items.

![alt text](assets/recording-2.gif)

```xml
<control:VCheckableCollection ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```

Set the `DisplayPropertyName` property to specify the displayed attribute.

![alt text](assets/recording-6.gif)

```xml
<control:VCheckableCollection DisplayPropertyName="Title"
                            ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```

## Search Box

Use the `SearchKeywords` bindable property to specify search keywords. Items matching the criteria will be case-insensitively and fuzzily matched.

![alt text](assets/recording-5.gif)

```xml
<control:VCheckableCollection DisplayPropertyName="Title"
                            SearchKeywords="{Binding SearchKeywords}"
                            ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```

## Single Selection

Set the `IsSingleSelection` property to `True` to enable single selection.

![alt text](assets/recording-3.gif)

```xml
<control:VCheckableCollection IsSingleSelection="True"
                            DisplayPropertyName="Title"
                            ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```

## Hide Search Box or Clear Button

Checkbox in an unavailable state.

* Set the `HasClear` property to `False` to remove the clear button.
* Set the `HasSearchBar` property to `False` to remove the search box.

![alt text](assets/image-51.png)

```xml
<control:VCheckableCollection HasClear="False"
                              HasSearchBar="False"
                              ItemsSource="{Binding InternalEmailList}"
                              SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```

## Disabled State

Checkbox in an unavailable state.

Set the `IsCollectionEnabled` property to `False`.

![alt text](assets/image-50.png)

```xml
<control:VCheckableCollection IsCollectionEnabled="False"
                              ItemsSource="{Binding InternalEmailList}"
                              SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
