using System;
using System.Collections;

namespace GraphPathing
{
	public class GridGraph
	{
		protected int gridWidth, gridHeight;

		public GridGraph(int width, int height)
		{
			gridWidth = width;
			gridHeight = height;
		}

		public bool validLocation (Location loc)
		{
			if (loc.X >= 0 && loc.X < gridWidth && loc.Y >= 0 && loc.Y < gridHeight)
				return true;

			return false;
		}

		public bool validLocation (int x, int y)
		{
			if (x >= 0 && x < gridWidth && y >= 0 && y < gridHeight)
				return true;

			return false;
		}

		public ArrayList getNeighbors (int x, int y)
		{
			return getNeighbors (new Location (x, y));
		}

		public ArrayList getNeighbors (Location loc)
		{
			ArrayList neighbors = new ArrayList();

			if (validLocation (loc)) {
				if (validLocation (loc.X + 1, loc.Y)) {
					neighbors.Add(new Location(loc.X + 1, loc.Y));
				}
				if (validLocation (loc.X - 1, loc.Y)) {
					neighbors.Add (new Location (loc.X - 1, loc.Y));
				}
				if (validLocation (loc.X, loc.Y+1)) {
					neighbors.Add (new Location(loc.X, loc.Y+1));
				}
				if (validLocation (loc.X, loc.Y - 1))
					neighbors.Add (new Location (loc.X, loc.Y - 1));
			}

			return neighbors;
		}

		public int getManhattanDistance(Location a, Location b)
		{
			if (validLocation (a) && validLocation (b)) {
				return (Math.Abs (a.X - b.X) + Math.Abs (a.Y - b.Y));
			}

			return -1;
		}
	}
}

