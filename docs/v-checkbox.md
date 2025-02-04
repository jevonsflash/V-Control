
# VCheckBox

多项选择器中的选择单元


## 基础用法


基础的CheckBox用法，使用

![alt text](assets/image-35.png)

```xml
<control:VCheckBox Title="CHECKBOX LABEL"></control:VCheckBox>

```

使用 `IsChecked` 属性来设置是否选中。此属性为双向数据绑定属性。

![alt text](assets/recording-23.gif)


```xml
<control:VCheckBox Title="CHECKBOX LABEL" IsChecked="True"></control:VCheckBox>
```

## 禁用状态


多选框不可用状态。

设置 `IsEnabled`属性为 `False` 即可。

![alt text](assets/image-36.png)


```xml
<control:VCheckBox Title="CHECKBOX LABEL"
                    IsEnabled="False"></control:VCheckBox>
```

## 不确定状态

设置 `IsIndeterminate` 属性为 `True` 用以表示 CheckBox 的不确定状态，注意：`IsIndeterminate` 属性仅改变控件外观，不变更控件的IsChecked状态。


![alt text](assets/recording-1.gif)


```xml

<control:VCheckBox Title="CHECKBOX LABEL"
                    IsIndeterminate="True"></control:VCheckBox>
```


## 变更图标

设置 `IconText`指定图标，图标的格式为Unicode字符或图标名称。默认为`\uF068`。

![alt text](assets/image-37.png)

```xml
<control:VCheckBox Title="CHECKBOX LABEL"
                   IconText="&#xf00d;"
                   IsChecked="True"></control:VCheckBox>
```



## 自定义内容

可以通过设置`ContentSlot`属性来设置CheckBox的自定义内容。设置此属性将覆盖原CheckBox中的图标。

带图标的CheckBox

![alt text](assets/image-38.png)


```xml
<control:VCheckBox Title="CHECKBOX LABEL">
    <control:VCheckBox.ContentSlot>
        <Image Source="aze.png"           
                HorizontalOptions="Center"
                VerticalOptions="Center"></Image>
    </control:VCheckBox.ContentSlot>
</control:VCheckBox>
```
