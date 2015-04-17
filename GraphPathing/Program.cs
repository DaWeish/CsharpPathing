using System;
using System.Collections;

namespace GraphPathing
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var myGraph = new BFSGridGraph(10, 10);

			myGraph.calculatePath (new Location (1, 2), new Location (7, 8));

			Console.WriteLine ("Printing path from 1,2 to 7, 8");
			foreach (Location loc in myGraph.getCalculatedPath (new Location(1, 2), new Location (7, 8))) {
				Console.WriteLine (loc.X + ", " + loc.Y);
			}
		}
	}
}
