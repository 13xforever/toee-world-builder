using System;
using System.IO;

namespace WorldBuilder.Helpers
{
	public static class Helper
	{
		/// <summary>
		///     Write an extended complement to 2
		/// </summary>
		public static void GetComp2Ex(BinaryWriter w_mob, uint no_entries)
		{
			uint ex_fillers = no_entries/32;
			uint c_highest = no_entries%32;

			w_mob.Write(ex_fillers + 1);

			for (int i = 0; i < ex_fillers; i++)
				w_mob.Write(0xFFFFFFFF);

			uint final_mod = (uint) Math.Pow(2, c_highest) - 1;
			w_mob.Write(final_mod);
		}

		/// <summary>
		///     Gen a size of an extended complement to 2
		/// </summary>
		public static uint GetSizeofComp2Ex(uint no_entries)
		{
			return (no_entries/32) + 1;
		}

		/// <summary>
		///     Hash function - HashPJW. Returns a 32-bit uint value from a string.
		/// </summary>
		public static uint hashpjw(string ptr)
		{
			uint val = 0;

			for (int i = 0; i < ptr.Length; i++)
			{
				uint tmp;
				val = (val << 4) + ptr[i];

				tmp = (val & 0xf0000000);
				if (tmp != 0)
				{
					val = val ^ (tmp >> 24);
					val = val ^ tmp;
				}
			}
			return val;
		}

		/// <summary>
		///     ElfHash - another hashing function. Used for lights.
		/// </summary>
		public static uint HashID_Generate(string str)
		{
			uint h = 0, g;
			for (int i = 0; i < str.Length; i++)
			{
				uint cur = str[i];
				if (cur >= 'a' && cur <= 'z') cur -= ('a' - 'A');
				h = (h << 4) + cur;
				g = h & 0xF0000000;
				if (g != 0)
					h ^= g >> 24;
				h &= ~g;
			}
			return h;
		}

		public static int GENERATOR_BITS = 0x07F80000;
		public static int GENERATOR_POS = 19;
		public static int SPAWNMAX_BITS = 0x0007C000;
		public static int SPAWNMAX_POS = 14;
		public static int TOTAL_BITS = 0x00003F80;
		public static int TOTAL_POS = 7;
		public static int NPCGEN_BITS = 0x00E00000;
		public static int NPCGEN_POS = 21;

		public static int GET_GENID(int target)
		{
			return (((target) & GENERATOR_BITS) >> GENERATOR_POS);
		}

		public static int GET_SPAWNMAX(int target)
		{
			return (((target) & SPAWNMAX_BITS) >> SPAWNMAX_POS);
		}

		public static int GET_TOTAL(int target)
		{
			return (((target) & TOTAL_BITS) >> TOTAL_POS);
		}

		public static int GET_NPCGEN(int target)
		{
			return (((target) & NPCGEN_BITS) >> NPCGEN_POS);
		}

		public static int MAKE_GENID(int x, int gid)
		{
			return (((x) & ~GENERATOR_BITS) | (((gid) & (GENERATOR_BITS >> GENERATOR_POS))) << GENERATOR_POS);
		}

		public static int MAKE_SPAWNMAX(int x, int max)
		{
			return (((x) & ~SPAWNMAX_BITS) | (((max) & (SPAWNMAX_BITS >> SPAWNMAX_POS))) << SPAWNMAX_POS);
		}

		public static int MAKE_TOTAL(int x, int tot)
		{
			return (((x) & ~TOTAL_BITS) | (((tot) & (TOTAL_BITS >> TOTAL_POS))) << TOTAL_POS);
		}

		public static int MAKE_NPCGEN(int x, int ngen)
		{
			return (((x) & ~NPCGEN_BITS) | (((ngen) & (NPCGEN_BITS >> NPCGEN_POS))) << NPCGEN_POS);
		}
	}
}