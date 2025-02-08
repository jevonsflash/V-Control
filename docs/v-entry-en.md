# VEntry 

A commonly used text entry component.

## Basic Usage

Basic text input usage

![alt text](assets/image-40.png)

```xml
<control:VEntry></control:VEntry>
```

## Placeholder Text

Set `Placeholder` to specify the placeholder text content.

![alt text](assets/image-41.png)

```xml
<control:VEntry EntryPlaceholder="User Name"></control:VEntry>
```

## Icon

Set `EntryIconText` to specify an icon. The format of the icon can be a Unicode character or an icon name. The default is empty.

![alt text](assets/image-42.png)

```xml
<control:VEntry EntryIconText="&#xf007;"></control:VEntry>
```

## Read-Only Mode

Make the text entry box read-only.

Set the `EntryIsReadOnly` property to `True`.

![alt text](assets/image-43.png)

```xml
<control:VEntry EntryIsReadOnly="True"
                EntryText="Read Only Text !"></control:VEntry>
```

## Password Entry

Use the `EntryIsPassword` property to create a password entry with a toggleable visibility option.

![alt text](assets/image-44.png)

```xml
<control:VEntry EntryIsPassword="True"
                EntryText="Passw0rd!"></control:VEntry>
```

## Input Length Limit

Use the `EntryMaxLength` property to set the maximum input length of the text box.

![alt text](assets/image-45.png)

```xml
<control:VEntry  EntryMaxLength="8"
                    EntryText="12345678"></control:VEntry>
```

## Prefix and Suffix

Use the `ContentSlot` and `PrefixSlot` properties to set prefix and suffix content for the text box.

![alt text](assets/image-46.png)

### Suffix with Icon and Text

```xml
 <control:VEntry EntryText="123">

     <control:VEntry.ContentSlot>
         <HorizontalStackLayout HeightRequest="20">
             <Image Source="aze.png"
                    HorizontalOptions="Center"
                    VerticalOptions="Center"></Image>
             <Label Text="Calories"></Label>
         </HorizontalStackLayout>
     </control:VEntry.ContentSlot>
 </control:VEntry>
```

### Prefix with Dollar Sign ($)

```xml
 <control:VEntry EntryText="123">

     <control:VEntry.PrefixSlot>
         <Border Margin="0,5"
                 Padding="15,5"
                 Background="{StaticResource SurfaceVariant}">
             <Label Text="$"
                    FontSize="18"
                    FontAttributes="Bold"
                    VerticalOptions="Center"></Label>
         </Border>
     </control:VEntry.PrefixSlot>
 </control:VEntry>
```

### Prefix with URL and Search Icon

```xml
 <control:VEntry EntryText="www.matoapp.net">

     <control:VEntry.PrefixSlot>
         <Border Margin="0,5"
                 Padding="5"
                 Background="{StaticResource SurfaceVariant}">
             <Label Text="Http://"
                    VerticalOptions="Center"></Label>
         </Border>
     </control:VEntry.PrefixSlot>
     <control:VEntry.ContentSlot>
         <Border Margin="0,5"
                 Padding="15,5"
                 Background="{StaticResource SurfaceVariant}">
             <Label 
                    FontFamily="FontAwesome-Solid"
                    Text="&#xf002;"                             
                    VerticalOptions="Center" />
         </Border>
     </control:VEntry.ContentSlot>
 </control:VEntry>
