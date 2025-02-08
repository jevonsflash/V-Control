# VExpander

Expandable panel. Can collapse/expand the content area.

## Basic Usage

Basic usage of the expandable panel.

![alt text](assets/recording-16.gif)

```xml
<control:VExpander TitleText="Title">
    <control:VExpander.ContentSlot>
        <Label Text="Content"></Label>
    </control:VExpander.ContentSlot>
</control:VExpander>
```

## Title and Content

Use the `TitleText` property to set the title. The default title area consists of text and an expand indicator. To customize the title, use the `HeaderSlot` property.

Use `ContentSlot` to set the content.

![alt text](assets/recording-17.gif)
```xml
<control:VExpander IsExpanded="{Binding IsExpanded}">
    <control:VExpander.HeaderSlot>
        <Grid>

            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="7"></ColumnDefinition>
                <ColumnDefinition Width="1*"></ColumnDefinition>
                <ColumnDefinition Width="Auto"></ColumnDefinition>
            </Grid.ColumnDefinitions>

            <Rectangle Fill="{StaticResource Primary}"
                       WidthRequest="4"
                       HeightRequest="16"
                       HorizontalOptions="Center" />

            <Label Text="Expander Title"
                   Grid.Column="1"
                   VerticalOptions="Center">
            </Label>
            <Label Grid.Column="2"
                   IsVisible="{Binding IsExpanded}"
                   FontFamily="FontAwesome-Solid"
                   Text="&#xf0d7;"
                   WidthRequest="17"
                   VerticalOptions="Center" />


            <Label Grid.Column="2"
                   IsVisible="{Binding IsExpanded, Converter={StaticResource InvertedBoolConverter}}"
                   TextColor="{Binding MenuTextColor}"
                   FontFamily="FontAwesome-Solid"
                   Text="&#xf0d8;"
                   WidthRequest="17"
                   VerticalOptions="Center" />

        </Grid>

    </control:VExpander.HeaderSlot>
    <control:VExpander.ContentSlot>
        <Label Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lacus hendrerit risus ultrices himenaeos pulvinar. Nostra nostra nisl sed suspendisse turpis. Curabitur praesent sed nec phasellus accumsan. Parturient conubia imperdiet lorem orci aliquet."></Label>

    </control:VExpander.ContentSlot>
</control:VExpander>
```

## Expand Direction

Use the `ExpandDirection` property to set the expansion direction of the panel. Available directions:

* `Down` - Default value, expands downward
* `Up` - Expands upward

![alt text](assets/recording-18.gif)

```xml
 <control:VExpander TitleText="Title"
                    ExpandDirection="Up">
     <control:VExpander.ContentSlot>
         <Label Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lacus hendrerit risus ultrices himenaeos pulvinar. Nostra nostra nisl sed suspendisse turpis. Curabitur praesent sed nec phasellus accumsan. Parturient conubia imperdiet lorem orci aliquet."></Label>

     </control:VExpander.ContentSlot>
 </control:VExpander>
