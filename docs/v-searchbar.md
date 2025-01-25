
# VSearchBar

搜索栏组件。


## 基础用法


基础的搜索栏用法

![alt text](assets/image-61.png)

```xml
<control:VSearchBar></control:VSearchBar>
```

## 关键字


设置 `Title` 指定关键字（标题）内容

![alt text](assets/image-68.png)

```xml
<control:VSearchBar Title="How to cook a delicious meal?"></control:VSearchBar>

```

## 占位文本


设置 `Placeholder` 指定占位文本内容

![alt text](assets/image-62.png)

```xml
<control:VSearchBar PlaceHolder="Enter order number"></control:VSearchBar>
```

## 隐藏搜索按钮


设置 `HasSearchButton` 为 `False` 属性即可隐藏搜索按钮。

![alt text](assets/image-63.png)

```xml
<control:VSearchBar HasSearchButton="False"></control:VSearchBar>

```

## 搜索按钮图标

设置 `IconText` 指定搜索按钮图标，图标的格式为Unicode字符或图标名称。默认为`\uF002`(放大镜)

![alt text](assets/image-64.png)

```xml
<control:VSearchBar IconText="&#xf130;"></control:VSearchBar>
```


## 标题颜色


使用`TitleColor`属性即可设置标题颜色

![alt text](assets/image-65.png)

```xml
<control:VSearchBar Title="How to cook a delicious meal?"
                    TitleColor="Brown"></control:VSearchBar>

```




## 自定义内容

使用`ContentSlot`设置搜索栏的后缀内容

![alt text](assets/image-66.png)

带图标和文本的后缀

```xml
<control:VSearchBar>
    <control:VSearchBar.ContentSlot>
        <HorizontalStackLayout HeightRequest="20">
            <Label Text="powered by"></Label>

            <Image Source="aze.png"
                   HorizontalOptions="Center"
                   VerticalOptions="Center"></Image>
            <Label Text="Flaming!!!"></Label>
        </HorizontalStackLayout>
    </control:VSearchBar.ContentSlot>
</control:VSearchBar>
```
