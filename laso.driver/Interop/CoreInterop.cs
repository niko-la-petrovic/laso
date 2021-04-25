using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laso.Driver.Interop
{
    public class CoreInterop
    {
        const string coreLibFilePath = "laso.core.dll";
        public static bool Method(bool test) => method(test);

        /// <summary>
        /// Returns an array of Complex, representing the signal in frequency domain.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="signal">Byte array of PCM signal samples.</param>
        /// <param name="signalLength">Length of signal (number of samples).</param>
        /// <param name="spectralComponents">Array of complex numbers. Should be 2*sizeof(</param>
        public static Complex[] FFT(double[] signal)
        {
            uint signalLength = (uint)signal.Length;

            //Complex[] spectralComponents = new Complex[signalLength / 2];
            Complex[] spectralComponents = new Complex[signalLength];

            GCHandle pinnedSignal = GCHandle.Alloc(signal, GCHandleType.Pinned);
            GCHandle pinnedSpectralComponents = GCHandle.Alloc(spectralComponents, GCHandleType.Pinned);
            try
            {
                IntPtr signalPtr = pinnedSignal.AddrOfPinnedObject();
                IntPtr spectralComponentsPtr = pinnedSpectralComponents.AddrOfPinnedObject();
                fft(signalPtr, signalLength, spectralComponentsPtr);
            }
            finally
            {
                pinnedSpectralComponents.Free();
                pinnedSignal.Free();
            }

            return spectralComponents;
        }

        // Internals

        [DllImport(coreLibFilePath, CallingConvention = CallingConvention.Cdecl)]
        internal extern static bool method(bool test);

        [DllImport(coreLibFilePath, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void fft(IntPtr signal, uint signalLength, IntPtr spectralComponents);

    }
}
