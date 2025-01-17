# 颜色系统

## 说明

V-Control中的颜色是从 Material Design 设计体系中导入的，并且遵循 Material Design 语义化变量名称。您可以使用这些颜色来创建您自己的主题。

颜色的资源字典路径为
```
.\src\Resources\Styles\VControlColors.xaml
```


## 标准色

有 21 种标准颜色，分为六组：主要（Primary）、次要（Secondary）、第三（Tertiary）、背景（Background）、表面（Surface）和轮廓（Outline）

![alt text](assets/image-19.png)

标准色语义定义：

* Surface – 用于背景和屏幕的大面积低重点区域的角色。
* Primary， Secondary， Tertiary – 用于强调或取消强调前景元素的强调色角色。
* Container  – 用作按钮等前景元素的填充颜色的角色。它们不应用于文本或图标。
* On – 以此术语开头的角色指示其配对父颜色之上的文本或图标的颜色。例如，on primary 用于文本和图标与主要填充颜色相对应。
* Variant – 以此术语结尾的角色提供其非变体对的较低强调替代项。例如，轮廓变体是轮廓颜色的不太强调的版本。

标准色资源如下所示，你可以以此为基础创建自己的主题。

```xml

<Color x:Key="Primary">#FF7415</Color>
<Color x:Key="OnPrimary">#FFFFFF</Color>
<Color x:Key="PrimaryContainer">#FEF4EA</Color>
<Color x:Key="OnPrimaryContainer">#ED6103</Color>

<Color x:Key="Secondary">#f38e47</Color>
<Color x:Key="OnSecondary">#FFFFFF</Color>
<Color x:Key="SecondaryContainer">#FEF4EA</Color>
<Color x:Key="OnSecondaryContainer">#EB6B13</Color>

<Color x:Key="Tertiary">#FDDB3A</Color>
<Color x:Key="OnTertiary">#2C3639</Color>
<Color x:Key="TertiaryContainer">#786301</Color>
<Color x:Key="OnTertiaryContainer">#fef1b0</Color>

<Color x:Key="Surface">#FFFFFF</Color>
<Color x:Key="OnSurface">#3F4E4F</Color>
<Color x:Key="SurfaceVariant">#E7E0EC</Color>
<Color x:Key="OnSurfaceVariant">#49454E</Color>

<Color x:Key="Background">#F5F5F5</Color>
<Color x:Key="OnBackground">#1C1B1F</Color>

<Color x:Key="Outline">#E1E1E1</Color>
<Color x:Key="OutlineVariant">#C4C7C5</Color>
<Color x:Key="Shadow">#000000</Color>

```

## 辅助色

除了主色外的场景色，需要在不同的场景中使用（例如危险色表示危险的操作）。


![alt text](assets/image-20.png)




辅助色资源如下所示，你可以以此为基础创建自己的主题。

```xml
<Color x:Key="Error">#B3261E</Color>
<Color x:Key="ErrorContainer">#F9DEDC</Color>

<Color x:Key="Success">#01ae54</Color>
<Color x:Key="SuccessContainer">#a8eac0</Color>

<Color x:Key="Warning">#F7B548</Color>
<Color x:Key="WarningContainer">#FFE5B9</Color>

<Color x:Key="DisabledText">#ba919191</Color>
<Color x:Key="PlaceHolderText">#E0E0E0</Color>
<Color x:Key="DisabledBackground">#80919191</Color>
```


## 中性色

中性色用于文本、背景和边框颜色。通过运用不同的中性色，来表现层次结构。


![alt text](assets/image-21.png)



中性色资源如下所示，你可以以此为基础创建自己的主题。
```xml
<Color x:Key="White">White</Color>
<Color x:Key="Black">Black</Color>

<Color x:Key="Gray50">#F8F8F8</Color>
<Color x:Key="Gray60">#F7F7F7</Color>
<Color x:Key="Gray100">#F5F5F5</Color>
<Color x:Key="Gray120">#F3F3F3</Color>
<Color x:Key="Gray150">#F1F1F1</Color>
<Color x:Key="Gray170">#F0F0F0</Color>
<Color x:Key="Gray190">#E1E1E1</Color>
<Color x:Key="Gray200">#E0E0E0</Color>
<Color x:Key="Gray230">#B7B7B7</Color>
<Color x:Key="Gray240">#B5B5B5</Color>
<Color x:Key="Gray250">#B3B3B3</Color>
<Color x:Key="Gray270">#AEAEAE</Color>
<Color x:Key="Gray300">#ACACAC</Color>
<Color x:Key="Gray360">#A6A6A6</Color>
<Color x:Key="Gray380">#919191</Color>
<Color x:Key="Gray400">#848381</Color>
<Color x:Key="Gray500">#6E6E6E</Color>
<Color x:Key="Gray550">#666666</Color>
<Color x:Key="Gray600">#404040</Color>
<Color x:Key="Gray900">#212121</Color>
<Color x:Key="Gray950">#141414</Color>
```
