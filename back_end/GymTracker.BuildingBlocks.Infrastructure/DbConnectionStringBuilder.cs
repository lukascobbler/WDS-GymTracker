namespace GymTracker.BuildingBlocks.Infrastructure;

public class DbConnectionStringBuilder
{
    // secrets about database connections should go here

    public static string Build(string schema)
    {
        var server = "localhost";
        var port = "5432";
        var database = "gymTracker";
        var user = "postgres";
        var password = "postgres";
        var integratedSecurity = "false";
        var pooling = "true";

        return
            $"Server={server};Port={port};Database={database};SearchPath={schema};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }
}