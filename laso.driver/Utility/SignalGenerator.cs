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

        public static double[] SineWaveRaw(
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

        /// <summary>
        /// Returns an array of frequencies as detemrined by the sampling rate and number of samples.
        /// </summary>
        /// <param name="samplingFrequency">Sampling frequency.</param>
        /// <param name="sampleNumber">Number of samples.</param>
        /// <param name="halfRange">Whether it should return only half of the frequency range.</param>
        /// <returns></returns>
        public static double[] Frequencies(
            double samplingFrequency = samplingFrequency,
            int sampleNumber = sampleNumber, bool halfRange = true)
        {
            int frequencyBins = halfRange ? sampleNumber / 2 : sampleNumber;
            double[] frequencies = new double[frequencyBins];

            for(int i = 0; i< frequencyBins; i++)
                frequencies[i] = i * samplingFrequency / sampleNumber;

            return frequencies;
        }
    }
}
