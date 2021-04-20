#include "pch.h"
#include "CppUnitTest.h"
#include "laso.core.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace laso::core;

namespace laso
{
	namespace core
	{
		namespace test
		{

			TEST_CLASS(lasocoretest)
			{
			public:

				TEST_METHOD(TestMethod1)
				{
					Assert::AreEqual(method(true), true);
				}
			};


		}
	}
}
