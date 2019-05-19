using System;
using System.Linq;

namespace Recursion
{
	class MainApp
	{
		static void Main( string[] args )
		{
			Task02_MinElementInArray();
		}

		//works 100%
		private static void Task05_SearchForElement()
		{
			var a = Console.ReadLine()
				.Split( new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();

			Array.Sort( a );

			var n = a.Length;

			var e = int.Parse( Console.ReadLine() );

			var result = new SearchForElement().Find( a, n, e );

			Console.WriteLine( result );
		}

		//works 100%
		private static void Task04_Palindrome()
		{
			var a = Console.ReadLine()
				.Split( new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();

			var n = a.Length;

			var result = new Palindrome().Check( a, n );

			Console.WriteLine( result );
		}

		//works 100%
		private static void Task03_SumOfArray()
		{
			var a = Console.ReadLine()
				.Split( new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();

			var n = a.Length;

			var result = new SumOfArray().Calculate( a, n );

			Console.WriteLine( result );
		}

		//works 0%
		private static void Task02_MinElementInArray()
		{
			var a = Console.ReadLine()
				.Split( new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries )
				.Select( int.Parse )
				.ToArray();

			var n = a.Length;

			var result = new MinElementInArray().Find( a, n );

			Console.WriteLine( result );
		}

		//works 100%
		private static void Task01_SumOfN()
		{
			var n = int.Parse( Console.ReadLine() );

			var result = new SumOfN().Calculate( n );

			Console.WriteLine( result );
		}
	}
}