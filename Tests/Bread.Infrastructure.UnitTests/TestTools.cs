using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Bread.Infrastructure.Data.DbContexts;

namespace Bread.Infrastructure.UnitTests
{
    public static class TestTools
    {
        public static ApplicationDbContext CreateApplicationDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var someOptions = Options.Create<OperationalStoreOptions>(new OperationalStoreOptions());
            var applicationDbContext = new ApplicationDbContext(dbContextOptions, someOptions);
            return applicationDbContext;
        }
    }
}
