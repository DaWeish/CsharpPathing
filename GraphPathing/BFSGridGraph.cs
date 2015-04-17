using System;
using System.Collections;

namespace GraphPathing
{
	public class BFSGridGraph : GridGraph
	{
		protected Queue frontier;
		protected Location[,] cameFrom;

		public BFSGridGraph (int width, int height) : base (width, height)
		{
			frontier = new Queue ();

			cameFrom = new Location[gridWidth, gridHeight];
			for (int i = 0; i < gridWidth; i++) {
				for (int j = 0; j < gridHeight; j++) {
					cameFrom [i, j] = new Location (-1, -1);
				}
			}
		}

		public void calculatePath(Location start, Location end)
		{
			if (validLocation (start) && validLocation (end)) {
				frontier.Enqueue (start);
				cameFrom [start.X, start.Y] = start;
				bool goalFound = false;

				while (frontier.Count != 0 && !goalFound) {
					var current = (Location)frontier.Dequeue ();

					if (current == end) {
						goalFound = true;
						continue;
					}

					foreach (Location next in getNeighbors(current)) {
						if (!validLocation (cameFrom [next.X, next.Y])) {
							frontier.Enqueue (next);
							cameFrom [next.X, next.Y] = current;
						}
					}
				}
			}
		}

		public Stack getCalculatedPath(Location start, Location end)
		{
			Stack myPath = new Stack ();

			if (validLocation (start) && validLocation (end)) {
				Location current = end;
				myPath.Push (current);

				while (cameFrom [current.X, current.Y] != current) {
					current = cameFrom [current.X, current.Y];
					myPath.Push (current);
				}
			}

			return myPath;
		}
	}
}

