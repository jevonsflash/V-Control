
# VCheckableCollection

一组选项的集合，用于实现多选或单选功能。


## 基础用法


使用 `ItemsSource` 和 `SelectedItems` 属性来绑定数据和选中项。



![alt text](assets/recording-2.gif)

```xml
<control:VCheckableCollection ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```

设置 `DisplayPropertyName` 属性来指定显示的属性。

![alt text](assets/recording-6.gif)


```xml
<control:VCheckableCollection DisplayPropertyName="Title"
                            ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```


## 搜索框


使用 `SearchKeywords` 可绑定属性指定搜索关键字。将不区分大小写模糊匹配符合条件的项。


![alt text](assets/recording-5.gif)

```xml
<control:VCheckableCollection DisplayPropertyName="Title"
                            SearchKeywords="{Binding SearchKeywords}"
                            ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>
```



## 单选

使用 `IsSingleSelection` 属性为`True`时来设置单选。


![alt text](assets/recording-3.gif)



```xml
<control:VCheckableCollection IsSingleSelection="True"
                            DisplayPropertyName="Title"
                            ItemsSource="{Binding InternalEmailList}"
                            SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>


```



## 隐藏搜索框或清空按钮


多选框不可用状态。

* 设置 `HasClear`属性为 `False` 可移除清空按钮。
* 设置 `HasSearchBar`属性为 `False` 可移除搜索框。

![alt text](assets/image-51.png)

```xml
<control:VCheckableCollection HasClear="False"
                              HasSearchBar="False"
                              ItemsSource="{Binding InternalEmailList}"
                              SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>

```


## 禁用状态


多选框不可用状态。

设置 `IsCollectionEnabled`属性为 `False` 即可。

![alt text](assets/image-50.png)

```xml
<control:VCheckableCollection IsCollectionEnabled="False"
                              ItemsSource="{Binding InternalEmailList}"
                              SelectedItems="{Binding SelectedEmailList}">
</control:VCheckableCollection>

```

