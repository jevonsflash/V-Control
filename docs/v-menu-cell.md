
# VMenuCell

V-MenuCell是对ViewCell的一层封装，可以用于TableSection的列表项，通常可以作为菜单选项


## 基础用法


V-MenuCell的默认样式为

![alt text](assets/image-47.png)

通过设置 `MenuText` 指定菜单文本内容，以及 `IconText` 指定图标，图标的格式为Unicode字符或图标名称。

通过绑定 `Command` 和 `CommandParameter` 属性，即可实现点击菜单项后触发命令。

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


## 无图标


取消设置 `IconText` 则不显示图标


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

## 标题颜色


设置 `MenuTextColor` 指定标题和图标的颜色


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
