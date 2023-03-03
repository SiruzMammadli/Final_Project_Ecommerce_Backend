namespace finalProject.Common.Repositories.MongoDb.Settings
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
