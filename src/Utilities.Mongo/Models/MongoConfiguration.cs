namespace MatrTech.Utilities.Mongo.Models
{
    public class MongoConfiguration
    {
        public string? ConnectionUrl { get; set; }
        public int Port { get; set; }
        public bool Srv { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DatabaseName { get; set; }
    }
}