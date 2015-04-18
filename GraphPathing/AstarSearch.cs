using System;
using System.Collections;
using Priority_Queue;

namespace GraphPathing
{
	public class AstarSearch
	{
		protected HeapPriorityQueue<Location> frontier;
		protected Location[,] cameFrom;
		protected int[,] costSoFar;

		protected WeightedGridGraph graph;

		private const int LARGEVALUE = 1000000;

		public AstarSearch (WeightedGridGraph parGraph)
		{
			graph = parGraph;
			cameFrom = new Location[graph.getGridWidth(), graph.getGridHeight()];
			costSoFar = new int[graph.getGridWidth (), graph.getGridHeight ()];
			frontier = new HeapPriorityQueue<Location> (graph.getGridWidth() * graph.getGridHeight());

			for (int i = 0; i < graph.getGridWidth (); i++) {
				for (int j = 0; j < graph.getGridHeight (); j++) {
					cameFrom [i, j] = new Location (-1, -1);
//					costSoFar [i, j] = LARGEVALUE;
				}
			}
		}

		public bool calculatePath (Location start, Location end, Stack path)
		{
			bool goalFound = false;

			if (graph.validLocation (start) && graph.validLocation (end)) {
			
				for (int i = 0; i < graph.getGridWidth (); i++) {
					for (int j = 0; j < graph.getGridHeight (); j++) {
						cameFrom [i, j].X = -1;
						cameFrom [i, j].Y = -1;
						costSoFar [i, j] = LARGEVALUE; // initialize to large value acts as infinity
					}
				}

				cameFrom [start.X, start.Y] = start;
				costSoFar [start.X, start.Y] = 0;

				frontier.Enqueue (start, 0);

				while (frontier.Count != 0 && !goalFound) {
					var current = frontier.Dequeue ();

					if (current == end) {
						goalFound = true;
						continue;
					}

					foreach (Location next in graph.getNeighbors(current)) {
						int newCost = costSoFar [current.X, current.Y] + graph.getCost (next);

						if (newCost < costSoFar [next.X, next.Y]) {
							costSoFar [next.X, next.Y] = newCost;
							double priority = newCost + graph.getManhattanDistance (next, end);
							frontier.Enqueue (next, priority);
							cameFrom [next.X, next.Y] = current;
						}
					
					}
				}

				if (!goalFound) {
					cameFrom [end.X, end.Y] = end;
				}

				Location step = end;
				path.Push (step);

				while (cameFrom [step.X, step.Y] != step) {
					step = cameFrom [step.X, step.Y];
					path.Push (step);
				}
			}

			return goalFound;

		}
	}
}

