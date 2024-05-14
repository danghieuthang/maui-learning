namespace DataBinding.Pages;

public partial class WithoutBindingContextPage : ContentPage
{
    public WithoutBindingContextPage()
    {
        InitializeComponent();
        label.SetBinding(Label.ScaleProperty, new Binding("Value", source: slider));
    }
}