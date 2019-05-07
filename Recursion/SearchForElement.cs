using System;

namespace Recursion
{
	public class SearchForElement
	{
		private int mid;

		private int min = 0;

		public int Find( int[] a, int n, int e )
		{
			this.mid = Convert.ToInt32( Math.Floor( ( this.min + ( decimal ) n ) / 2 ) );

			if ( a[ this.mid ] != e )
			{
				if ( a[ this.mid ] < e )
				{
					this.min = this.mid + 1;
				}
				else if ( a[ this.mid ] > e )
				{
					this.min = this.mid - 1;
				}

				this.Find( a, n, e );
			}

			//TODO: doesnt work for an odd array
			return this.mid;
		}
	}
}