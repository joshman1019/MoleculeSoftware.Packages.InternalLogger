using System.Reflection;
using Xunit.Sdk;

namespace MoleculeSoftware.Packages.InternalLogger.Testing
{
    internal class TestingBeforeAndAfter : BeforeAfterTestAttribute
    {
        public override async void Before(MethodInfo methodUnderTest)
        {
            await LibraryInitUtilities.Init();
        }
    }
}
