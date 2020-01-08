using Xunit;
using System.Linq;
using AutoFixture;
using System.Threading.Tasks;
using Speedruns.Runners.Runners;
using Speedruns.Runners.Entities;
using Speedruns.Runners.Runners.Models;
using Speedruns.Runners.Tests.Extensions;

namespace Speedruns.Runners.Tests.Runners
{
    public class GetActiveRunnersTests
    {
        private readonly CommandRunner _commandRunner;

        public GetActiveRunnersTests() =>
            _commandRunner = new CommandRunner(builder => builder.UseInMemoryDatabase());

        [Fact]
        public async Task WhenNoRunnersArePresent_ThenEmptyListIsReturned() 
            => Assert.Empty(await _commandRunner.Execute(new GetActiveRunners()));

        public class GivenThereAreRunners
        {
            private readonly Fixture _fixture;

            public GivenThereAreRunners() => _fixture = new Fixture();

            [Fact]
            public async Task WhenRunnerIsOnline_ThenRunnerIsReturnedInList()
            {
                var factory = new TestContextFactory();
                await using var context = factory.CreateInMemoryContext();

                var runnerEntity = _fixture.CreateRunner(true);

                context.Runners.Add(runnerEntity);
                context.SaveChanges();

                var command = new GetActiveRunners();
                var runner = Assert.Single(await command.Execute(context));

                Assert.NotNull(runner);
                IsEntityEqualToRunner(runnerEntity, runner);
            }

            [Fact]
            public async Task WhenMultipleRunnersAreOnline_ThenRunnersAreReturnedInList()
            {
                var factory = new TestContextFactory();
                await using var context = factory.CreateInMemoryContext();

                var runnerEntity = _fixture.CreateRunner(true);
                var runnerEntity2 = _fixture.CreateRunner(true);

                context.Runners.Add(runnerEntity);
                context.Runners.Add(runnerEntity2);
                context.SaveChanges();

                var command = new GetActiveRunners();
                var runners = await command.Execute(context);

                var array = runners as Runner[] ?? runners.ToArray();
                Assert.Equal(2, array.Length);
                
                IsEntityEqualToRunner(runnerEntity, array[0]);
                IsEntityEqualToRunner(runnerEntity2, array[1]);
            }

            [Fact]
            public async Task WhenAllRunnersAreOffline_ThenListIsEmpty()
            {
                var factory = new TestContextFactory();
                await using var context = factory.CreateInMemoryContext();

                var runnerEntity = _fixture.CreateRunner(false);

                context.Runners.Add(runnerEntity);
                context.SaveChanges();

                var command = new GetActiveRunners();
                Assert.Empty(await command.Execute(context));
            }
        }

        private static void IsEntityEqualToRunner(RunnerEntity runnerEntity, Runner runner)
        {
            Assert.Equal(runnerEntity.Id, runner.Id);
            Assert.Equal(runnerEntity.Name, runner.Name);
            Assert.Equal(runnerEntity.IsOnline, runner.IsOnline);
            Assert.Equal(runnerEntity.Description, runner.Description);
            Assert.Equal(runnerEntity.ActiveGameTitle, runner.ActiveGameTitle);
        }
    }
}