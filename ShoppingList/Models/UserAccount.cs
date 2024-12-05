namespace ShoppingList.Models;

public class UserAccount
{
  
    public string username { get; set; }
    
    public string password { get; set; }
    
    public string email { get; set; }

    public string userKey { get; set; }
    
    public UserAccount(string username, string password, string email) //We are refrencing the Exact paremeters 
    {
        this.username = username;

        this.password = password;

        this.email = email;
    }
    
    public UserAccount(string username, string password) //We created this so that we can use User account if we wanted to login anywhere within the app 
    {
        this.username = username;

        this.password = password;
        
    }
    
    public UserAccount(string userKey) //We created this so that we can use User account if we wanted to login anywhere within the app 
    {
        this.userKey = userKey;
        
    }

    
}