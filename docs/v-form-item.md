
# VFormItem

表单项组件。


## 基础用法

通过设置`TitleText`属性来设置表单项的标题。

![alt text](assets/image-93.png)


```xml
<control:VFormItem TitleText="Company Name:">
</control:VFormItem>
```

通常表单项需要设置内容

可以通过设置`ContentSlot`属性来设置表单项的自定义内容。

配合VEntry组件来实现输入框表单项

![alt text](assets/image-94.png)

```xml
<control:VFormItem TitleText="Company Name:">
    <control:VFormItem.ContentSlot>
        <control:VEntry  />
    </control:VFormItem.ContentSlot>
</control:VFormItem>
```


## 必填项

通过设置`IsRequired`属性来设置表单项是否必填。默认为`True`


![alt text](assets/image-96.png)

```xml
<control:VFormItem TitleText="Company Name:"
                IsRequired="False">

</control:VFormItem>

```

## 帮助信息

通过设置 `HelpText`属性来设置表单项的帮助信息。


![alt text](assets/image-100.png)

```xml
<control:VFormItem TitleText="Company Name:"
                InfoText="Please fill in the buyer or client's information here">
</control:VFormItem>

```

当设置了`HelpText`属性之后，会在标题行最右侧自动显示帮助按钮“?”， 点击按钮后会弹出帮助信息。

可以通过设置 `IsShowInfo` 属性来隐藏标题和帮助信息。此属性为双向绑定属性

## 隐藏标题和帮助信息

可以通过设置 `HideTitle`和`HideHelpText`属性来完全隐藏标题和帮助信息。


![alt text](assets/recording-28.gif)


```xml
  <control:VFormItem TitleText="Company Name:"
                     HasInfo="{Binding HasInfo}"
                     HasTitle="{Binding HasTitle}"
                     InfoText="Please fill in the buyer or client's information here">
      <control:VFormItem.ContentSlot>
          <control:VEntry />
      </control:VFormItem.ContentSlot>
  </control:VFormItem>
```


## 表单验证信息

通过设置 `IsInvalid`属性为`true`，可以显示验证信息，设置 `InvalidText`属性设置验证信息内容


![alt text](assets/image-97.png)

```xml
 <control:VFormItem TitleText="Company Name:"
                    IsInvalid="False"
                    ValidateText="'Company Name' must not be null">
 </control:VFormItem>

```


## 标题颜色

通过设置 `TitleColor`属性设置标题颜色

![alt text](assets/image-98.png)

```xml
<control:VFormItem TitleText="Company Name:"
                    TitleTextColor="Green">

</control:VFormItem>

```



## 自定义内容

可以通过设置`InfoSlot`属性来设置帮助信息自定义内容。设置此属性将覆盖原帮助信息中的文本。

![alt text](assets/image-99.png)

```xml
<control:VFormItem TitleText="Upload files:">
    <control:VFormItem.ContentSlot>
        <control:VUploader  />
    </control:VFormItem.ContentSlot>
    <control:VFormItem.InfoSlot>
        <VerticalStackLayout>
            <Label Text="Only files in the following formats can be uploaded"
                    />
            <HorizontalStackLayout HeightRequest="35" Spacing="10">
                <Image Source="xls.png"></Image>
                <Image Source="ppt.png"></Image>
                <Image Source="doc.png"></Image>
            </HorizontalStackLayout>
        </VerticalStackLayout>
    </control:VFormItem.InfoSlot>
</control:VFormItem>

```