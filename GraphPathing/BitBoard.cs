using System;
using System.Collections;

namespace GraphPathing
{
	public class BitBoard
	{
		public int width { get; private set; }
		public int height { get; private set; }

		protected BitArray[] board;

		public BitBoard (int pwidth, int pheight)
		{
			width = pwidth;
			height = pheight;

			board = new BitArray[width];

			for (int i = 0; i < width; i++) {
				board [i] = new BitArray (height, false);
			}
		}

		public void setBits(bool value, params Location[] locations)
		{
			foreach (Location loc in locations) {
				if (validBitLocation (loc)) {
					board [loc.X].Set (loc.Y, value);
				}
			}
		}

		// input Location must be a valid Location in the BitBoard
		public bool getBit(Location loc)
		{
			return board [loc.X].Get (loc.Y);

		}

		public bool validBitLocation (Location loc)
		{
			if (loc.X >= 0 && loc.X < width && loc.Y >= 0 && loc.Y < height)
				return true;

			return false;
		}
	}
}

