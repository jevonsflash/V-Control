# VMenuCell

V-MenuCell is a wrapper around ViewCell that can be used as a list item in TableSection, typically serving as a menu option.

## Basic Usage

The default style of V-MenuCell is:

![alt text](assets/image-47.png)

Set the `MenuText` property to specify the menu text content and the `IconText` property to specify the icon. The icon format can be a Unicode character or an icon name.

By binding the `Command` and `CommandParameter` properties, you can trigger a command when clicking a menu item.

```xml
<TableView Intent="Settings"
            Grid.Row="1"
            RowHeight="50"
            IsVisible="{Binding IsAuthenticated}">
    <TableRoot>
        <TableSection Title="">
            <control:VMenuCell MenuText="My Profile"
                                IconText="&#xf007;"
                                Command="{Binding MessageCommand}"
                                CommandParameter="ProfilePage"></control:VMenuCell>
            <control:VMenuCell MenuText="Contact Us"
                                IconText="&#xf0e0;"
                                Command="{Binding MessageCommand}"
                                CommandParameter="ContactPage"></control:VMenuCell>
            <control:VMenuCell MenuText="Change Password"
                                IconText="&#xf084;"
                                Command="{Binding MessageCommand}"
                                CommandParameter="UpdatePasswordPage"></control:VMenuCell>
            <control:VMenuCell MenuText="Logout"
                                IsEnabled="{Binding IsAuthenticated}"
                                IconText="&#xf08b;"
                                Command="{Binding GoSignOutCommand}"></control:VMenuCell>
            <control:VMenuCell MenuText="Delete Account"
                                IconText="&#xf235;"
                                Command="{Binding MessageCommand}"
                                CommandParameter="DeleteAccountPage"></control:VMenuCell>
            <control:VMenuCell MenuText="About"
                                IconText="&#xf05a;"
                                Command="{Binding MessageCommand}"
                                CommandParameter="AboutPage"></control:VMenuCell>
        </TableSection>
    </TableRoot>
</TableView>
```

## Without Icons

If `IconText` is not set, the icon will not be displayed.

![alt text](assets/image-48.png)

```xml
<TableView Intent="Settings"
           Grid.Row="1"
           RowHeight="50"
           IsVisible="{Binding IsAuthenticated}">
    <TableRoot>
        <TableSection Title="">
            <control:VMenuCell MenuText="Bookings"
                               Command="{Binding MessageCommand}"
                               CommandParameter="OrdersPage?type=1"></control:VMenuCell>
            <control:VMenuCell MenuText="Reports"
                               Command="{Binding MessageCommand}"
                               CommandParameter="OrdersPage?type=2"></control:VMenuCell>
        </TableSection>
    </TableRoot>
</TableView>
```

## Title Color

Set the `MenuTextColor` property to specify the color of the title and icon.

![alt text](assets/image-49.png)

```xml
<TableView Intent="Settings"
            Grid.Row="1"
            RowHeight="50"
            IsVisible="{Binding IsAuthenticated}">
    <TableRoot>
        <TableSection Title="">
            <control:VMenuCell MenuText="Logout"
                                IsEnabled="{Binding IsAuthenticated}"
                                IconText="&#xf08b;"
                                MenuTextColor="Red"
                                Command="{Binding GoSignOutCommand}"></control:VMenuCell>
            <control:VMenuCell MenuText="Delete Account"
                                IconText="&#xf235;"
                                MenuTextColor="Blue"
                                Command="{Binding MessageCommand}"
                                CommandParameter="DeleteAccountPage"></control:VMenuCell>
            <control:VMenuCell MenuText="About"
                                IconText="&#xf05a;"
                                MenuTextColor="Green"
                                Command="{Binding MessageCommand}"
                                CommandParameter="AboutPage"></control:VMenuCell>
        </TableSection>
    </TableRoot>
</TableView>
```
