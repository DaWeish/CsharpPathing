using System;
using System.Collections;

namespace GraphPathing
{
	public class WeightedGridGraph : GridGraph
	{
		protected int[,] locationWeight;

		public WeightedGridGraph (int width, int height) : base (width, height)
		{
			locationWeight = new int[gridWidth, gridHeight];

			for (int i = 0; i < gridWidth; i++) {
				for (int j = 0; j < gridHeight; j++) {
					locationWeight [i, j] = 0;
				}
			}
		}

		public int getCost(Location dest)
		{
			if (validLocation(dest))
				return locationWeight [dest.X, dest.Y];

			return -1;
		}

		public void setLocationWeight(Location loc, int weight)
		{
			if (validLocation (loc)) {
				locationWeight [loc.X, loc.Y] = weight;
			}
		}

		public void setLocationWeight(int[,] weights)
		{
			locationWeight = weights;
		}
	}
}

