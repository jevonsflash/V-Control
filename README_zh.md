
# V-Control

[![许可证](https://img.shields.io/badge/license-MIT-blue.svg?style=for-the-badge)](https://github.com/jevonsflash/VControl/blob/master/LICENSE)
[![nuget](https://img.shields.io/nuget/v/VControl.svg?style=for-the-badge)](https://www.nuget.org/packages/VControl)
![codeSize](https://img.shields.io/github/languages/code-size/jevonsflash/VControl.svg?style=for-the-badge)
![编程语言](https://img.shields.io/github/languages/top/jevonsflash/VControl.svg?style=for-the-badge)

[English](README.md) | 中文

V-Control是适用于[.NET MAUI](https://dotnet.microsoft.com/zh-cn/apps/maui) 的组件库(Component)，它提供了一组开箱即用的 UI 控件，可快速搭建面向业务的应用程序界面。

![alt text](/docs/assets/banner.png)


## 功能

* [VButton](https://vcontrol.matoapp.net/documents/v-button) - 按钮组件
* VCard - 卡片组件
* [VCheckableCollection](https://vcontrol.matoapp.net/documents/v-checkable-collection) - 可勾选的集合组件
* [VCheckBox](https://vcontrol.matoapp.net/documents/v-checkbox) - 复选框组件
* [VCheckBoxButton](https://vcontrol.matoapp.net/documents/v-checkbox-button) - 复选框按钮组件
* [VCheckBoxGroup](https://vcontrol.matoapp.net/documents/v-checkbox-group) - 复选框集合组件
* [VCollection](https://vcontrol.matoapp.net/documents/v-collection) - 集合视图组件
* VDateNativePicker - 原生封装的日期选择器组件
* [VDatePicker](https://vcontrol.matoapp.net/documents/v-date-picker) - 日期选择器组件
* [VEditor](https://vcontrol.matoapp.net/documents/v-editor) - 编辑器组件
* [VExpander](https://vcontrol.matoapp.net/documents/v-expander) - 展开收起组件
* [VFormItem](https://vcontrol.matoapp.net/documents/v-form-item) - 表单组件
* VIndicator - 进度指示器组件
* [VMenuCell](https://vcontrol.matoapp.net/documents/v-menu-cell) - 菜单项组件
* [VNumberEntry](https://vcontrol.matoapp.net/documents/v-number-entry) - 数字输入框组件
* [VPicker](https://vcontrol.matoapp.net/documents/v-picker) - 选择器组件
* VRadioButton - 单选框组件
* [VRadioButtonGroup](https://vcontrol.matoapp.net/documents/v-radio-button-group) - 单选框集合组件（切换栏组件）
* [VSearchBar](https://vcontrol.matoapp.net/documents/v-search-bar) - 搜索栏组件
* [VTagPicker](https://vcontrol.matoapp.net/documents/v-tag-picker) - 标签选择器组件
* [VTimeLine](https://vcontrol.matoapp.net/documents/v-time-line) - 时间轴组件
* [VTopAppBar](https://vcontrol.matoapp.net/documents/v-top-app-bar) - 顶栏组件
* VTouchContentView - 手势监听组件
* VUploader - 文件上传组件
* [VValidatingEntry](https://vcontrol.matoapp.net/documents/v-validating-entry) - 带验证的输入框组件
* [VValidatingPicker](https://vcontrol.matoapp.net/documents/v-validating-picker) - 带验证的选择器组件
* [VRichTextEditor](https://vcontrol.matoapp.net/documents/v-rich-text-editor) - 富文本编辑器组件
* [VEntry](https://vcontrol.matoapp.net/documents/v-entry) - 输入框组件
* [VPlaceholderView](https://vcontrol.matoapp.net/documents/v-placeholder-view) - 占位视图组件


## Todo

* VAutocomplete - 自动完成组件
* VComparisonView - 比较视图组件
* VCalendar - 日历组件
* 暗黑模式
* 基于 BlazorApp 的组件

## 快速开始

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

## 文档

前往[V-Control Docs](https://vcontrol.matoapp.net/documents/starter)

## 源码和示例

您可以前往[GitHub](https://github.com/jevonsflash/VControl)查看V-Control的源码和示例。

## Stargazers over time
[![Stargazers over time](https://starchart.cc/jevonsflash/V-Control.svg?variant=adaptive)](https://starchart.cc/jevonsflash/V-Control)