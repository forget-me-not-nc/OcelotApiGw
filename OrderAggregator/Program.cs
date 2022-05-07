using Microsoft.OpenApi.Models;
using OrderAggregator.Extensions;
using OrderAggregator.Services;
using OrderAggregator.Services.Impls;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<LoggingDelegatingHandler>();

builder.Services.AddHttpClient<IArchiveService, ArchiveService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:ArchiveUrl"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>();

builder.Services.AddHttpClient<IBasketService, BascketService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:ShoppingCartUrl"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>();

builder.Services.AddHttpClient<IDataService, DataService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:DataUrl"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order.Aggregator", Version = "v1" });
});

var app = builder.Build();

#region Swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order.Aggregator v1");
    });

}
#endregion

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
