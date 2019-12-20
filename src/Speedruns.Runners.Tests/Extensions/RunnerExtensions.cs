using AutoFixture;
using Speedruns.Runners.Entities;

namespace Speedruns.Runners.Tests
{
    public static class RunnerExtensions
    {
        public static RunnerEntity CreateRunner(this Fixture fixture, bool isOnline)
        {
            return fixture.Build<RunnerEntity>()
                .Without(entity => entity.Id)
                .With(entity => entity.IsOnline, isOnline)
                .Create();
        }
    }
}