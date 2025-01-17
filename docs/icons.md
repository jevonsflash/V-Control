# 图标

V-Control引入了Font Awesome 6的三个字符集，用于显示图标。

字体文件的路径为：

```
.\src\Resources\Fonts\Font_Awesome_6_Brands-Regular-400.otf
.\src\Resources\Fonts\Font_Awesome_6_Free-Regular-400.otf
.\src\Resources\Fonts\Font_Awesome_6_Free-Solid-900.otf
```

分别对应了三个别称：

* `"FontAwesome-Regular"`
* `"FontAwesome-Solid"`
* `"FontAwesome-Brands"`


## 使用


在XAML中，您可以指定任何可显示文本的控件显示图标，如：Label， Button， Editor

1. 设置 `FontFamily` 属性为 `"FontAwesome-Solid"`或其他字符集别称
2. 设置 `Text` 属性为图标的名称或图标的Unicode编码
   
图标的名称和图标的Unicode编码都可以指向同一个图标，也就是如下写法是等效的：


名称

```xml

  <Label FontFamily="FontAwesome-Solid"
         Text="user"></Label>
```

Unicode 编码

```xml
  <Label FontFamily="FontAwesome-Solid"
         Text="&#xf007;"></Label>
```



可以通过绑定来动态设置图标，在CodeBehind需要使用Unicode编码的转义字符形式

```xml
 <DataTemplate>
     <Grid RowDefinitions="*,auto"
           Margin="20,2.5">
         <Label TextColor="{Binding TextColor}"
                FontFamily="{Binding FontFamily}"
                FontAttributes="Bold"
                FontSize="40"
                HorizontalOptions="Center"
                Text="{Binding Icon}"></Label>
         <Label Text="{Binding Title}"
                Grid.Row="1"
                HorizontalOptions="Center"
                Style="{StaticResource ItemDetailsLabel}" />
     </Grid>
 </DataTemplate>
```

CodeBehind

```C#
IconItemList = new ObservableCollection<dynamic>(){
    new { Title= "house"  , Icon="\uF015", TextColor="Red",  FontFamily="FontAwesome-Solid"},
    new { Title= "magnifying-glass"  , Icon="\uF002", TextColor="green",  FontFamily="FontAwesome-Solid" },
    new { Title= "user"  , Icon="\uF007", TextColor="orange" ,  FontFamily="FontAwesome-Solid"},
    new { Title= "facebook"  , Icon="\uF09a", TextColor="blue" ,  FontFamily="FontAwesome-Brands"},
    new { Title= "check"  , Icon="\uF00c", TextColor="green" ,  FontFamily="FontAwesome-Solid"},
    new { Title= "download"  , Icon="\uF019", TextColor="Red",  FontFamily="FontAwesome-Solid" },
};
```

效果如下：

![alt text](assets/image-24.png)

## 如何查找你需要的图标的编码和字符集？



前往Font Awesome 6的官方站点（https://fontawesome.com/search）

搜索框中输入图标名称，回车键搜索

![alt text](assets/image-22.png)

点击你需要的图标，在弹出的窗口中，找到Unicode编码，复制即可

下方的示例代码中显示了图标所在的字符集


