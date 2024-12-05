namespace ShoppingList;
using ShoppingList.Views;
public partial class App : Application
{
    public static string SessionKey = "";//UNIVERSAL SESSION THT WILL ENSURE A USER HAS LOGIN CREDITINITALS 
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}