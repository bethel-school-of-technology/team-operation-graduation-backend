using Microsoft.Extensions.Options;
using PathAPI.Models;
using bcrypt = BCrypt.Net.BCrypt;
using MongoDB.Driver;

namespace PathAPI.Repositories;

public class AuthService : IAuthService
{
    private readonly IMongoCollection<User> _user;

    public AuthService(IOptions<PathDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);

        _user = database.GetCollection<User>(settings.Value.CollectionName);
    }
    
    public User CreateUser(User user)
    {
        var passwordHash = bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;
        
        _user.InsertOne(user);
        return user;
    }

    public string SignIn(string email, string password)
    {
        var user = _user.FindAsync<User>(x => x.Email == email);
        var verified = false;

        // if(user != null) 
        // {
        //     verified = bcrypt.Verify(password, user.Password);
        // }

        if(user == null || !verified)
        {
            return String.Empty;
        }

        return "Build Token";
    }
}