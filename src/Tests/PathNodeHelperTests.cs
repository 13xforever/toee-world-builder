using NUnit.Framework;
using WorldBuilder.Helpers;

namespace Tests
{
	[TestFixture]
	public class PathNodeHelperTests
	{
		[Test]
		[TestCase(0u, 0u, (uint)short.MaxValue, (uint)short.MaxValue, 46339.535798279205464084934426179d, TestName = "Maximum distance for Int16 parameters")]
		[TestCase(0u, 0u, (uint)ushort.MaxValue, (uint)ushort.MaxValue, 92680.485810120784023218670541083d, TestName = "Maximum distance for UInt16 parameters")]
		[TestCase(0u, 0u, (uint)int.MaxValue, (uint)int.MaxValue, 3037000498.5618361300782934812246d, TestName = "Maximum distance for Int32 parameters")]
		[TestCase(0u, 0u, uint.MaxValue, uint.MaxValue, 6074000998.5378858225296820112509d, TestName = "Maximum distance for UInt32 parameters")]
		public void GetPathLength(uint x1, uint y1, uint x2, uint y2, double expected)
		{
			const double epsilon = 0.001;

			var len = PathNodeHelper.GetPathLength(x1, y1, x2, y2);
			var delta = len - expected;
			Assert.That(delta, Is.InRange(-epsilon, epsilon));
		}
	}
}