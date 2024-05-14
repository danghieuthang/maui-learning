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


## Binding Type:
1. ### Binding with Binding Context
- Use code. For example code, see [Binding with Binding Context Details](../Code/DataBinding/DataBinding/Pages/BasicBindingPage.xaml.cs)

- Use XAML markup extensions to define. 
```XAML
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
- The `x:Reference` markup extension is required to reference the source object, which is the Slider named slider.
- The `Binding` markup extension links the Rotation property of the Label to the Value property of the Slider.

For example code, see [Binding with Binding Context Details](../Code/DataBinding/DataBinding/Pages/ContextBindingPage.xaml)

- **Note:** The source property is specified with the `Path` property of the `Binding` markup extension, which corresponds with the `Path` property of the `Binding` class.

2. ### Binding without Binding Context
- Use code. For more details, see [Binding without a Binding Context Details](../Code/DataBinding/DataBinding/Pages/WithoutBindingContextPage.xaml.cs)
- Use XAML:
```XAML
Scale="{Binding Value, Source={x:Reference slider}}" />
```

3. ### Binding context inherictance
The BindingContext property value is inherited through the visual tree.
```XAML
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

