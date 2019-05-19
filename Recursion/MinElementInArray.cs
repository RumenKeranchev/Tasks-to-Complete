namespace Recursion
{
	public class MinElementInArray
	{
		public int Find( int[] a, int n )
		{
			if ( n < 1 )
			{
				return a[ n ];
			}

			var b = a[ n - 1 ];

			if ( this.Find( a, n - 1 ) < b )
			{
				return this.Find( a, n - 1 );
			}
			else
			{
				return a[ n - 1 ];
			}
		}
	}
}