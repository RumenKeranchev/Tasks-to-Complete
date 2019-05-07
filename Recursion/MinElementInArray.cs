namespace Recursion
{
	public class MinElementInArray
	{
		private int counter;

		private int min;

		private int max;

		public int Find( int[] a, int n )
		{
			if ( this.counter < n )
			{
				this.min = a[ this.counter ];
				this.counter++;
				this.max = a[ this.counter ];

				if (this.min > this.max )
				{
					 this.min = this.Find( a, n );
				}
			}
			//TODO: Not wotking ok e.g: 2 1 3 0 -> returns 1 instead of 0 (returns 1st lowest value)
			return this.min;
		}
	}
}