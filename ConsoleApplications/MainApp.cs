using System;
using System.Linq;

namespace ConsoleApplications
{
	class MainApp
	{
		static void Main( string[] args )
		{
			
		}

		private static void Task05_MinAbsSum()
		{
			var input = Console.ReadLine()
							.Split( new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries )
							.Select( int.Parse )
							.ToArray();

			try
			{
				var result = Task05_Solution.Solution( input );

				Console.WriteLine( result );
			}
			catch ( Exception e )
			{
				Console.WriteLine( e.Message );
			}
		}

		private static void Task02_GenomicRangeQuery()
		{
			var s = Console.ReadLine();

			var p = Console.ReadLine()
				.Split( new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();

			var q = Console.ReadLine()
				.Split( new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();

			try
			{
				var result = Task02_Solution.Solution( s, p, q );

				Console.WriteLine( string.Join( " ", result ) );
			}
			catch ( Exception e )
			{
				Console.WriteLine( e.Message );
			}
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