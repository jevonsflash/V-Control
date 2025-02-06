
# VPicker

选择器组件。


## 基础用法


![alt text](assets/image-101.png)

使用 `ItemsSource` 属性绑定选择器数据源，需要绑定 `IList<ValidatableObject<T>>` 的对象。

使用 `SelectedItem` 属性绑定当前选中的项。


```xml
<control:VPicker ItemsSource="{Binding SalutationList}"
                    DisplayPropertyName="Value"
                    SelectedItem="{Binding SelectedSalutation}"></control:VPicker>
           
```




设置 `DisplayPropertyName` 属性来指定显示的属性。

![alt text](assets/recording-32.gif)

```xml
<control:VPicker ItemsSource="{Binding SalutationList}"
                DisplayPropertyName="Id"
                IsPickerEnabled="False"
                SelectedItem="{Binding SelectedSalutation}"></control:VPicker>


```


## 占位文本



![alt text](assets/image-102.png)

使用 `PickerTitle` 属性设置占位文本。


```xml

<control:VPicker ItemsSource="{Binding SalutationList}"
                PickerTitle="Please select a salutation"
                DisplayPropertyName="Value"
                SelectedItem="{Binding SelectedSalutation}"></control:VPicker>
           
```

## 禁用状态


![alt text](assets/image-103.png)


使用 `IsPickerEnabled` 属性设置组件是否可用。

```xml
<control:VPicker ItemsSource="{Binding SalutationList}"
                DisplayPropertyName="Value"
                IsPickerEnabled="False"
                SelectedItem="{Binding SelectedSalutation}"></control:VPicker>


```

