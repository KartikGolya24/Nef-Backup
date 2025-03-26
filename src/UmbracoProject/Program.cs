
using UmbracoProject.App_Code.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

//Service Registration
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IPurchaseFlowService, PurchaseFlowService>();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

// Use a redirect for the root URL.
app.MapGet("/", context =>
{
    context.Response.Redirect("/privat", permanent: true);
    return Task.CompletedTask;
});

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=604800, immutable");
    }
});

await app.RunAsync();
