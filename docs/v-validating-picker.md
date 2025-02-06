# VValidatingPicker

带有校验功能的选择器组件。

V-ValidatingPicker继承自 [V-Picker](v-picker.md)



## 基础用法

选择器完成选择后，将触发校验规则进行校验。

![alt text](assets/image-101.png)

使用 `ItemsSource` 属性绑定选择器数据源，需要绑定 `IList<ValidatableObject<T>>` 的对象。

使用 `SelectedItem` 属性绑定当前选中的项。


```xml
<control:VValidatingPicker ItemsSource="{Binding SalutationList}"
                            SelectedItem="{Binding SelectedSalutation}"
                            ValidateCommand="{Binding ValidateSalutationCommand}"></control:VValidatingPicker>
```


## 校验规则

校验规则`Validations`属性可以添加多个校验规则，当多个校验规则都通过时，才认为校验通过。此示例中，用户选择的年龄必须在 18 到 21 之间。

![alt text](assets/recording-29.gif)




首先创建一个 `IList<ValidatableObject<T>>` 对象AgeList， 并循环添加数据。

ViewModel：

```csharp
this.AgeList = new();
for (int i = 14; i < 23; i++)
{

    AgeList.Add(new ValidatableObject<PickerM>()
    {
        Value = new PickerM { Value = i.ToString() },
    });
}
```

添加校验规则

```csharp

var rules = new List<IValidationRule<PickerM>>() {
    new MoreThanRule<PickerM>(18, true) { ValidationMessage = "You must be over 18 years old" },
    new LessThanRule<PickerM>(21, false) { ValidationMessage = "You must be under 21 years old" }
};
this.AgeList = new();
for (int i = 14; i < 23; i++)
{

    AgeList.Add(new ValidatableObject<PickerM>()
    {
        Value = new PickerM { Value = i.ToString() },
        Validations = rules
    });
}

```

校验规则由`Validations`属性提供，它由一组校验规则组成。

V-Control默认实现了以下几种校验规则：

* public class IsEmailRule<T> 			
* public class IsNotNullOrEmptyRule<T> 				
* public class IsUserNameOrEmailRule<T> 				
* public class MaxLenRule<T> 		
* public class MinCountOfDigitRule<T>				
* public class MinCountOfUpperLetterRule<T>	
* public class MinLenRule<T> 
* pubiic class LessThanRule<T>	
* pubiic class MoreThanRule<T>	







## ValidateCommand

使用 `ValidateCommand` 属性，在触发校验时时，执行 `ValidateCommand` 指定的命令。

![alt text](assets/recording-30.gif)


```xml
<control:VValidatingPicker ItemsSource="{Binding SalutationList}"
                            SelectedItem="{Binding SelectedSalutation}"
                            ValidateCommand="{Binding ValidateSalutationCommand}"></control:VValidatingPicker>

```

在这个示例中，可以通过在 `ValidateSalutationCommand` 中，对称呼进行非空校验

ViewModel：

```csharp
[RelayCommand]
private void ValidateSalutation()
{

    if (SelectedSalutation.Value != null && !string.IsNullOrEmpty(SelectedSalutation.Value.Id))
    {
        return;
    }
    SelectedSalutation.IsValid = false;
    SelectedSalutation.Errors = ["Title is required."];

}



```