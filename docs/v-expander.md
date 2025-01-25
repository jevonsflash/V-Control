
# VExpander

扩展面板。可以折叠/展开内容区域


## 基础用法


基础的扩展面板用法

![alt text](assets/recording-16.gif)

```xml
<control:VExpander TitleText="Title">
    <control:VExpander.ContentSlot>
        <Label Text="Content"></Label>
    </control:VExpander.ContentSlot>
</control:VExpander>
```


## 标题与内容


可以使用 `TitleText` 属性设置标题。默认的标题区域是由一个文字和展开指示器组成，如果需要自定义标题，可以使用 `HeaderSlot` 属性。

使用  `ContentSlot` 来设置内容。


![alt text](assets/recording-17.gif)
```xml
<control:VExpander IsExpanded="{Binding IsExpanded}">
    <control:VExpander.HeaderSlot>
        <Grid>

            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="7"></ColumnDefinition>
                <ColumnDefinition Width="1*"></ColumnDefinition>
                <ColumnDefinition Width="Auto"></ColumnDefinition>
            </Grid.ColumnDefinitions>

            <Rectangle Fill="{StaticResource Primary}"
                       WidthRequest="4"
                       HeightRequest="16"
                       HorizontalOptions="Center" />

            <Label Text="Expander Title"
                   Grid.Column="1"
                   VerticalOptions="Center">
            </Label>
            <Label Grid.Column="2"
                   IsVisible="{Binding IsExpanded}"
                   FontFamily="FontAwesome-Solid"
                   Text="&#xf0d7;"
                   WidthRequest="17"
                   VerticalOptions="Center" />


            <Label Grid.Column="2"
                   IsVisible="{Binding IsExpanded, Converter={StaticResource InvertedBoolConverter}}"
                   TextColor="{Binding MenuTextColor}"
                   FontFamily="FontAwesome-Solid"
                   Text="&#xf0d8;"
                   WidthRequest="17"
                   VerticalOptions="Center" />

        </Grid>

    </control:VExpander.HeaderSlot>
    <control:VExpander.ContentSlot>
        <Label Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lacus hendrerit risus ultrices himenaeos pulvinar. Nostra nostra nisl sed suspendisse turpis. Curabitur praesent sed nec phasellus accumsan. Parturient conubia imperdiet lorem orci aliquet."></Label>


    </control:VExpander.ContentSlot>
</control:VExpander>

```


## 展开方向

使用 `ExpandDirection` 属性设置扩展面板的展开方向。可使用的方向有：

* `Down` - 默认值，向下展开
* `Up` - 向上展开

![alt text](assets/recording-18.gif)


```xml
 <control:VExpander TitleText="Title"
                    ExpandDirection="Up">
     <control:VExpander.ContentSlot>
         <Label Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lacus hendrerit risus ultrices himenaeos pulvinar. Nostra nostra nisl sed suspendisse turpis. Curabitur praesent sed nec phasellus accumsan. Parturient conubia imperdiet lorem orci aliquet."></Label>

     </control:VExpander.ContentSlot>
 </control:VExpander>

```