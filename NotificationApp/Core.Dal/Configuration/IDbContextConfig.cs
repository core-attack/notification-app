namespace Core.Dal.Configuration
{
    public interface IDbContextConfig
    {
        string ConnectionString { get; }
    }
}