using System;

namespace Recursion
{
	public class SearchForElement
	{
		private int min = 0;

		private int mid;

		public int Find( int[] a, int n, int e )
		{
			this.mid = Convert.ToInt32( Math.Floor( ( this.min + ( decimal ) n ) / 2 ) );
			

			if ( a[ this.mid ] != e )
			{
				if ( a[ this.mid ] < e )
				{
					this.min = this.mid + 1;
				}
				else
				{
					n = this.mid - 1;
				}

				this.Find( a, n, e );
			}
			return this.mid;
		}
	}
}