using System;
using System.Collections.Generic;
using System.Linq;
using Battlefield.Entities.Army;
using Battlefield.Interfaces;

namespace Battlefield
{
	class MainApp
	{
		static void Main( string[] args )
		{
			List< ArmyUnit > units = new List< ArmyUnit >();
			units.Add( new Airplane() );
			units.Add( new Artilery() );

			foreach ( var unit in units )
			{
				Console.WriteLine( "-----------------------------------------------------------------" );
				Console.WriteLine( $"This is a {unit.GetType().Name} unit." );

				Console.WriteLine($"With health: {unit.GetHealth}, defense: {unit.GetDefense} with attack power of: {unit.GetAttackPower} and range of: {unit.GetAttackRange}." );
				Console.WriteLine( "-----------------------------------------------------------------" );
				Console.WriteLine();
			}

			Console.WriteLine($"Artilery ourranges with {(double)( units.Skip( 1 ).First().GetAttackRange - units.First().GetAttackRange ) / 100}%" );
			Console.WriteLine( Math.Round( 17.94 ) );
		}
	}
}