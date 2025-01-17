
# V-Button

常用的操作按钮。


## 基础用法


基础的按钮用法

![alt text](assets/image-26.png)

```
<control:VButton TitleText="BUTTON"></control:VButton>
````

## 样式

使用`ButtonStyle`属性来控制按钮的样式类型。


控件提供以下几种按钮类型：

* Primaryn - 基本按钮
* Text - 文本按钮
* Outlined - 线框按钮
* Light - 轻盈按钮（淡背景色）

![alt text](assets/image-27.png)


```
<control:VButton TitleText="BUTTON"
                 ButtonStyle="Light"></control:VButton>
<control:VButton TitleText="BUTTON"
                 ButtonStyle="Outlined"></control:VButton>
<control:VButton TitleText="BUTTON"
                 ButtonStyle="Primary"></control:VButton>
<control:VButton TitleText="BUTTON"
                 ButtonStyle="Text"></control:VButton>
```

## 禁用状态

![alt text](assets/image-28.png)

```
<control:VButton TitleText="BUTTON"
                    IsEnabled="False"></control:VButton>
```


## 忙碌状态

![alt text](assets/recording.gif)

```
<control:VButton TitleText="BUTTON"
                    IsEnabled="False"></control:VButton>
```

## 自定义内容

可以通过设置`ContentSlot`属性来设置按钮的自定义内容。设置此属性将覆盖原按钮中的文本。

带图标的按钮

![alt text](assets/image-29.png)

```xml
<control:VButton WidthRequest="92"
                HeightRequest="92">
    <control:VButton.ContentSlot>
        <Grid>
            <Label TextColor="{StaticResource OnPrimary}"
                HorizontalOptions="Center"
                VerticalOptions="Center"
                FontSize="{StaticResource HeaderFontSize}"
                FontFamily="FontAwesome-Solid"
                Text="&#xf007;"></Label>

            <Label TextColor="{StaticResource OnPrimary}"
                FontAttributes="Bold"
                HorizontalOptions="Center"
                VerticalOptions="End"
                Text="BUTTON"></Label>
        </Grid>
    </control:VButton.ContentSlot>
</control:VButton>
```

图片按钮

![alt text](assets/image-31.png)

```
<control:VButton>
    <control:VButton.ContentSlot>
        <Image Source="service3.jpg"></Image>
    </control:VButton.ContentSlot>
</control:VButton>
```

Tile风格的按钮

![alt text](assets/image-30.png)

```xml
<control:VButton ButtonBackground="#0C3F93">
    <control:VButton.ContentSlot>
        <Grid>
            <Image Source="doc.png"
                   Margin="20"
                   HorizontalOptions="Center"
                   VerticalOptions="Center"></Image>
            <Label  TextColor="{StaticResource OnPrimary}"
                    HorizontalOptions="Start"
                    VerticalOptions="End"
                    Text="Word"></Label>
        </Grid>
    </control:VButton.ContentSlot>
</control:VButton>
```

FAB按钮

![alt text](assets/image-32.png)


```xml
<control:VButton Grid.Column="0"
                 HeightRequest="82"
                 WidthRequest="82"
                 ButtonBackground="{StaticResource SecondaryContainer}">
    <control:VButton.ContentSlot>
        <Label TextColor="{StaticResource OnSecondaryContainer}"
               HorizontalOptions="Center"
               VerticalOptions="Center"
               FontSize="{StaticResource HeaderFontSize}"
               FontFamily="FontAwesome-Solid"
               Text="&#x2b;"></Label>
    </control:VButton.ContentSlot>
    <control:VButton.Shadow>
        <Shadow Brush="Black"
                Offset="0,1"
                Radius="2"
                Opacity="0.3" />
    </control:VButton.Shadow>
</control:VButton>
```
导航栏按钮

![alt text](assets/image-34.png)

```xml
<control:VButton ButtonStyle="Text"
                HeightRequest="92">
    <control:VButton.ContentSlot>
        <Grid RowSpacing="0"
            RowDefinitions="1.3*,1*">
            <Border StrokeShape="{StaticResource MediumRoundRectangle}"
                    StrokeThickness="0"
                    BackgroundColor="{StaticResource  Gray200}">
                <Label TextColor="{StaticResource OnSurface}"
                    HorizontalOptions="Center"
                    VerticalOptions="Center"
                    FontSize="{StaticResource HeaderFontSize}"
                    FontFamily="FontAwesome-Solid"
                    Text="&#xf007;"></Label>
            </Border>
            <Label Grid.Row="1"
                TextColor="{StaticResource OnSurface}"
                FontAttributes="Bold"
                HorizontalOptions="Center"
                VerticalOptions="End"
                Text="BUTTON"></Label>
        </Grid>

    </control:VButton.ContentSlot>
</control:VButton>

```
