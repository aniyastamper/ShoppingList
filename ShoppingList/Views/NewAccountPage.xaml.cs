using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ShoppingList.Models;
using System.Threading.Tasks;

namespace ShoppingList.Views;

public partial class NewAccountPage : ContentPage
{
    public NewAccountPage()
    {
        
        InitializeComponent();
        Title = "Create New Account";
    }


    async void CreateAccount_OnClicked(object sender, EventArgs e)
    { 
        //Adding the Api direction
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPassword1.Text, txtEmail.Text));

        var client = new HttpClient();
        var response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/createuser"),
            new StringContent(data, Encoding.UTF8, "application/json"));

        var AccountStatus = response.Content.ReadAsStringAsync().Result;

        AccountStatus = AccountStatus;
        
        
        //Our login is true and the User Exist
        if (AccountStatus == "user exists")
        {
          await  DisplayAlert("Error", "This Username is Already in Use ", "OK");
            return;
        }
        //Is the email already in use?
        if (AccountStatus == "email exists")
        {
           await  DisplayAlert("Error", "This Email is Already is in Use ", "OK");
            return;
        }
        
        //All the Information is Valid
        if (AccountStatus == "complete")
        {
            //Now we need to login to the account since we are able to create acct
             response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"),
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
                await  DisplayAlert("Error", "Sorry there was an issue logging you in ", "OK");
                return;
            }
            
        }
        else
        {
            await  DisplayAlert("Error", "Sorry there is an Error Creating You Account", "OK");
            return;
        }
    }
    
}