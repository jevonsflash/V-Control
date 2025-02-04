
# VTimeLine

可视化地呈现时间流信息。


## 基础用法


使用 `ItemsSource` 属性来绑定数据。


![alt text](assets/image-77.png)




数据源的条目可通过如下属性控制时间流信息：

```
string Title  - 标题

string Details - 详情

string Date - 日期

TimeLineItemType Type - 节点样式类型

Color TitleColor - 标题颜色
```

其中 `TimeLineItemType` 为枚举类型，包含以下几种：

* Normal - 普通节点样式
* Active - 当前节点样式
* Success - 成功节点样式


```xml
<control:VTimeLine ItemsSource="{Binding ProBarList}"></control:VTimeLine>
```


ViewModel:

```csharp
this.ProBarList = new ObservableCollection<ITimeLineItemModel>()
{
    new TimeLineItemModel()
    {
        Date = now.AddDays(-2).ToString("G"),
        Title = "Event start",
        Type = TimeLineItemType.Normal,
    },
    new TimeLineItemModel()
    {
        Date = now.AddDays(-1).ToString("G"),
        Title = "Approved",
        Type = TimeLineItemType.Active,
    },
    new TimeLineItemModel()
    {
        Date = now.ToString("G"),
        Title = "Success",
        Type = TimeLineItemType.Success,
    },
};
```

## 标题颜色


通过绑定对象的 `TitleColor` 属性即可设置标题颜色。

![alt text](assets/image-78.png)


ViewModel:

```csharp
new TimeLineItemModel()
{
    Date = now.ToString("G"),
    Title = "Event start",
    TitleColor = Colors.Red,
    Type = TimeLineItemType.Normal,
},
```

## 详情内容


通过绑定对象的 `Details` 属性即可设置详情内容。

![alt text](assets/image-79.png)


ViewModel:

```csharp
new TimeLineItemModel()
{
    Date = now.ToString("G"),
    Title = "Event start",
    Details="Gary accepted merge request!! ",
    TitleColor = Colors.Green,
    Type = TimeLineItemType.Normal,
},   
```

