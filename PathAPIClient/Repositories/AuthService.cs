using Microsoft.Extensions.Options;
using PathAPI.Models;
using bcrypt = BCrypt.Net.BCrypt;
using MongoDB.Driver;

namespace PathAPI.Repositories;

public class AuthService : IAuthService
{
    private readonly IMongoCollection<User> _user;

    public AuthService(IOptions<UserDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.UserConnectionString);
        var database = client.GetDatabase(settings.Value.UserDatabaseName);

        _user = database.GetCollection<User>(settings.Value.UserCollectionName);
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
        throw new NotImplementedException();
    }
}