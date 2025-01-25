
# VNumberEntry

数字编辑框组件，仅允许输入标准的数字值，可定义范围。


## 基础用法


基础的数字编辑框用法

![alt text](assets/image-69.png)

```xml
<control:VNumberEntry></control:VNumberEntry>
```

## 值


设置 `Value` 指定数字编辑框当前的值

![alt text](assets/image-70.png)


```xml
<control:VNumberEntry Value="50"></control:VNumberEntry>

```


## 步进

允许定义递增递减的步进控制，设置 `Digits` 指定步进的精度的小数位，默认为`0`，即整数步进

![alt text](assets/image-71.png)


```xml
<control:VNumberEntry Digits="2"></control:VNumberEntry>
```


如果当前输入值的精度高于 `Digits` 属性指定的精度，则会使用“四舍五入”截断。

![alt text](assets/recording-15.gif)


## 最大值


设置 `Maximum` 指定数字编辑框的最大值，增加按钮和输入的值都不允许超过该值，默认为`100`

![alt text](assets/recording-13.gif)

```xml
<control:VNumberEntry Maximum="10"></control:VNumberEntry>
```


## 最小值


设置 `Minimum` 指定数字编辑框的最小值，减少按钮和输入的值都不允许低于该值，默认为`0`

![alt text](assets/recording-14.gif)

```xml
<control:VNumberEntry Minimum="10"></control:VNumberEntry>
```


## 禁用状态


使控件处于不可用状态。

设置 `IsEnabled`属性为 `False` 即可。


![alt text](assets/image-72.png)

```xml
<control:VNumberEntry IsEnabled="False"></control:VNumberEntry>
```

## 占位文本


设置 `EntryPlaceholder` 指定占位文本内容

![alt text](assets/image-73.png)

```xml
<control:VNumberEntry EntryPlaceholder="Please enter quantities"></control:VNumberEntry>
```


## 只读状态


使文本编辑框处于只读状态

设置 `EntryIsReadOnly`为 `True` 属性即可。


```xml

<control:VNumberEntry EntryIsReadOnly="True"></control:VNumberEntry>

```



## 自定义内容

使用`ContentSlot`设置编辑框的后缀内容

![alt text](assets/image-66.png)

带图标和文本的后缀

```xml
<control:VNumberEntry>
    <control:VNumberEntry.ContentSlot>
        <HorizontalStackLayout HeightRequest="20">
            <Image Source="aze.png"
                HorizontalOptions="Center"
                VerticalOptions="Center"></Image>
            <Label Text="Calories"></Label>
        </HorizontalStackLayout>
    </control:VNumberEntry.ContentSlot>
</control:VNumberEntry>
```
