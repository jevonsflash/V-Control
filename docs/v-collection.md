
# VCollection

一组数据的集合，用于列表显示和选择数据。


## 基础用法


使用 `ItemsSource`  属性来绑定数据。


![alt text](assets/image-86.png)


```xml
<control:VCollection ItemsSource="{Binding InternalEmailList}">

</control:VCollection>
```

设置 `DisplayPropertyName` 属性来指定显示的属性。

![alt text](assets/recording-25.gif)


```xml
<control:VCollection DisplayPropertyName="Title"
                            ItemsSource="{Binding InternalEmailList}">
</control:VCollection>
```


## 搜索框


使用 `SearchKeywords` 可绑定属性指定搜索关键字。将不区分大小写模糊匹配符合条件的项。


![alt text](assets/recording-24.gif)

```xml
<control:VCollection DisplayPropertyName="Title"
                            SearchKeywords="{Binding SearchKeywords}"
                            ItemsSource="{Binding InternalEmailList}">
</control:VCollection>
```




## 隐藏搜索框


多选框不可用状态。设置 `HasSearchBar`属性为 `False` 可移除搜索框。


```xml
<control:VCollection HasClear="False"
                    HasSearchBar="False"
                    ItemsSource="{Binding InternalEmailList}">
</control:VCollection>

```

## 编辑和删除按钮


使用 `HasEdit` 和 `HasRemove` 属性来显示或隐藏编辑和删除按钮。

![alt text](assets/image-87.png)

```xml
<control:VCollection HasEdit="True"
                     HasRemove="True"
                     ItemsSource="{Binding InternalEmailList}"
                    ></control:VCollection>

```


## 禁用状态


多选框不可用状态。

设置 `IsCollectionEnabled`属性为 `False` 即可。


![alt text](assets/image-85.png)


```xml
<control:VCollection IsCollectionEnabled="False"
                              ItemsSource="{Binding InternalEmailList}">
</control:VCollection>

```

