// ToEE World Builder .NET2 version 2.0.0 Open-Source Edition
// Copyright (C) 2005-2006    Michael Kamensky, all rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

// v1.6: A class for storing system message queues.
// Every message consists of two things: a boolean variable stating whether
// the message is currently awaiting to be processed, and an array list that
// actually stores the system message parameters queue. The parameters are parsed
// later in the Worlded main class (during the next heartbeat,usually every 1ms).
// If the queue doesn't exist, it's assumed that an empty queue is passed.
using System;
using System.Collections;

namespace ToEE_World_Builder
{
	public class SysMsg
	{
		private SysMsg(){}

		public static bool SM_REMEMBER_COORDS = false;
		public static ArrayList SM_REMEMBER_COORDS_QUEUE = new ArrayList();
		public static bool SM_PAINT_TILE = false;
		public static ArrayList SM_PAINT_TILE_QUEUE = new ArrayList();
		public static bool SM_PAINT_NOTHING = false;
		public static bool SM_PAINT_IMPASSABLE = false;
		public static bool SM_PAINT_FLYOVER = false;
		public static bool SM_PAINT_FLYOVER_COVER = false;
		public static bool SM_ADD_SVB1 = false;
		public static bool SM_REMOVE_SVB1 = false;
		public static bool SM_SAN_ENABLED = false;
        public static bool SM_PROTO_SEARCH = false;
        public static string SM_PROTO_SEARCH_PARAM = "";
        public static int SM_PROTO_SEARCH_TARGET = 0;

        // Special extended SVB support
        public static bool SM_SVB1 = false;
        public static int SM_SVB1_X = -1;
        public static int SM_SVB1_Y = -1;
        public static bool SM_SVB2 = false;
        public static int SM_SVB2_X = -1;
        public static int SM_SVB2_Y = -1;
        public static bool SM_SVB3 = false;
        public static int SM_SVB3_X = -1;
        public static int SM_SVB3_Y = -1;
        public static bool SM_SVB4 = false;
        public static int SM_SVB4_X = -1;
        public static int SM_SVB4_Y = -1;

		// Test message. For debug purposes only.
		public static bool SM_TEST_MSG = false;
		public static ArrayList SM_TEST_MSG_QUEUE = new ArrayList();
	}
}
