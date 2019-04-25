using System;
using System.Linq;

namespace ConsoleApplications
{
	class MainApp
	{
		static void Main( string[] args )
		{

		}

		private static void Task01_MaxCounters()
		{
			var inputArray = Console.ReadLine()
							.Split( new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries )
							.Select( int.Parse )
							.ToArray();

			var result = Task01_Solution.Solution( 5, inputArray );

			Console.WriteLine( "(" + string.Join( ", ", result ) + ")" );
		}
	}
}