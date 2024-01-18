using JwtAuthenticationWithMiddlewares;
using JwtAuthenticationWithMiddlewares.Helpers.Pagination;
using JwtAuthenticationWithMiddlewares.Helpers.Utils.GlobalAttributes;
using JwtAuthenticationWithMiddlewares.Middlewares;
using JwtAuthenticationWithMiddlewares.Services.AuthService;
using JwtAuthenticationWithMiddlewares.Services.StoryService;
using JwtAuthenticationWithMiddlewares.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add global attributes
GlobalAttributes.mysqlConfiguration.connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

// Add services to the container.

// db connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


// custom services
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IStoryService,StoryService>();
builder.Services.AddScoped<QueryPaginator, QueryPaginator>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyHeader();
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// use CORS
app.UseCors();

// use exception handler 
app.UseExceptionHandlerMiddleware();

app.UseAuthorization();
app.UseJwtMiddleware();

app.MapControllers();

app.Run();
