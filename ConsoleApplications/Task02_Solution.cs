using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplications
{
	public static class Task02_Solution
	{
		public static int[] Solution( string s, int[] p, int[] q )
		{
			ValidateInput( s, p, q );

			var nucleotides = s.ToCharArray();
			var nucleotideSB = new StringBuilder();
			var result = new int[ p.Length ];

			foreach ( var nucleotide in nucleotides )
			{
				switch ( nucleotide )
				{
					case 'A':
						nucleotideSB.Append( 1 );

						break;
					case 'C':
						nucleotideSB.Append( 2 );

						break;
					case 'G':
						nucleotideSB.Append( 3 );

						break;
					case 'T':
						nucleotideSB.Append( 4 );

						break;
				}
			}

			var nucleotideString = nucleotideSB.ToString();

			for ( int i = 0; i < p.Length; i++ )
			{
				if ( p[ i ] == q[ i ] )
				{
					var minValue = nucleotideString.Substring( p[ i ], 1 );

					result[ i ] = Convert.ToInt32( minValue );
				}
				else
				{
					var minValue2 = nucleotideString
						.Substring( p[ i ], nucleotideString.Length - q[ i ] + 1 )
						.ToCharArray()
						.Select( char.GetNumericValue )
						.ToArray()
						.Select( Convert.ToInt32 )
						.Min();

					result[ i ] = minValue2;
				}
			}

			return result;
		}

		private static void ValidateInput( string s, int[] p, int[] q )
		{
			if ( !Regex.IsMatch( s, "^[A,C,G,T]+$" ) )
			{
				throw new ArgumentException( "Invalid Input!" );
			}

			if ( p.Length > q.Length || p.Length < q.Length )
			{
				throw new ArgumentException( "Invalid Input!" );
			}

			if ( p.Length < 1 || p.Length > 50000 )
			{
				throw new ArgumentException( "Invalid Input!" );
			}

			if ( q.Length < 1 || q.Length > 50000 )
			{
				throw new ArgumentException( "Invalid Input!" );
			}
		}
	}
}