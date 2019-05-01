using System;
using System.Linq;

namespace ConsoleApplications
{
	public static class Task03_Solution
	{
		public static int Solution( int[] a )
		{
			if ( a.Length == 0 || a.Length < 3 )
			{
				return 0;
			}

			if ( a.Length > 100000 )
			{
				throw new ArgumentException( "Invalid Input!" );
			}

			Array.Sort( a );

			var triangleExists = 0;

			for ( int i = 0 ; i < a.Length ; i++ )
			{
				var p = 0;
				var q = 0;
				var r = 0;

				if ( i + 2 == a.Length )
				{
					break;
				}

				if ( i + 2 < a.Length )
				{
					p = a[ i ];
					q = a[ i + 1 ];
					r = a[ i + 2 ];
					var isThereATriangle = IsThereATriangle( p, q, r );

					if ( isThereATriangle )
					{
						triangleExists = 1;
					}
				}
			}

			return triangleExists;
		}

		private static bool IsThereATriangle( int p, int q, int r )
		{
			var isTriangle_PQR = false;
			var isTriangle_QRP = false;
			var isTriangle_RPQ = false;

			if ( p + q > r )
			{
				isTriangle_PQR = true;
			}

			if ( q + r > p )
			{
				isTriangle_QRP = true;
			}

			if ( r + q > p )
			{
				isTriangle_RPQ = true;
			}

			if ( isTriangle_PQR && isTriangle_QRP && isTriangle_RPQ )
			{
				return true;
			}

			return false;
		}
	}
}