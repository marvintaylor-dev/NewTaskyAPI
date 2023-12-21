global using NewTaskyAPI.Server.Data.AuthService;
global using NewTaskyAPI.Server.Data.MemberRepository;
global using NewTaskyAPI.Server.Data.TagRepository;
global using NewTaskyAPI.Server.Data.TaskRepository;
global using NewTaskyAPI.Server.Data.EpicRepository;
global using NewTaskyAPI.Server.Data.StatusRepository;
global using NewTaskyAPI.Server.Data.EstimationRepository;
global using NewTaskyAPI.Server.Data.SprintRepository;
global using NewTaskyAPI.Server.Data.GenericRepository;
global using NewTaskyAPI.Server.Data.ProductGoalsRepository;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using NewTaskyAPI.Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Microsoft.AspNetCore.Identity;
using NewTaskyAPI.Server.Data.ProductGoalsRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IProductGoalsRepository, ProductGoalsRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IEpicRepository, EpicRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IEstimationRepository, EstimationRepository>();
builder.Services.AddScoped<ISprintRepository,SprintRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", 
        b => b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
