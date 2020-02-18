using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Bread.Domain.Entities;
using Bread.Infrastructure.Data.Entities;
using IdentityServer4.EntityFramework.Options;

namespace Bread.Infrastructure.Data.DbContexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Participate> Participates { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
