namespace Recursion
{
	public class SumOfN
	{
		private int counter;

		public SumOfN()
		{
			this.counter = 1;
		}

		public int Calculate( int n )
		{
			int sum = this.counter;

			if ( this.counter < n )
			{
				this.counter++;
				return sum += this.Calculate( n );
			}

			return sum;
		}
	}
}