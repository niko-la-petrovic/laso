#pragma once

#include <complex>

#ifdef LASOCORE_EXPORTS
#define LASOCORE_API __declspec(dllexport)
#else
#define LASOCORE_API __declspec(dllimport)
#endif

namespace laso
{
	namespace core
	{

		extern "C" LASOCORE_API bool method(bool test) noexcept;

		extern "C" LASOCORE_API void fft(const double* signal, const unsigned signalLength,
			std::complex<double>*spectralComponents) noexcept(false);

		class init
		{
		public:
			static bool initMethod(bool test) noexcept;
		protected:

		private:

		};
	}
}