using Speedruns.Runners.Stores;

namespace Speedruns.Runners.Tests.CoreFakes
{
    public static class TestBuilderExtensions
    {
        public static bool HasBeenCalled { get; private set; }

        public static Settings UseTest(this SettingsBuilder builder, TestStore store)
        {
            HasBeenCalled = true;
            return new TestSettings(store);
        }
    }
}