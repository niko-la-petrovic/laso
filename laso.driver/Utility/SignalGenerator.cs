using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laso.driver.Utility
{
    public class SignalGenerator
    {
        const double samplingFrequency = 44.1e3;
        const int sampleNumber = 4096;

        public static double[] SineWaveRawSignal(
            double signalFrequency = 1e3,
            double samplingFrequency = samplingFrequency,
            double amplitude = 1,
            int sampleNumber = sampleNumber)
        {
            double[] signal = new double[sampleNumber];

            for (int i = 0; i < sampleNumber; i++)
            {
                double t = i / samplingFrequency;
                signal[i] = amplitude * Math.Sin(2 * Math.PI * signalFrequency * t);
            }

            return signal;
        }

        public static double[] Frequencies(
            double samplingFrequency = samplingFrequency,
            int sampleNumber = sampleNumber, bool halfSpectrum = true)
        {
            int frequencyBins = halfSpectrum ? sampleNumber / 2 : sampleNumber;
            double[] frequencies = new double[frequencyBins];

            for(int i = 0; i< frequencyBins; i++)
                frequencies[i] = i * samplingFrequency / sampleNumber;

            return frequencies;
        }
    }
}
