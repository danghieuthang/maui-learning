# Understanding Data Binding in .NET MAUI

This document provides an overview of data binding in .NET Multi-platform App UI (MAUI).

## What is Data Binding?

Data binding is a technique to link your business logic (backend code) to the UI. With data binding, you can make your UI update to reflect changes in the data, and vice versa.

## How Does Data Binding Work in .NET MAUI?

In .NET MAUI, data binding is typically achieved through the MVVM (Model-View-ViewModel) pattern. The ViewModel exposes data and commands that the View can bind to, and notifies the View of any changes to the data using the `INotifyPropertyChanged` interface.

## Key Concepts

1. **Binding Context**: The source object for data binding. In MVVM, this is typically the ViewModel.

2. **Binding Source**: The specific property on the Binding Context that the target property is bound to.

3. **Binding Target**: The UI element and property that is data bound.


## Binding Ways:
1. ### Binding with Binding Context
- Use code. For example code, see [Binding with Binding Context Details](../Code/DataBinding/DataBinding/Pages/BasicBindingPage.xaml.cs)

- Use XAML markup extensions to define. 
```xml
 <Label Text="TEXT"
               FontSize="80"
               HorizontalOptions="Center"
               VerticalOptions="Center"
               BindingContext="{x:Reference Name=slider}"
               Rotation="{Binding Path=Value}" />

        <Slider x:Name="slider"
                Maximum="360"
                VerticalOptions="Center" />
```
In this example:
- The `x:Reference` markup extension is required to reference the source object, which is the Slider named slider.
- The `Binding` markup extension links the Rotation property of the Label to the Value property of the Slider.

For example code, see [Binding with Binding Context Details](../Code/DataBinding/DataBinding/Pages/ContextBindingPage.xaml)

- **Note:** The source property is specified with the `Path` property of the `Binding` markup extension, which corresponds with the `Path` property of the `Binding` class.

2. ### Binding without Binding Context
- Use code. For more details, see [Binding without a Binding Context Details](../Code/DataBinding/DataBinding/Pages/WithoutBindingContextPage.xaml.cs)
- Use XAML:
```xml
<Scale="{Binding Value, Source={x:Reference slider}}" />
```

3. ### Binding context inherictance
The BindingContext property value is inherited through the visual tree.
```xml
 <StackLayout VerticalOptions="Fill"
                     BindingContext="{x:Reference slider}">

            <Label Text="TEXT"
                   FontSize="80"
                   HorizontalOptions="Center"
                   VerticalOptions="End"
                   Rotation="{Binding Value}" />

            <BoxView Color="#800000FF"
                     WidthRequest="180"
                     HeightRequest="40"
                     HorizontalOptions="Center"
                     VerticalOptions="Start"
                     Rotation="{Binding Value}" />
        </StackLayout>
```
For example code, see [Binding context inhenrictnace](../Code/DataBinding/DataBinding/Pages/BindingContextInherictance.xaml)

## Binding Mode
1. Default Binding Modes: Each .NET MAUI bindable property has a default binding mode, accessible via `DefaultBindingMode`.

### Common Modes:
1. **OneWay**: Used by properties like `Rotation`, `Scale`, and `Opacity`. The target property is set from the source.
2. **TwoWay**: Allowing bidirectional updates between source and target.
Some properties: 
- `Date` property of `DatePicker`
- `Text` property of `Editor`, `Entry`, `SearchBar`, and `EntryCell`
- `IsRefreshing` property of `ListView`
- `SelectedItem` property of `MultiPage`
- `SelectedIndex` and SelectedItem properties of `Picker`
- `Value` property of `Slider` and `Stepper`
- `IsToggled` property of `Switch`
- `On` property of `SwitchCell`
- `Time` property of `TimePicker`
3. **OneWayToSource**: Read-only properties like `SelectedItem` of `ListView` use this to update the source from the target.
4. **OneTime**: Updates the target only when the binding context changes, without monitoring source property changes.

[See more](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/binding-mode?view=net-maui-8.0)

### Implementing INotifyPropertyChanged

In the MVVM (Model-View-ViewModel) pattern, the ViewModel acts as the intermediary between the Model and the View. When a property in the ViewModel changes, it needs to notify the View so that the corresponding UI can be updated.


1. **ViewModels**: They don’t define bindable properties but use `INotifyPropertyChanged` for notifying binding infrastructure about property changes.

[View example](../Code/DataBinding/DataBinding/Pages/ViewModelNofityPage.xaml)

### XAML Data Binding Mode
- Binding Overrides: It’s possible to override the default binding mode by setting the Mode property in the binding definition.

```xml
<Slider Value="{Binding Source={x:Reference label}, Path=Opacity, Mode=TwoWay}" />
```