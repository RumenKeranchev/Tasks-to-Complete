using System;
using System.Collections.Generic;
using System.Linq;
using Battlefield.Entities;
using Battlefield.Entities.Army;
using Battlefield.Interfaces;

namespace Battlefield
{
	class MainApp
	{
		static void Main( string[] args )
		{
			List< ArmyUnit > units = InitialArmy();
			AttacksBetweenTheUnits( units );
			InitializeBaseCamp();
			Calculator();
		}

		/// <summary>
		/// Initializes the Calculator class and uses both available method
		/// </summary>
		private static void Calculator()
		{
			var a = new CalculateDamage();
			a.CalculateFromConstants();
			a.CalculateWithUserInput();
		}

		/// <summary>
		/// Initializes the BaseCamp class,  for loops use the .AddToArmy() to fill the army units, displays the health and
		/// if the base is damageable with the .IsDamageable() method.
		/// </summary>
		private static void InitializeBaseCamp()
		{
			var camp = new BaseCamp();
			Console.WriteLine();
			Console.WriteLine( new string( '-', 74 ) );
			Console.Write( $"The Base Camp has {camp.Health} hp with " );

			for ( int i = 0 ; i < 25 ; i++ )
			{
				camp.AddToArmy( new Airplane() );
			}

			for ( int i = 0 ; i < 25 ; i++ )
			{
				camp.AddToArmy( new Artillery() );
			}

			Console.Write( $"{camp.Army.Count()} units available.\n" );

			Console.WriteLine( "Is the camp attackable currently: {0}", camp.IsDamageable ? "Yes" : "No" );
			Console.WriteLine( new string( '-', 74 ) );
		}

		/// <summary>
		/// Tests the .Attack() method by having 2 units attack eachother and show their health afterwards.
		/// </summary>
		/// <param name="units"></param>
		private static void AttacksBetweenTheUnits( List< ArmyUnit > units )
		{
			var unit1 = units.First();
			var unit2 = units.Skip( 1 ).First();
			unit1.Attack( unit2 );
			unit2.Attack( unit1 );

			Console.WriteLine( new string( '-', 74 ) );

			Console.WriteLine(
				$"{unit1.GetType().Name}'s health after the attack from {unit2.GetType().Name} is {unit1.Health}" );

			Console.WriteLine();

			Console.WriteLine(
				$"{unit2.GetType().Name}'s health after the attack from {unit1.GetType().Name} is {unit2.Health}" );

			Console.WriteLine( new string( '-', 74 ) );
		}

		/// <summary>
		/// Creates an Initial Army to test unit creation and displays their statistics.
		/// </summary>
		/// <returns></returns>
		private static List< ArmyUnit > InitialArmy()
		{
			List< ArmyUnit > units = new List< ArmyUnit >();
			units.Add( new Airplane() );
			units.Add( new Artillery() );

			Console.WriteLine( new string( '-', 31 ) + "Initial Army" + new string( '-', 31 ) );

			foreach ( var unit in units )
			{
				Console.WriteLine( new string( '-', 74 ) );
				Console.WriteLine( $"This is a {unit.GetType().Name} unit." );

				Console.WriteLine(
					$"With health: {unit.Health}, defense: {unit.GetDefense} with attack power of: {unit.GetAttackPower} and range of: {unit.GetAttackRange}." );

				Console.WriteLine( new string( '-', 74 ) );
				Console.WriteLine();
			}

			return units;
		}
	}
}