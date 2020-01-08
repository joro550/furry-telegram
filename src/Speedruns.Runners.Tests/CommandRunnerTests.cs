using Xunit;
using System;
using System.Threading.Tasks;
using Speedruns.Runners.Stores;
using Microsoft.EntityFrameworkCore;
using Speedruns.Runners.Tests.CoreFakes;
using Speedruns.Runners.Stores.Settings;
using Speedruns.Runners.Stores.Factories;

namespace Speedruns.Runners.Tests
{
    public class CommandRunnerTests
    {
        [Fact]
        public void WhenCreatingCommandRunner_ThenExtensionIsCalled()
        {
            // ReSharper disable once UnusedVariable
            var commandRunner = new CommandRunner(builder => builder.UseTest(new TestStore()));
            Assert.True(TestBuilderExtensions.HasBeenCalled);
        }

        [Fact]
        public async Task WhenQueryIsPassed_StoreIsCreatedAndQueryIsRan()
        {
            var store = new TestStore();
            var commandRunner = new CommandRunner(builder => builder.UseTest(store));

            var result = await commandRunner.Execute(new TestQuery());

            Assert.True(store.HasBeenCreated);
            Assert.Equal(1, result);
        }
    }

    public class InMemoryDatabaseSettings : Settings
    {
        public override StoreFactory CreateStoreFactory() =>
            new ContextStoreFactory(new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
    }

    public static class SettingsBuilderExtensions
    {
        public static Settings UseInMemoryDatabase(this SettingsBuilder builder) 
            => new InMemoryDatabaseSettings();
    }
}