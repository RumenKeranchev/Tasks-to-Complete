using System;
using System.Linq;

namespace ConsoleApplications
{
	public static class Task05_Solution
	{
		public static int Solution( int[] a )
		{
			ValidateInput( a );

			var s = new int[ a.Length ];
			var outArr = new int[ a.Length ];

			for ( int i = 0 ; i < a.Length ; i++ )
			{
				if ( i % 2 == 0 )
				{
					s[ i ] = -1;
				}
				else
				{
					s[ i ] = 1;
				}

				outArr[i] = a[ i ] * s[ i ];
			}

			return outArr.Sum();
		}

		private static void ValidateInput( int[] a )
		{
			if ( a.Length > 20000 )
			{
				throw new ArgumentException( "Invalid Input!" );
			}

			if ( a.Any( x => x < -100 || x > 100 ) )
			{
				throw new ArgumentException( "Invalid Input!" );
			}
		}
	} 
}