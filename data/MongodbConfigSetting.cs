namespace api_test_with_mongo.data
{
    public class MongodbConfigSetting
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionNameInDb { get; set; } = string.Empty;
    }
}
