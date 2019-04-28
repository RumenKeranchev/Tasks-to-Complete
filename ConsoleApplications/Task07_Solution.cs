using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplications
{
	public static class Task07_Solution
	{
		public static int[] Solution( int[] a )
		{
			ValidateInput( a );

			var result = new int[ a.Length ];

			for ( var i = 0; i < a.Length; i++ )
			{
				var restOfNums = new List<int>( a );
				restOfNums.Remove( a[ i ] );

				int count = 0;

				foreach ( var num in restOfNums )
				{
					if ( a[ i ] % num != 0 )
					{
						count++;
					}
				}

				result[ i ] = count;
			}

			return result;
		}

		private static void ValidateInput( int[] a )
		{
			if ( a.Length < 1 || a.Length > 50000 )
			{
				throw new ArgumentException( "Invalid Input!" );
			}

			if ( a.Any( x => x < 1 || x > a.Length * 2 ) )
			{
				throw new ArgumentException( "Invalid Input!" );
			}
		}
	}
}