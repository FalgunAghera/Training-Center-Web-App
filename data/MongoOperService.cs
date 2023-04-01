using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Operations.ElementNameValidators;

namespace api_test_with_mongo.data
{
    public class MongoDbAPIManager
    {
        private readonly IMongoCollection<CodeForMongoOpr> DB_trainingCenters; // database collection to be used
        private readonly string CONST_CLIENTGATEWAY = "mongodb://localhost:27017/training_center";

        public MongoDbAPIManager(IOptions<MongodbConfigSetting> options) // constructor with dependency injection
        {
            var mongoClient = new MongoClient(CONST_CLIENTGATEWAY); // creates a new MongoClient instance pointing to the specified MongoDB instance
            DB_trainingCenters = mongoClient.GetDatabase(options.Value.DatabaseName) // get the database with the specified name
                .GetCollection<CodeForMongoOpr>(options.Value.CollectionNameInDb); // get the collection with the specified name
        }

        public async Task<List<CodeForMongoOpr>> GetAll() => // returns all the records from the collection
            await DB_trainingCenters.Find(_ => true).ToListAsync();

        public async Task<CodeForMongoOpr> Get(string id) => // returns a single record from the collection by ObjectId
            await DB_trainingCenters.Find(m => m.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();

        public async Task CreateDocument(CodeForMongoOpr newName) => // creates a new record in the collection
            await DB_trainingCenters.InsertOneAsync(newName);

        public async Task Update(string id, CodeForMongoOpr updateRec) => // updates an existing record in the collection by ObjectId
            await DB_trainingCenters.ReplaceOneAsync(m => m.Id == ObjectId.Parse(id), updateRec);

        public async Task Remove(string id) => // deletes an existing record from the collection by ObjectId
            await DB_trainingCenters.DeleteOneAsync(m => m.Id == ObjectId.Parse(id));
    }
}
