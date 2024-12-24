var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);
var sql = builder.AddSqlServer("sql", password: sqlPassword)
    .WithDataVolume();

var sqlDb = sql.AddDatabase("sqlDb");

builder.AddProject<Projects.aspireWorkshop_API>("aspireworkshop-api")
    .WithReference(sqlDb)
     .WaitFor(sqlDb);

builder.Build().Run();
