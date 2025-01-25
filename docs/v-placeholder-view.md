
# VPlaceholderView

占位提示视图组件。常用于空状态占位提示，或者结果展示


## 基础用法


基础的占位提示视图用法


![alt text](assets/recording-19.gif)

```xml
<control:VPlaceholderView></control:VPlaceholderView>
```


## 标题

使用 `TitleText` 属性设置标题
使用 `ButtonText` 属性设置按钮文本


![alt text](assets/image-74.png)

```xml
<control:VPlaceholderView TitleText="Ops! Looks like there's nothing here yet. " ButtonText="Got it!"></control:VPlaceholderView>
```




## 自定义

使用`ContentSlot`设置自定义内容

![alt text](assets/image-75.png)

以图片作为内容

```xml
 <control:VPlaceholderView  TitleText="Ops! Looks like there's nothing here yet. ">
     <control:VPlaceholderView.ContentSlot>
         <Image Source="service3.jpg"
                WidthRequest="120"
                HeightRequest="120"></Image>
     </control:VPlaceholderView.ContentSlot>                
 </control:VPlaceholderView>

```


