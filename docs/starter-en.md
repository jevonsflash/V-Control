# Start

## Introduction

V-Control is a component library for .NET MAUI, or in Microsoft's ecosystem, it is referred to as a [Control Library](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/?view=net-maui-9.0). It provides a set of out-of-the-box UI controls that enable rapid creation of business-oriented application interfaces.

## Installation

1. Run the following command in your .NET MAUI project to install V-Control:
   
```bash
dotnet add package VControl
```

Or search for "V-Control" in NUGET and install it.

2. Open the `AppShell.xaml` file and use `.UseVControl()` in `MauiAppBuilder` to add the V-Control handler.

The following code:

```csharp
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseVControl()   //👈 Add the V-Control handler here
    var mauiApp = builder.Build();
    return mauiApp;
}
```

3. Open the `App.xaml` file, and define the `VControl.Styles` namespace within `<Application>`.

The following code:

```xml
<?xml version = "1.0" encoding = "UTF-8" ?>
<Application xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:v="clr-namespace:VControl.Styles;assembly=VControl" 
...
</Application>
```

Add `VControlTheme` inside the `<Application.Resources>` tag.

```xml
<Application.Resources>
    <v:VControlTheme />
    ...
</Application.Resources>   
```

## Usage

To use V-Control in XAML, first define the `VControl.Controls` namespace in the root element of the page:

```xml
xmlns:v="clr-namespace:VControl.Controls;assembly=VControl"
```

The namespace prefix `v` can be replaced with other characters.

When using V-Control components, you can reference controls with the `v:` prefix.

![alt text](assets/image-39.png)

## Source Code and Examples

You can visit [GitHub](https://github.com/jevonsflash/VControl) to check out the source code and examples of V-Control.
