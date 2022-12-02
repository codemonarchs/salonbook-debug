using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SalonBook.Server.Data.Main;
using SalonBook.Server.Data.Users;
using SalonBook.Server.Data.Users.Entities;
using SalonBook.Server.Options;
using Microsoft.AspNetCore.Identity;

namespace SalonBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // identity is a bitch
            // https://stackoverflow.com/questions/65583794/azure-500-error-on-a-blazor-wasm-hosted-with-authentication
            // https://github.com/CodeMazeBlog/blazor-wasm-hosted-security/blob/google_authentication_blazor_wasm_hosted/BlazorWasmHostedAuth/BlazorWasmHostedAuth/Server/Startup.cs

            // Add services to the container.
            builder.Services.AddDbContext<UsersDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Users"));
            });

            builder.Services.AddDbContextFactory<MainDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Main"));
            });
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UsersDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<User, UsersDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt()
                 .AddGoogle(options =>
                  {
                      IConfigurationSection config = builder.Configuration.GetSection("Authentication:Google");
                      options.ClientId = config["ClientId"];
                      options.ClientSecret = config["ClientSecret"];
                  })
                .AddFacebook(options =>
                {
                    IConfigurationSection config = builder.Configuration.GetSection("Authentication:Facebook");
                    options.AppId = config["AppId"];
                    options.AppSecret = config["AppSecret"];
                })
                .AddMicrosoftAccount(options =>
                {
                    IConfigurationSection config = builder.Configuration.GetSection("Authentication:Microsoft");
                    options.ClientId = config["ClientId"];
                    options.ClientSecret = config["ClientSecret"];
                });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // configuration
            builder.Services.AddOptions();
            builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection("Stripe"));
            builder.Services.Configure<SendGridOptions>(builder.Configuration.GetSection("SendGrid"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}