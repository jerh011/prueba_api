using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using API_JERH.Models;
using API_JERH.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;


namespace API_JERH.Services
{
  
        public class DriverServices
        {
       
            private readonly IMongoCollection<Driver> _driverCollection;

    
            public DriverServices(IOptions<DatabaseSettings> databaseSettings)
            {
                var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
                var mongoDB =
                mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
                _driverCollection =
                    mongoDB.GetCollection<Driver>(databaseSettings.Value.CollectionName);
            }
            public async Task<List<Driver>> GetAsync() =>
                await _driverCollection.Find(_ => true).ToListAsync();

            public async Task<Driver> GetDriverById(string id)
            {
                return await _driverCollection.FindAsync(new BsonDocument
            {{"_id",new ObjectId(id)}}).Result.FirstAsync();
            }

            public async Task InsertDriver(Driver drivers)
            {
                await _driverCollection.InsertOneAsync(drivers);
            }
            public async Task UpdateDriver(Driver drivers)
            {
                var filter = Builders<Driver>.Filter.Eq(S => S.Id, drivers.Id);
                await _driverCollection.ReplaceOneAsync(filter, drivers);
            }

            public async Task DelateDriver(string id)
            {
                var filter = Builders<Driver>.Filter.Eq(S => S.Id, id);
                await _driverCollection.DeleteManyAsync(filter);
            }
        }

    }