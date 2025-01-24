
# V-Entry

常用的文本编辑框组件。


## 基础用法


基础的文本输入用法

![alt text](assets/image-40.png)

```xml
<control:VEntry></control:VEntry>
```

## 占位文本


设置 `Placeholder` 指定占位文本内容

![alt text](assets/image-41.png)

```xml
<control:VEntry EntryPlaceholder="User Name"></control:VEntry>
```

## 图标


设置 `EntryIconText` 指定图标，图标的格式为Unicode字符或图标名称。默认为空



![alt text](assets/image-42.png)

```xml
<control:VEntry EntryIconText="&#xf007;"></control:VEntry>

```

## 只读状态


使文本编辑框处于只读状态

设置 `EntryIsReadOnly`为 `True` 属性即可。


![alt text](assets/image-43.png)

```xml
<control:VEntry EntryIsReadOnly="True"
                EntryText="Read Only Text !"></control:VEntry>

```


## 密码框


使用`EntryIsPassword`属性即可得到一个可切换显示隐藏的密码框

![alt text](assets/image-44.png)


```xml
<control:VEntry EntryIsPassword="True"
                EntryText="Passw0rd!"></control:VEntry>
```

## 输入长度限制


使用`EntryMaxLength`属性设置文本框的最大输入长度


![alt text](assets/image-45.png)

```xml
<control:VEntry  EntryMaxLength="8"
                    EntryText="12345678"></control:VEntry>

```


## 前缀和后缀

使用`ContentSlot`和`PrefixSlot`属性设置文本框的前缀和后缀内容

![alt text](assets/image-46.png)

带图标和单位文本的后缀

```xml

 <control:VEntry EntryText="123">

     <control:VEntry.ContentSlot>
         <HorizontalStackLayout HeightRequest="20">
             <Image Source="aze.png"
                    HorizontalOptions="Center"
                    VerticalOptions="Center"></Image>
             <Label Text="Calories"></Label>
         </HorizontalStackLayout>
     </control:VEntry.ContentSlot>
 </control:VEntry>
```

美元符号（$）的前缀

```xml
 <control:VEntry EntryText="123">

     <control:VEntry.PrefixSlot>
         <Border Margin="0,5"
                 Padding="15,5"
                 Background="{StaticResource SurfaceVariant}">
             <Label Text="$"
                    FontSize="18"
                    FontAttributes="Bold"
                    VerticalOptions="Center"></Label>
         </Border>
     </control:VEntry.PrefixSlot>
 </control:VEntry>
```

带网址的前缀和搜索图标的前缀

```xml
 <control:VEntry EntryText="www.matoapp.net">

     <control:VEntry.PrefixSlot>
         <Border Margin="0,5"
                 Padding="5"
                 Background="{StaticResource SurfaceVariant}">
             <Label Text="Http://"
                    VerticalOptions="Center"></Label>
         </Border>
     </control:VEntry.PrefixSlot>
     <control:VEntry.ContentSlot>
         <Border Margin="0,5"
                 Padding="15,5"
                 Background="{StaticResource SurfaceVariant}">
             <Label 
                    FontFamily="FontAwesome-Solid"
                    Text="&#xf002;"                             
                    VerticalOptions="Center" />
         </Border>
     </control:VEntry.ContentSlot>
 </control:VEntry>
```