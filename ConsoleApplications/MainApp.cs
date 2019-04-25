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
			var n = Convert.ToInt32( Console.ReadLine() );

			var inputArray = Console.ReadLine()
				.Split( new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();

			try
			{
				var result = Task01_Solution.Solution( n, inputArray );

				Console.WriteLine( "(" + string.Join( ", ", result ) + ")" );
			}
			catch ( Exception e )
			{
				Console.WriteLine( e.Message );
			}
		}
	}
}