// using PathAPI.Models;
// using PathAPI.Migrations;
// using bcrypt = BCrypt.Net.BCrypt;

// namespace PathAPI.Repositories;

// public class AuthService : IAuthService
// {
//     private static DataDbContext _context;
//     private IConfiguration _config;

//     public AuthService(DataDbContext context, IConfiguration config) {
//         _context = context;
//         _config = config;
//     }
    
//     public User CreateUser(User user)
//     {
//         var passwordHash = bcrypt.HashPassword(user.Password);
//         user.Password = passwordHash;

//         _context.Add(user);
//         _context.SaveChanges();
//         return user;
//     }

//     public string SignIn(string email, string password)
//     {
//         var user = _context.User.SingleOrDefault(x => x.Email == email);
//         var verified = false;

//         if(user != null)
//         {
//             verified = bcrypt.Verify(password, user.Password);
//         }

//         if(user == null || !verified)
//         {
//             return String.Empty;
//         }
//         return("Build Jwt Token");
//     }
// }