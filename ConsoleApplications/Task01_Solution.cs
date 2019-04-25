using System.Linq;

namespace ConsoleApplications
{
	public static class Task01_Solution
	{
		public static int[] Solution( int n, int[] a )
		{
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
	}
}