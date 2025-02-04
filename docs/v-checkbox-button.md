
# VCheckBoxButton

在两种状态之间切换的按钮，通常用于有两个相互排斥的简单状态(例如“开”和“关”)的情况。

## 基础用法


基础的CheckBoxButton用法，使用

![alt text](assets/recording-21.gif)



使用 `IsChecked` 属性来设置是否选中。此属性为双向数据绑定属性。


```xml
<control:VCheckBoxButton Title="CHECKBOX BUTTON" IsChecked="True"></control:VCheckBoxButton>
```

## 禁用状态


多选框不可用状态。

设置 `IsEnabled`属性为 `False` 即可。

![alt text](assets/image-84.png)


```xml
<control:VCheckBoxButton Title="CHECKBOX BUTTON"
                            IsEnabled="False"></control:VCheckBoxButton>
```




## 自定义内容

可以通过设置`ContentSlot`属性来设置CheckBoxButton的自定义内容。

带图标的CheckBox

![alt text](assets/recording-22.gif)


```xml
<control:VCheckBoxButton Title="CHECKBOX BUTTON"
                         IsChecked="True">

    <control:VCheckBoxButton.ContentSlot>
        <VerticalStackLayout>
            <Image Source="download.png"
                   IsVisible="{Binding IsChecked}"
                   HorizontalOptions="Center"
                   VerticalOptions="Center"></Image>
            <Image Source="sketch.png"
                   IsVisible="{Binding IsChecked, Converter={StaticResource InvertedBoolConverter}}"
                   HorizontalOptions="Center"
                   VerticalOptions="Center"></Image>
            <Label Text="{Binding IsChecked}"
                   HorizontalOptions="Center">
                <Label.FormattedText>
                    <FormattedString>
                        <Span Text="Check State"></Span>
                        <Span Text=" : "></Span>
                        <Span Text="{Binding IsChecked}"></Span>
                    </FormattedString>
                </Label.FormattedText>
            </Label>
        </VerticalStackLayout>
    </control:VCheckBoxButton.ContentSlot>
</control:VCheckBoxButton>
```
