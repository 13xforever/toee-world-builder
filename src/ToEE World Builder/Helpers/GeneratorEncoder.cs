namespace WorldBuilder.Helpers
{
	public static class GeneratorEncoder
	{
		public sealed class BitsOperator
		{
			private readonly int mask;
			private readonly int shiftedMask;
			private readonly int invertedMask;
			private readonly int shift;

			public BitsOperator(int mask, int shift)
			{
				this.mask = mask;
				this.shift = shift;
				shiftedMask = mask >> shift;
				invertedMask = ~mask;
			}

			private int Get(int value)
			{
				return (value & mask) >> shift;
			}

			private int Set(int oldValue, int newValue)
			{
				return oldValue & ~mask | ((newValue & (mask >> shift)) << shift);
			}
		}

		public static readonly BitsOperator GenId = new BitsOperator(0x07f80000, 19); //00000111 11111000 00000000 00000000
		public static readonly BitsOperator NpcGen = new BitsOperator(0x00e00000, 21); //00000000 11100000 00000000 00000000
		public static readonly BitsOperator SpawnMax = new BitsOperator(0x0007c000, 14); //00000000 00000111 11000000 00000000
		public static readonly BitsOperator Total = new BitsOperator(0x00003f80, 7); //00000000 00000000 00111111 10000000

	}
}