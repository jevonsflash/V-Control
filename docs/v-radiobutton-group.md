
# V-RadioButtonGroup

用于展示多个选项并允许用户选择其中单个选项。


## 基础用法


基础用法

使用 `ItemsSource` 和 `SelectedItem` 属性来绑定数据和选中项。

绑定的数据源对象，需要包含`Value`和`Icon`


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

## 带图标


绑定的数据源对象的`Icon`属性，设置图标。图标的格式为Unicode字符或图标名称。


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

## 禁用状态


使控件进入不可用状态。

设置 `IsEnabled`属性为 `False` 即可。


![alt text](assets/image-54.png)
![alt text](assets/image-55.png)


## 排列方向

设置 `RadioButtonGroupDirection` 属性来设置排列方向，默认为横向。

可选择的方向：

* Horizontal - 横向
* Vertical - 纵向

![alt text](assets/image-56.png)

```xml
<control:VRadioButtonGroup ItemsSource="{Binding InspTypeList}"
                            RadioButtonGroupDirection="Vertical"></control:VRadioButtonGroup>

```
