using MonteOlimpo.Base.Core.Tests;
using MonteOlimpo.Data;
using MonteOlimpo.Repository;
using MonteOlimpo.Service;
using System.Collections.Generic;
using System.Reflection;

namespace MonteOlimpo.Test.Base
{
    public class MonteOlimpoTestFixture : TestsFixture<MonteOlimpoContext>
    {
        protected override IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(GodRepository).Assembly;
            yield return typeof(GodService).Assembly;
        }
    }
}