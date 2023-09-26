using InventoryManagementAPis.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Enable Cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
//builder.Services.Configure<TwilioService>(builder.Configuration.GetSection("Twilio"));
//builder.Services.AddTransient<TwilioService>();
//var twilioSettings = builder.Configuration.GetSection("Twilio").Get<TwilioSettings>();
//var whatsAppMessageSettings = builder.Configuration.GetSection("WhatsAppMessage").Get<WhatsAppMessageModel>();

//builder.Services.AddTransient<TwilioService>(sp =>
//{
//    return new TwilioService(
//        twilioSettings.AccountSid,
//        twilioSettings.AuthToken,
//        twilioSettings.PhoneNumber
//    );
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(Options => Options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
