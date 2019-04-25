using System;
using System.Linq;

namespace ConsoleApplications
{
	public static class Task01_Solution
	{
		public static int[] Solution( int n, int[] a )
		{
			ValidateInput( n, a );

			var result = new int[ n ];

			foreach ( var k in a )
			{
				if ( k >= 1 && k <= n )
				{
					result[ k - 1 ]++;
				}

				else if ( k == n + 1 )
				{
					var maxCount = result.Max();

					for ( int i = 0 ; i < n ; i++ )
					{
						result[ i ] = maxCount;
					}
				}
			}

			return result;
		}

		private static void ValidateInput( int n, int[] a )
		{
			if ( n < 1 || n > 100000 )
			{
				throw new ArgumentException( "Invalid input!" );
			}

			if ( a.Length < 1 || a.Length > 100000 )
			{
				throw new ArgumentException( "Invalid input!" );
			}

			if ( Array.Exists( a, arr => arr < 1 || arr > n + 1 ) )
			{
				throw new ArgumentException( "Invalid input!" );
			}
		}
	}
}