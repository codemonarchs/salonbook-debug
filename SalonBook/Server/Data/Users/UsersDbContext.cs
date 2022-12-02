using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalonBook.Server.Data.Users.Entities;

namespace SalonBook.Server.Data.Users
{
    public class UsersDbContext : ApiAuthorizationDbContext<User>
    {
        public UsersDbContext(
           DbContextOptions options,
           IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<User>().Navigation(s => s.SomeNavigationProperty).AutoInclude();
        }
    }
}