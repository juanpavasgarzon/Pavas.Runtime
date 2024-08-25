using Context.Example.Endpoints;
using Pavas.Runtime.ApplicationContext;
using Pavas.Runtime.ApplicationContext.DependencyInjection;
using Pavas.Runtime.MemoryContext.DependencyInjection;
using Pavas.Runtime.TenantContext;
using Pavas.Runtime.TenantContext.DependencyInjection;
using Pavas.Runtime.TraceContext.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var applicationContext = new ApplicationContext
{
    ApplicationName = "Test",
    ApplicationVersion = new Version("1.0.0"),
    BuildMode = ApplicationBuildMode.Release,
    Environment = ApplicationEnvironment.Debug,
    BaseUrl = "api/v1"
};

List<Tenant> tenants =
[
    new Tenant
    {
        Id = "Develop",
        Name = "Develop",
        Connection = "MyConnectionDevelop",
        IsDefault = true
    },
    new Tenant
    {
        Id = "ProductionTenant",
        Name = "ProductionTenant",
        Connection = "MyConnectionToProduction"
    },
    new Tenant
    {
        Id = "TestTenant",
        Name = "TestTenant",
        Connection = "MyConnectionToTest"
    }
];

string[] repositories = ["application"];

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationContext(applicationContext);
builder.Services.AddMemoryContext(repositories);
builder.Services.AddTraceContext();
builder.Services.AddTenantContext(tenants);

var app = builder.Build();

app.MapApplicationContextEndpoint();
app.MapMemoryContextEndpoint();
app.MapTenantContextEndpoint();
app.MapTraceContextEndpoint();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseTenantContextMiddleware();
app.UseTraceContextMiddleware();
app.Run();