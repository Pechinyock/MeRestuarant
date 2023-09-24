using MongoDB.Driver;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace MeRestaurantWebApi;

public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;
    public UserService()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDb = mongoClient.GetDatabase("MeRestaurant");
        _usersCollection = mongoDb.GetCollection<User>("Users");
    }

    public async Task CreateNewUser(CreateUserModel createUserModel){
        User newUser = new User{
            Email = createUserModel.Email,
            Password = createUserModel.Password
        };        
        await _usersCollection.InsertOneAsync(newUser);
    }

    public async Task<bool> IsUserExists(string email){
        var filter = Builders<User>.Filter.Eq(e => e.Email, email);
        var user = await _usersCollection.Find(filter).FirstOrDefaultAsync();
        return user != null;
    }
}
