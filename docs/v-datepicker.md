
# V-DatePicker

用于选择或输入日期


## 基础用法


日期选择器的基础用法


![alt text](assets/image-58.png)


```xml
<control:VDatePicker></control:VDatePicker>

```


## 选择日期模式


可以使用`SelectionMode`属性来设置选择日期的模式。
可用的选择模式有：

* Single - 单选
* Multiple - 多选
* Range - 范围选择


单选

![alt text](assets/recording-7.gif)

多选

![alt text](assets/recording-8.gif)

范围选择

![alt text](assets/recording-9.gif)

```xml
<control:VDatePicker SelectionMode="Multiple"></control:VDatePicker>

```


## 默认值​

日期选择器默认不会选中任何日期。 可以使用`SelectedDate`来设置默认的日期。

`SelectedDate`是双向数据绑定的属性，在单选模式下，变更选择的日期后会更新`SelectedDate`的值。


![alt text](assets/image-57.png)


```xml
<control:VDatePicker SelectedDate="{Binding CurrentDate}"></control:VDatePicker>

```



## 禁用状态


使控件进入不可用状态。

设置 `IsEnabled`属性为 `False` 即可。

![alt text](assets/image-59.png)


```xml
<control:VDatePicker IsEnabled="False"></control:VDatePicker>

```


## 方法

可供调用的方法有：

* SetAll(bool isAll) - 设置是否全选/取消全选当前视图月份
* TrySetSelectedDate(bool isSelected, DateTime date) - 设置选中的日期
* JumpToDate(DateTime date) - 控件视图跳转到指定日期所在的月份


![alt text](assets/recording-10.gif)

CodeBehind

```csharp

private void TextCell_Tapped(object sender, EventArgs e)
{
    MainDatePicker.SetAll(false);
}

private void TextCell_Tapped_1(object sender, EventArgs e)
{
    MainDatePicker.SetAll(true);

}

private void TextCell_Tapped_2(object sender, EventArgs e)
{
    MainDatePicker.TrySetSelectedDate((sender as SwitchCell).On, DateTime.Now);
}
private void TextCell_Tapped_3(object sender, EventArgs e)
{
    MainDatePicker.JumpToDate(DateTime.Now);
}
```


## 与按钮联动

通过双向绑定`SelectedDates`属性，在ViewModel中响应和处理数据变化，实现与按钮联动。

![alt text](assets/recording-11.gif)


```xml
<control:VDatePicker SelectionChangedCommand="{Binding DateRangeSelectionChangedCommand}"
                        SelectedDates="{Binding Dates}"
                        SelectionMode="Range" />

```

ViewModel

```csharp

private void UpdateDateTime(SearchItemM tempDateRange)
{
    var now = DateTime.Now;
    if (tempDateRange == null)
    {
        StartDate = default;
        EndDate = default;
    }
    else
    {
        switch (tempDateRange.Id)
        {
            case "Today":
                StartDate = now;
                EndDate = now;
                break;
            case "Last3":
                StartDate = now.AddDays(-3);
                EndDate = now.AddDays(-1);
                break;
            case "Next3":
                StartDate = now.AddDays(1);
                EndDate = now.AddDays(3);
                break;
            case "RecentWeek":
                StartDate = now.AddDays(-7);
                EndDate = now.AddDays(-1);
                break;
            case "NextWeek":
                StartDate = now.AddDays(1);
                EndDate = now.AddDays(7);
                break;
            case "RecentMonth":
                StartDate = now.AddDays(-30);
                EndDate = now.AddDays(-1);
                break;
            case "NextMonth":
                StartDate = now.AddDays(1);
                EndDate = now.AddDays(30);
                break;
        }
    }
}

```