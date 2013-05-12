using System;
using NUnit.Framework;
using WorldBuilder.Helpers;

namespace Tests
{
	[TestFixture]
	public class GenHelperTests
	{
		[Test]
		public void ConvertBytesToStringGuid()
		{
			var guid = Guid.NewGuid();
			var guidBytes = new byte[24];
			guid.ToByteArray().CopyTo(guidBytes, 8);

			var expected = "G_" + guid.ToString("D").Replace('-', '_').ToUpper();
			Assert.That(GenHelper.ConvertBytesToStringGuid(guidBytes), Is.EqualTo(expected));
		}
	}
}