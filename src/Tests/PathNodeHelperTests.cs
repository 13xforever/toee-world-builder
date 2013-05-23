using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WorldBuilder;

namespace Tests
{
	[TestFixture]
	public class PathNodeHelperTests
	{
		[Test]
		[TestCase(0u, 0u, 1u, 0u, 1d, TestName = "Minimal horizontal line")]
		[TestCase(0u, 0u, uint.MaxValue, 0u, (double)uint.MaxValue, TestName = "Maximal horizontal line")]
		[TestCase(0u, 0u, uint.MaxValue, 1u, 4294967295.000000000116415321854d, TestName = "Maximum skew error")]
		[TestCase(0u, 0u, 1u, 1u, 1.4142135623730950488016887242097d, TestName = "1x1 square")]
		[TestCase(0u, 0u, (uint)byte.MaxValue, (uint)byte.MaxValue, 360.62445840513923744443062467347d, TestName = "Maximum distance for Byte parameters")]
		[TestCase(0u, 0u, (uint)short.MaxValue, (uint)short.MaxValue, 46339.535798279205464084934426179d, TestName = "Maximum distance for Int16 parameters")]
		[TestCase(0u, 0u, (uint)ushort.MaxValue, (uint)ushort.MaxValue, 92680.485810120784023218670541083d, TestName = "Maximum distance for UInt16 parameters")]
		[TestCase(0u, 0u, (uint)int.MaxValue, (uint)int.MaxValue, 3037000498.5618361300782934812246d, TestName = "Maximum distance for int parameters")]
		[TestCase(0u, 0u, uint.MaxValue, uint.MaxValue, 6074000998.5378858225296820112509d, TestName = "Maximum distance for uint parameters")]
		public void GetPathLength(uint x1, uint y1, uint x2, uint y2, double expected)
		{
			var node1 = new PathNode(1, x1, y1, 0, 0);
			var node2 = new PathNode(2, x2, y2, 0, 0);

			Assert.That(node1.IsNear(node2, expected), Is.True);
		}

		[Test]
		public void SaveThroughStackVoodo()
		{
			var collection = new[] {1, 2, 3, 4, 5};
			var stack = new Stack<int>(collection);
			var e = stack.GetEnumerator();
			e.MoveNext();

			Assert.That(e.Current, Is.EqualTo(collection.Last()));
			Assert.That(stack.AsEnumerable(), Is.EqualTo(collection.Reverse()));
		}
	}
}