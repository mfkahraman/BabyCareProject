namespace BabyCareProject.DataAccess.Settings
{
    //In mongodb insteadof => wecall; table => collection, row => document, column => field
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string InstructorCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
