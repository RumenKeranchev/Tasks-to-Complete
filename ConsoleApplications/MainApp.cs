using System;

namespace ConsoleApplications
{
	class MainApp
	{
		static void Main( string[] args )
		{
			var result = Task01_Solution.Solution( 5, new[] { 1, 2, 3 } );

			Console.WriteLine( string.Join( ", ", result ) );
		}
	}
}