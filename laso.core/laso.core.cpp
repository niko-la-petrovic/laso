#include "pch.h"
#include "laso.core.h"

#include <stdexcept>
#include <math.h>
#include <bit>
#include <stack>
#include <utility>
#include <numbers>

using namespace std;

namespace laso
{
	namespace core
	{

		bool method(bool test) noexcept
		{
			return test;
		}

		complex<double>* fft_recurse(const double* signal, const unsigned signalLength,
			complex<double>* inSpectralArray = nullptr)
		{
			bool useSpectralArray = inSpectralArray != nullptr;
			complex<double>* spectralComponents = useSpectralArray ? inSpectralArray :
				new complex<double>[signalLength];

			const unsigned halfSignalLength = signalLength / 2;

			if (signalLength == 1)
			{
				spectralComponents[0] = signal[0];
				return spectralComponents;
			}

			double* evenSignal = new double[halfSignalLength];
			double* oddSignal = new double[halfSignalLength];

			for (unsigned i = 0; i < halfSignalLength; i++)
			{
				evenSignal[i] = signal[i * 2];
				oddSignal[i] = signal[i * 2 + 1];
			}

			complex<double>* evenSpectralComponents = fft_recurse(evenSignal, halfSignalLength);
			complex<double>* oddSpectralComponents = fft_recurse(oddSignal, halfSignalLength);

			for (unsigned i = 0; i < halfSignalLength; i++)
			{
				complex<double> oddOffsetSpectralComponent =
					polar<double>(1, -2 * numbers::pi * (i / static_cast<double>(signalLength))) *
					oddSpectralComponents[i];

				spectralComponents[i] = evenSpectralComponents[i] + oddOffsetSpectralComponent;
				spectralComponents[halfSignalLength + i] = evenSpectralComponents[i] - oddOffsetSpectralComponent;
			}

			delete[] evenSignal;
			delete[] oddSignal;

			return spectralComponents;
		}

		void fft(const double* signal, const unsigned signalLength,
			complex<double>* spectralComponents) noexcept(false)
		{
			if (signal == nullptr)
				throw exception("Signal pointer is null.");

			if (spectralComponents == nullptr)
				throw exception("Spectral component pointer is null.");

			if (signalLength == 0)
				throw length_error("Signal length cannot be 0.");

			if (!_Is_pow_2(signalLength))
				throw length_error("Signal length must be a power of 2.");

			fft_recurse(signal, signalLength, spectralComponents);
		}

		bool init::initMethod(bool test) noexcept
		{
			return test;
		}

	}
}