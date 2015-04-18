using System;
using Priority_Queue;

namespace GraphPathing
{
	public class Location : PriorityQueueNode
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Location()
		{
			X = -1;
			Y = -1;
		}

		public Location(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static bool operator == (Location lhs, Location rhs)
		{
			if (lhs.X == rhs.X && lhs.Y == rhs.Y)
				return true;

			return false;
		}

		public static bool operator != (Location lhs, Location rhs) {
			return !(lhs == rhs);
		}
	}
}

