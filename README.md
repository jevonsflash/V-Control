# V-Control

[![License](https://img.shields.io/badge/license-MIT-blue.svg?style=for-the-badge)](https://github.com/jevonsflash/VControl/blob/master/LICENSE)
[![nuget](https://img.shields.io/nuget/v/VControl.svg?style=for-the-badge)](https://www.nuget.org/packages/VControl)
![codeSize](https://img.shields.io/github/languages/code-size/jevonsflash/VControl.svg?style=for-the-badge)
![Programming Language](https://img.shields.io/github/languages/top/jevonsflash/VControl.svg?style=for-the-badge)

English | [中文](README_zh.md)

V-Control is a component library for [ .NET MAUI](https://dotnet.microsoft.com/zh-cn/apps/maui), providing a set of out-of-the-box UI controls to quickly build business-oriented app interfaces.

![alt text](/docs/assets/banner.png)


## Features

* [VButton](https://vcontrol.matoapp.net/documents/v-button) - Button Component
* VCard - Card Component
* [VCheckableCollection](https://vcontrol.matoapp.net/documents/v-checkable-collection) - Checkable Collection Component
* [VCheckBox](https://vcontrol.matoapp.net/documents/v-checkbox) - Checkbox Component
* [VCheckBoxButton](https://vcontrol.matoapp.net/documents/v-checkbox-button) - Checkbox Button Component
* [VCheckBoxGroup](https://vcontrol.matoapp.net/documents/v-checkbox-group) - Checkbox Group Component
* [VCollection](https://vcontrol.matoapp.net/documents/v-collection) - Collection View Component
* VDateNativePicker - Native Date Picker Component
* [VDatePicker](https://vcontrol.matoapp.net/documents/v-date-picker) - Date Picker Component
* [VEditor](https://vcontrol.matoapp.net/documents/v-editor) - Editor Component
* [VExpander](https://vcontrol.matoapp.net/documents/v-expander) - Expander Component
* [VFormItem](https://vcontrol.matoapp.net/documents/v-form-item) - Form Component
* VIndicator - Progress Indicator Component
* [VMenuCell](https://vcontrol.matoapp.net/documents/v-menu-cell) - Menu Item Component
* [VNumberEntry](https://vcontrol.matoapp.net/documents/v-number-entry) - Number Entry Component
* [VPicker](https://vcontrol.matoapp.net/documents/v-picker) - Picker Component
* VRadioButton - Radio Button Component
* [VRadioButtonGroup](https://vcontrol.matoapp.net/documents/v-radio-button-group) - Radio Button Group Component (Toggle Bar)
* [VSearchBar](https://vcontrol.matoapp.net/documents/v-search-bar) - Search Bar Component
* [VTagPicker](https://vcontrol.matoapp.net/documents/v-tag-picker) - Tag Picker Component
* [VTimeLine](https://vcontrol.matoapp.net/documents/v-time-line) - Timeline Component
* [VTopAppBar](https://vcontrol.matoapp.net/documents/v-top-app-bar) - Top App Bar Component
* VTouchContentView - Gesture Listener Component
* VUploader - File Upload Component
* [VValidatingEntry](https://vcontrol.matoapp.net/documents/v-validating-entry) - Validating Entry Component
* [VValidatingPicker](https://vcontrol.matoapp.net/documents/v-validating-picker) - Validating Picker Component
* [VRichTextEditor](https://vcontrol.matoapp.net/documents/v-rich-text-editor) - Rich Text Editor Component
* [VEntry](https://vcontrol.matoapp.net/documents/v-entry) - Entry Component
* [VPlaceholderView](https://vcontrol.matoapp.net/documents/v-placeholder-view) - Placeholder View Component


## Todo

* VAutocomplete - Autocomplete Component
* VComparisonView - Comparison View Component
* VCalendar - Calendar Component
* Dark Mode
* BlazorApp-based Components

## Quick Start

1. Run the following command in your .NET MAUI project to install V-Control:
   
```bash
dotnet add package VControl
```

Or search for "V-Control" in NUGET and install it.


2. In `MauiProgram`, use `.UseVControl()` to add the V-Control handler in the MauiAppBuilder.

```csharp
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseVControl()   //👈 Add V-Control handler here
    var mauiApp = builder.Build();
    return mauiApp;
}
```

3. Open the `App.xaml` file and add `<v:VControlTheme />` to the resources.

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

## Documentation

Visit [V-Control Docs](https://vcontrol.matoapp.net/documents/starter)

## Source Code and Samples

You can visit the [GitHub](https://github.com/jevonsflash/VControl) to view the source code and examples for V-Control.

## Stargazers over time
[![Stargazers over time](https://starchart.cc/jevonsflash/V-Control.svg?variant=adaptive)](https://starchart.cc/jevonsflash/V-Control)