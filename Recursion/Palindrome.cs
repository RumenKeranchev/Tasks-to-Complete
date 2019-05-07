namespace Recursion
{
	public class Palindrome
	{
		private int counter;

		private int isPalindrome = 1;

		public int Check( int[] a, int n )
		{
			if ( a.Length % 2 != 0 )
			{
				var mid = a.Length / 2 + 1;

				if ( this.counter < mid && n > mid )
				{
					if ( a[ this.counter ] == a[ n - 1 ] && this.counter < mid && n > mid )
					{
						this.counter++;
						n--;
						this.Check( a, n );
					}
					else
					{
						this.isPalindrome = 0;
					}
				}
			}

			if ( a.Length % 2 == 0 )
			{
				int mid = a.Length / 2;

				if ( this.counter < mid && n > mid )
				{
					if ( a[ this.counter ] == a[ n - 1 ] )
					{
						this.counter++;
						n--;
						this.Check( a, n );
					}
					else
					{
						this.isPalindrome = 0;
					}
				}
			}

			return this.isPalindrome;
		}
	}
}