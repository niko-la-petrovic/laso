using Laso.Driver.Interop;
using System;
using Xunit;

namespace laso.driver.test
{
    public class UnitTest1
    {
        [Fact]
        public void AlwaysTrue()
        {
            
        }

        [Fact]
        public void ExternTest()
        {
            Assert.True(CoreInterop.Method(true));
        }

    }
}
