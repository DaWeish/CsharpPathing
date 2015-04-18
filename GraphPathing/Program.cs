using System;
using System.Collections;

namespace GraphPathing
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var myBoard = new GameBoardModel (5, 5);

			var pathAlg = new AstarSearch (myBoard);

			Location wall1 = new Location (0, 1);
			Location wall2 = new Location (1, 0);

			Stack myPath = new Stack ();
			BitBoard myWalls = new BitBoard (5, 5);
			myWalls.setBits (true, wall1, wall2);

			Location a = new Location (0, 0);
			Location b = new Location (4, 4);

			Location c = new Location (3, 2);
			myBoard.setLocationWeight (c, 4);
			myBoard.setImpassables (myWalls);

			if (pathAlg.calculatePath (a, b, myPath)) {

				while (myPath.Count != 0) {
					Location temp = (Location)myPath.Pop ();
					Console.WriteLine (temp.X + ", " + temp.Y);
				}
			} else {
				Console.WriteLine ("No path exists!");
			}

			return;
		}
	}
}
