var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    // Default is AutoCreate.CreateOrUpdate
    // It will create or update automatically when first api call
    //opts.AutoCreateSchemaObjects = AutoCreate.All;
}).UseLightweightSessions();
builder.Services.AddValidatorsFromAssembly(assembly);


var app = builder.Build();

app.MapCarter();

app.Run();
