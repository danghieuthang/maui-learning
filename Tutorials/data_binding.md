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
- Use code. For more details, see [Binding with Binding Context Details](../Code/DataBinding/DataBinding/Pages/BasicBindingPage.xaml)
- Use XAML markup extensions to define. For more details, see [Binding with Binding Context Details](../Code/DataBinding/DataBinding/Pages/ContextBindingPage.xaml)

2. ### Binding without Binding Context
- Use code. For more details, see [Binding without a Binding Context Details](../Code/DataBinding/DataBinding/Pages/WithoutBindingContextPage.xaml)
- Use XAML:
```XAML
Scale="{Binding Value, Source={x:Reference slider}}" />
```

3. ### Binding context inherictance
The BindingContext property value is inherited through the visual tree.

For more details, see [Binding context inhenrictnace](../Code/DataBinding/DataBinding/Pages/BindingContextInherictance.xaml)

