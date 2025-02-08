# VSearchBar

Search Bar Component

## Basic Usage

Basic usage of the search bar.

![alt text](assets/image-61.png)

```xml
<control:VSearchBar></control:VSearchBar>
```

## Keyword

Set the `Title` to specify the keyword (title) content.

![alt text](assets/image-68.png)

```xml
<control:VSearchBar Title="How to cook a delicious meal?"></control:VSearchBar>
```

## Placeholder Text

Set the `Placeholder` to specify the placeholder text content.

![alt text](assets/image-62.png)

```xml
<control:VSearchBar PlaceHolder="Enter order number"></control:VSearchBar>
```

## Hide Search Button

Set the `HasSearchButton` property to `False` to hide the search button.

![alt text](assets/image-63.png)

```xml
<control:VSearchBar HasSearchButton="False"></control:VSearchBar>
```

## Search Button Icon

Set the `IconText` to specify the search button icon. The icon can be a Unicode character or an icon name. The default is `\uF002` (magnifying glass).

![alt text](assets/image-64.png)

```xml
<control:VSearchBar IconText="&#xf130;"></control:VSearchBar>
```

## Title Color

Use the `TitleColor` property to set the title color.

![alt text](assets/image-65.png)

```xml
<control:VSearchBar Title="How to cook a delicious meal?"
                    TitleColor="Brown"></control:VSearchBar>
```

## Custom Content

Use `ContentSlot` to set the suffix content for the search bar.

![alt text](assets/image-66.png)

Suffix with an icon and text:

```xml
<control:VSearchBar>
    <control:VSearchBar.ContentSlot>
        <HorizontalStackLayout HeightRequest="20">
            <Label Text="powered by"></Label>

            <Image Source="aze.png"
                   HorizontalOptions="Center"
                   VerticalOptions="Center"></Image>
            <Label Text="Flaming!!!"></Label>
        </HorizontalStackLayout>
    </control:VSearchBar.ContentSlot>
</control:VSearchBar>
```
