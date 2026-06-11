var builder = WebApplication.CreateBuilder(args);

builder.Services
    .addCatalogModule(builder.Configuration)
    .addBasketModule(builder.Configuration)
    .addOrderingModule(builder.Configuration);
var app = builder.Build();
app.Run();
