using Laso.Driver.Interop;
using System;
using System.Linq;
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

        [Fact]
        public void CanCallFFT()
        {
            double[] signal = new double[1 << 12];

            Random random = new Random();
            for (int i = 0; i < signal.Length; i++)
                signal[i] = (1 << 24)*random.NextDouble();

            var spectralComponents = CoreInterop.FFT(signal);
        }
    }
}
