﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities;

public class User
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password {get;set;} = null!;    
}
