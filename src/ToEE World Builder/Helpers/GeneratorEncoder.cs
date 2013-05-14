namespace WorldBuilder.Helpers
{
	public static class GeneratorEncoder
	{
		public interface IBitOperation<T>
		{
			T Get(T value);
			T Set(T oldValue, T newValue);
		}

		private sealed class BitsOperator: IBitOperation<int>
		{
			private readonly int mask;
			private readonly int shift;

			public BitsOperator(int mask, int shift)
			{
				this.mask = mask;
				this.shift = shift;
			}

			public int Get(int value)
			{
				return (value & mask) >> shift;
			}

			public int Set(int oldValue, int newValue)
			{
				return oldValue ^ (((newValue << shift) ^ oldValue) & mask);
			}
		}

		public static readonly IBitOperation<int> GenId		= new BitsOperator(0x07f80000, 19); //00000111 11111000 00000000 00000000
		public static readonly IBitOperation<int> NpcGen	= new BitsOperator(0x00e00000, 21); //00000000 11100000 00000000 00000000
		public static readonly IBitOperation<int> SpawnMax	= new BitsOperator(0x0007c000, 14); //00000000 00000111 11000000 00000000
		public static readonly IBitOperation<int> Total		= new BitsOperator(0x00003f80,  7); //00000000 00000000 00111111 10000000
	}
}