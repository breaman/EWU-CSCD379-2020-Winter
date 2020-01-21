using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretSanta.Business.Tests
{
    public abstract class TestBase
    {
#nullable disable
        private SqliteConnection SqliteConnection { get; set; }
        protected DbContextOptions<ApplicationDbContext> Options { get; private set; }
        protected IMapper Mapper { get; private set; }
#nullable enable
        private static ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name,
                        LogLevel.Information);
            });
            return serviceCollection.BuildServiceProvider().
                GetService<ILoggerFactory>();
        }

        [TestInitialize]
        public void InitializeTests()
        {
            SqliteConnection = new SqliteConnection("DataSource=:memory:");
            SqliteConnection.Open();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(SqliteConnection)
                .UseLoggerFactory(GetLoggerFactory())
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new ApplicationDbContext(Options))
            {
                context.Database.EnsureCreated();
            }

            var currentDomain = AppDomain.CurrentDomain;
            var assemblies = currentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains(nameof(SecretSanta.Business))).ToArray();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assemblies);
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [TestCleanup]
        public void TeardownTests()
        {
            SqliteConnection.Close();
        }
    }
}
