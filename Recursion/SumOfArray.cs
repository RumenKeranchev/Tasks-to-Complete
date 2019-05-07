namespace Recursion
{
	public class SumOfArray
	{
		private int counter;

		private int result;

		public int Calculate( int[] a, int n )
		{
			if ( this.counter < n )
			{
				this.result += a[ this.counter ];
				this.counter++;

				this.result = this.Calculate( a, n );
			}

			return this.result;
		}
	}
}