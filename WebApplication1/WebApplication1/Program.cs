using Asp.Versioning;
using WebApplication1.Ext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersionService();

var app = builder.Build();

var apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(2.0))
    .HasDeprecatedApiVersion(new ApiVersion(1.0))
    .ReportApiVersions()
    .Build();

app.MapGet("/", () =>
    "Hello world"
).WithApiVersionSet(apiVersionSet)
.MapToApiVersion(new ApiVersion(2.0));

app.MapGet("/keke", () =>
    "keke"
).WithApiVersionSet(apiVersionSet)
.MapToApiVersion(new ApiVersion(1.0));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
