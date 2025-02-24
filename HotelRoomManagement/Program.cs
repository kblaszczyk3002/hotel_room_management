using HotelRoomManagement.DataAccess;
using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Service;
using HotelRoomManagement.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

HotelRoomManagementContext.ConnectionString = builder.Configuration.GetConnectionString("HotelRoomManagementDb");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelRoomManagementContext>();
builder.Services.AddDbContext<IHotelRoomContext, HotelRoomManagementContext>();

builder.Services.AddScoped<IHotelRoomService, HotelRoomService>();
builder.Services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();

var app = builder.Build();

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
