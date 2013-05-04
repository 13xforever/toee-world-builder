using System.Collections;

namespace WorldBuilder
{
	/// <summary>
	/// v1.6: A class for storing system message queues.
	/// Every message consists of two things: a boolean variable stating whether
	/// the message is currently awaiting to be processed, and an array list that
	/// actually stores the system message parameters queue. The parameters are parsed
	/// later in the Worlded main class (during the next heartbeat, usually every 1ms).
	/// If the queue doesn't exist, it's assumed that an empty queue is passed.
	/// </summary>
	public static class SysMsg
	{
		public static bool SM_REMEMBER_COORDS;
		public static ArrayList SM_REMEMBER_COORDS_QUEUE = new ArrayList();
		public static bool SM_PAINT_TILE;
		public static ArrayList SM_PAINT_TILE_QUEUE = new ArrayList();
		public static bool SM_PAINT_NOTHING;
		public static bool SM_PAINT_IMPASSABLE;
		public static bool SM_PAINT_FLYOVER;
		public static bool SM_PAINT_FLYOVER_COVER;
		public static bool SM_ADD_SVB1;
		public static bool SM_REMOVE_SVB1;
		public static bool SM_SAN_ENABLED;
		public static bool SM_PROTO_SEARCH;
		public static string SM_PROTO_SEARCH_PARAM = "";
		public static int SM_PROTO_SEARCH_TARGET;

		// Special extended SVB support
		public static bool SM_SVB1;
		public static int SM_SVB1_X = -1;
		public static int SM_SVB1_Y = -1;
		public static bool SM_SVB2;
		public static int SM_SVB2_X = -1;
		public static int SM_SVB2_Y = -1;
		public static bool SM_SVB3;
		public static int SM_SVB3_X = -1;
		public static int SM_SVB3_Y = -1;
		public static bool SM_SVB4;
		public static int SM_SVB4_X = -1;
		public static int SM_SVB4_Y = -1;

		// Test message. For debug purposes only.
		public static bool SM_TEST_MSG;
		public static ArrayList SM_TEST_MSG_QUEUE = new ArrayList();
	}
}
