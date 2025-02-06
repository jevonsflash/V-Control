# 开始

## 介绍

V-Control是适用于[.NET MAUI](https://dotnet.microsoft.com/zh-cn/apps/maui) 的组件库(Component)，或在微软体系下称其为[控件库(Control)](https://learn.microsoft.com/zh-cn/dotnet/maui/user-interface/controls/?view=net-maui-9.0)，它提供了一组开箱即用的 UI 控件，可快速搭建面向业务的应用程序界面。



## 安装

1. 在你的.NET MAUI 项目中执行以下命令来安装 V-Control：
   
```bash
dotnet add package VControl
```

或在NUGET中搜索"V-Control"并安装它。


2. 在 `MauiProgram` 使用`.UseVControl()`在MauiAppBuilder中添加V-Control的处理程序。



```csharp
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseVControl()   //👈在这里添加V-Control的处理程序
    var mauiApp = builder.Build();
    return mauiApp;
}
```

3. 打开 `App.xaml` 文件， 在资源中添加`<v:VControlTheme />`。

```xml

<?xml version = "1.0" encoding = "UTF-8" ?>
<Application xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:v="clr-namespace:VControl.Styles;assembly=VControl">
    <Application.Resources>
        <v:VControlTheme />
        ...
    </Application.Resources>   
</Application>

```

## 使用


在XAML中使用V-Control，首先在页面根元素中定义VControl.Controls的命名空间

```xml
xmlns:v="clr-namespace:VControl.Controls;assembly=VControl"
```
命名空间前缀`v`可以使用其他的字符来代替。

在使用V-Control控件时，你可以使用`v:`前缀来引用控件。

![alt text](assets/image-39.png)

## 源码和示例

您可以前往[GitHub](https://github.com/jevonsflash/VControl)查看V-Control的源码和示例。