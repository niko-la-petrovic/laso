#pragma once

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

		class init
		{
		public:
			static bool initMethod(bool test) noexcept;
		protected:

		private:

		};
	}
}