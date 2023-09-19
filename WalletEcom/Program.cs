using Microsoft.EntityFrameworkCore;
using WalletEcom.BackgroundTasks;
using WalletEcom.DB;
using WalletEcom.Services;
using WalletEcom.Services.Impls;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("MySql")));
services.AddSingleton<IDbContextFactory<AppDbContext>, AppDbContextFactory>();
services.AddHostedService<WalletQueueHandler>();
services.AddSingleton<IWalletQueueService>(sp =>
{
    return new InMemoryWalletQueueService(128);
});
services.AddScoped<IAccountService, AccountService>();
services.AddSingleton<IWalletService, WalletService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFileServer();

app.MapControllers();

app.Run();
