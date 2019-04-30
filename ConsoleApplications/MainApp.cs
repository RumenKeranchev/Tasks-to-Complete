using System;
using System.Linq;

namespace ConsoleApplications
{
	class MainApp
	{
		static void Main( string[] args )
		{

		}

		private static void Task07_CountNonDivisible()
		{
			var input = ReadInputArray();

			try
			{
				var restult = Task07_Solution.Solution( input );

				Console.WriteLine( string.Join( " ", restult ) );
			}
			catch ( Exception e )
			{
				Console.WriteLine( e.Message );
			}
		}

		private static void Task05_MinAbsSum()
		{
			var input = ReadInputArray();

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

		private static void Task03_Triangle()
		{
			var input = ReadInputArray();

			try
			{
				var result = Task03_Solution.Solution( input );

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

			var p = ReadInputArray();

			var q = ReadInputArray();

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
			int[] input = ReadInputArray();

			try
			{
				var result = Task01_Solution.Solution( n, input );

				Console.WriteLine( "(" + string.Join( ", ", result ) + ")" );
			}
			catch ( Exception e )
			{
				Console.WriteLine( e.Message );
			}
		}

		private static int[] ReadInputArray()
		{
			return Console.ReadLine()
				.Split( new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();
		}
	}
}