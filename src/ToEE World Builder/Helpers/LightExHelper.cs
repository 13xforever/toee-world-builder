namespace WorldBuilder.Helpers
{
	public static class LightExHelper
	{
		private const uint LGT_ANIMATED = 0x00000004;
		private const uint LGT_EXTENDED_LIGHT = 0x00000010;
		private const uint LGT_PARTICLE_SYSTEM = 0x00000020;
		private const uint LGT_STATUS_1 = 0x00000001; // Light flags
		private const uint LGT_STATUS_2 = 0x00000002;
		private const uint LGT_VIEW_CONTROLS = 0x00000008;

		/// <summary>
		///     A basic 64-byte light. A structure that must be defined for all lights.
		/// </summary>
		public struct LightBasic
		{
			public float angle; // light angle
			public byte blue; // blue
			public Vector3 direction; // direction of the light
			public uint flags; // light flags
			public byte green; // green
			public ulong handle; // must always be 0x0?
			public float height; // offset Z (height)
			public float ofs_x; // offset X
			public float ofs_y; // offset Y
			public byte padding1; // padding area (has no effect)
			public uint padding2; // padding area (has no effect)
			public float range; // light range
			public byte red; // red
			public uint type; // light type
			public uint x; // coordinate X
			public uint y; // coordinate Y
		}

		/// <summary>
		///     Extended light structure. Incorporates both the primary and the secondary lights. 108 bytes long.
		///     It is recommended to use this structure in any case, and write back necessary parts of the light
		///     per the flags and type.
		/// </summary>
		public struct LightEx
		{
			public LightPrimary light_pri;
			public LightSecondary light_sec;
		}

		/// <summary>
		///     Primary light structure. Used for all light types and wraps a basic light. 72 bytes long.
		/// </summary>
		public struct LightPrimary
		{
			public LightBasic light1; // primary light
			public PartSys partsys1; // primary light particle system
		}

		/// <summary>
		///     Secondary light structure. Used only for certain light types.
		/// </summary>
		public struct LightSecondary
		{
			public float angle; // light angle
			public byte blue; // blue
			public Vector3 direction; // direction of the light
			public byte green; // green
			public byte padding1; // padding area (has no effect)
			public PartSys partsys2; // secondary light particle system
			public float range; // light range
			public byte red; // red
			public uint type; // light type
		}

		/// <summary>
		///     Particle system substructure.
		/// </summary>
		public struct PartSys
		{
			public uint hash_id; // hash ID for the particle system name
			public uint id; // ID of the particle system
		}

		/// <summary>
		///     A structure defining three a 3-dimensional (x,y,z) vector
		/// </summary>
		public struct Vector3
		{
			public float x;
			public float y;
			public float z;
		}
	}
}