using System;
using Microsoft.EntityFrameworkCore;
using Speedruns.Runners.Stores;

namespace Speedruns.Runners.Tests
{
    public class TestContextFactory : ContextFactory
    {
        public Context CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new Context(options);
        }
    }
}