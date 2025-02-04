
# VTagPicker

可视化地呈现时间流信息。


## 基础用法

![alt text](assets/image-80.png)

使用 `ItemsSource`  属性来绑定数据。



![alt text](assets/recording-20.gif)

```xml
<control:VTagPicker ItemsSource="{Binding SelectedCountryList}"></control:VTagPicker>

```

ViewModel:

```csharp
DesCountryList = new ObservableCollection<PickerM>()
{
    new PickerM { Id = "US", Value = "United States" },
    new PickerM { Id = "CN", Value = "China" },
    new PickerM { Id = "JP", Value = "Japan" },
    new PickerM { Id = "DE", Value = "Germany" },
    new PickerM { Id = "FR", Value = "France" },
    new PickerM { Id = "GB", Value = "United Kingdom" },
    new PickerM { Id = "RU", Value = "Russia" },
    new PickerM { Id = "IN", Value = "India" },
    new PickerM { Id = "CA", Value = "Canada" },
    new PickerM { Id = "AU", Value = "Australia" },
};
```


设置 `DisplayPropertyName` 属性来指定显示的属性。

![alt text](assets/recording-1.png)

```xml
<control:VTagPicker DisplayPropertyName="Value"
                    ItemsSource="{Binding SelectedCountryList}"></control:VTagPicker>

```


## 删除事件


使用RemoveCommand属性，在删除按钮点击时触发事件。

![alt text](assets/recording.png)


ViewModel (With CommunityToolkit ObservableObject) :

```csharp

[RelayCommand]

private void RemoveDesCountry(object obj)
{
    if (obj != null && obj is PickerM)
    {
        SelectedCountryList.Remove(obj as PickerM);
    }
}
```



## 禁用状态

设置 `IsPickerEnabled`属性为 `False` 即可。

![alt text](assets/image-82.png)

```xml
<control:VTagPicker IsPickerEnabled="False"
                    ItemsSource="{Binding DesCountryList2}"></control:VTagPicker>
```

## 无删除按钮


设置 `HasRemove`属性为 `False` 即可。

![alt text](assets/image-83.png)


```xml
<control:VTagPicker HasRemove="False"
                    ItemsSource="{Binding DesCountryList2}"></control:VTagPicker>

```