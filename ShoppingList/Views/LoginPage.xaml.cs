using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        Title = "Login";
    }

    async void Login_OnClicked(object sender, EventArgs e)
    {
        //This is successfull submitting and attaching our session to our account password
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPassword.Text));
        
        var client = new HttpClient();
        //Now we need to login to the account since we are able to create acct
        var  response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"),
            new StringContent(data, Encoding.UTF8, "application/json"));
             
        //We recieved vailid session key
        var SKey = response.Content.ReadAsStringAsync().Result;

        if (string.IsNullOrEmpty(SKey) || SKey.Length < 50)
        {
            App.SessionKey = SKey;
            Navigation.PopModalAsync(); 
        }
        else
        {
            await  DisplayAlert("Error", "Sorry Your UserName Or Password is Incorrect  ", "OK");
            return;
        }
        
    }

    private void CreateAccount_OnClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewAccountPage());
    }
}