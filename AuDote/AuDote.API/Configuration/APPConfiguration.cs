namespace AuDote.API.Configuration
{
    public class APPConfiguration
    {
        public SwaggerInfo Swagger { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public MongoDBSettings MongoDBSettings { get; set; }
    }

    public class ConnectionStrings
    {
        public string CachorrosMongoDb { get; set; }
    }

    public class SwaggerInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class MongoDBSettings
    {
        public string URL { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnectionString
        {
            get { return $"mongodb://{Username}:{Password}@{URL}/{DatabaseName}"; }
        }
    }
}
