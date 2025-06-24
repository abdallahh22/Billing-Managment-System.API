using Invoice.Data.Context;
using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Invoice.Repositories.Repositories;
using Invoice.Service.HanddleResponses;
using Invoice.Service.ServiceInterfaces.CompaniesService;
using Invoice.Service.ServiceInterfaces.CompanyService;
using Invoice.Service.ServiceInterfaces.CustomerService;
using Invoice.Service.ServiceInterfaces.DiscountService;
using Invoice.Service.ServiceInterfaces.InvoiceItemService;
using Invoice.Service.ServiceInterfaces.InvoiceService;
using Invoice.Service.ServiceInterfaces.PaymentService;
using Invoice.Service.ServiceInterfaces.ProductService;
using Invoice.Service.ServiceInterfaces.TaxService;
using Invoice.Service.TokenService;
using Invoice.Service.UserService;
using Invoice_App.MiddleWares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register services
#region Register Service
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IInvoiceItemsRepository, InvoiceItemsRepository>();
builder.Services.AddScoped<IInvoicesRepository, InvoicesRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITaxRepository, TaxRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<Invoice.Service.Mapping.Mapper>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IInvoiceItemService, InvoiceItemService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ITaxesService, TaxService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();

#endregion

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();




builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
                       .Where(model => model.Value.Errors.Count > 0)
                       .SelectMany(model => model.Value.Errors)
                       .Select(error => error.ErrorMessage)
                       .ToList();


        var errorResponse = new ValidateErrorsResponse
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


// swagger Customizations

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Invice-System", Version = "v1" });
});


// Register Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidateAudience = false,
            
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExcptionMiddlewares>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
