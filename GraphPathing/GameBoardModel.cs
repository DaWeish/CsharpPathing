using System;
using System.Collections;

namespace GraphPathing
{
	public class GameBoardModel : WeightedGridGraph
	{
		protected BitBoard impassables;

		public GameBoardModel (int width, int height) : base (width, height)
		{
			impassables = new BitBoard (gridWidth, gridHeight);
		}

		public GameBoardModel (int width, int height, BitBoard walls) : base (width, height)
		{
			if (walls.width == width && walls.height == height) {
				impassables = walls;
			} else {
				impassables = new BitBoard (gridWidth, gridHeight);
			}

		}

		public override ArrayList getNeighbors(Location loc)
		{
			ArrayList neighborsOld = base.getNeighbors (loc);
			ArrayList neighbors = new ArrayList ();

			foreach (Location tile in neighborsOld) {
				if (!impassables.getBit (tile)) {
					neighbors.Add (tile);
				}
			}

			return neighbors;
		}

		public void setImpassables(BitBoard walls) {
			if (walls.width == impassables.width && walls.height == impassables.height)
				impassables = walls;
		}
	}
}

