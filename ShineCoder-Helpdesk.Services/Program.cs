using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Core;
using Microsoft.AspNetCore.Mvc;
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Repository;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ShineCoder_Helpdesk.Core.Helpers;
using ShineCoder_Helpdesk.Infrastructure.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    In = ParameterLocation.Header,
    Description = "Please Enter Authentication Token",
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
}));



builder.Services.AddDbContext<HelpdeskDbContext>(options =>
options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(HelpdeskDbContext).Assembly.FullName)));
builder.Services.AddScoped<IHelpdeskDbContext>(provider => provider.GetService<HelpdeskDbContext>());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IResponseBuilder, ResponseBuilder>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextProxy, HttpContextProxy>();
builder.Services.AddLogging();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = false;
    config.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                                        new HeaderApiVersionReader("x-api-version"),
                                                                                        new MediaTypeApiVersionReader("x-api-version"));
});


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<HelpdeskDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredLength = 4;
    opt.Password.RequiredUniqueChars = 1;

    // Lockout settings 
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.AllowedForNewUsers = true;

    //Signin option
    opt.SignIn.RequireConfirmedEmail = false;

    // User settings 
    opt.User.RequireUniqueEmail = true;

    //Token Option
    //opt.Tokens.AuthenticatorTokenProvider = "Name of AuthenticatorTokenProvider";

});
builder.Services.Configure<PasswordHasherOptions>(option =>
{
    option.IterationCount = 12000;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
             ValidAudience = builder.Configuration["JWT:ValidAudience"],

             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
             ClockSkew = TimeSpan.Zero
         }


    );
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddCors(options =>
{

   // options.AddPolicy(name:MyAllowSpecificOrigins, builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
    options.AddPolicy(name:MyAllowSpecificOrigins, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});



builder.Services.AddTransient<IValidator, CustomValidator>();

//var mapperConfig = new MapperConfiguration(mc =>
//{
//	mc.AddProfile(new MappingProfile());
//});
//IMapper mapper = mapperConfig.CreateMapper();
//services.AddSingleton(mapper);
builder.Services.AddAutoMapper(typeof(MappingProfile)); ;

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
