using Application.Interface.Cdc;
using Asp.Versioning;
using Infrastructure.AppContext;
using Infrastructure.Repository.Cdc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// SSERVICES for DEPENDENCY INJECTION CONTAINER

//DbContext with connection string in Configuratiion file appsettings.json
builder.Services.AddDbContext<YojanaContext>(
        options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("Yojana")
            )
    );

//support for controllers, API explorer, Authorization, CQRS, Validation etc.
builder.Services.AddControllers();

//Minimal API - not using MapGet, using controller API
//builder.Services.AddEndpointsApiExplorer();



//Access to HttpContextAccessor for user data for Audit data - keep Singleton
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//http client
builder.Services.AddHttpClient();


//API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
});

// token options in frank liu notes
builder.Services.AddSwaggerGen();

//register interface with repository
builder.Services.AddScoped<ICdcCvx, CdcCvxRepository>();
builder.Services.AddScoped<ICdcCvxCpt, CdcCvxCptRepository>();
builder.Services.AddScoped<ICdcCvxManufacturer, CdcCvxManufacturerRepository>();
builder.Services.AddScoped<ICdcCvxVaccineGroup, CdcCvxVaccineGroupRepository>();
builder.Services.AddScoped<ICdcCvxVis, CdcCvxVisRepository>();
builder.Services.AddScoped<ICdcLookupBarcode, CdcLookupBarcodeRepository>();
builder.Services.AddScoped<ICdcLookupNdc, CdcLookupNdcRepository>();
builder.Services.AddScoped<ICdcManufacturer, CdcManufacturerRepository>();

var app = builder.Build();


//MIDDLEWARE

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// always https
app.UseHttpsRedirection();

//api route mapping for webapi project
app.MapControllers();


app.Run();
