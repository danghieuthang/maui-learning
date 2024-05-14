namespace DataBinding.Pages;

public partial class BasicBindingPage : ContentPage
{
    public BasicBindingPage()
    {
        InitializeComponent();
        label.BindingContext = slider;
        label.SetBinding(Label.TextProperty, "Value");
    }


}