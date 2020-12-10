using DistinctValues;
using NUnit.Framework;

namespace DistinctValuesTests
{

	[TestFixture]
	public class DistinctValuesCalculatorTests
	{
		private DistinctValuesCalculator _calculator;

		[SetUp]
		public void Setup()
		{
			_calculator = new DistinctValuesCalculator();
		}

		[Test]
		public void Null_Array_Returns_Empty_String()
		{
			var result = _calculator.GetDistinctValues(null);
			Assert.AreEqual(string.Empty, result);
		}

		[Test]
		public void Empty_Array_Returns_Empty_String()
		{
			var values = new int[0];
			var result = _calculator.GetDistinctValues(values);
			Assert.AreEqual(string.Empty, result);
		}

		[Test]
		public void Single_Value_Returns_Single_Line()
		{
			var values = new[] {1};
			var result = _calculator.GetDistinctValues(values);
			Assert.AreEqual("1-1", result);
		}

		[Test]
		public void Multiple_Distinct_Values_Returns_Multiple_Lines()
		{
			var values = new[] {1, 2};
			var result = _calculator.GetDistinctValues(values);
			Assert.AreEqual("1-1\n2-1", result);
		}

		[Test]
		public void Single_Duplicate_Value_Returns_Single_Line()
		{
			var values = new[] {1, 1};
			var result = _calculator.GetDistinctValues(values);
			Assert.AreEqual("1-2", result);
		}

		[Test]
		public void Multiple_Duplicate_Values_Returns_Single_Line_Per_Value()
		{
			var values = new[] {1, 1, 2, 2};
			var result = _calculator.GetDistinctValues(values);
			Assert.AreEqual("1-2\n2-2", result);
		}

		[Test]
		public void Mix_Of_Duplicate_And_Non_Duplicate_Values_Returns_The_Correct_Lines()
		{
			var values = new[] {1, 2, 2, 3, 4, 4, 4 };
			var result = _calculator.GetDistinctValues(values);
			Assert.AreEqual("1-1\n2-2\n3-1\n4-3", result);
		}
	}
}
