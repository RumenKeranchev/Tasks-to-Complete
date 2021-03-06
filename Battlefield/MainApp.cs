﻿using System;
using System.Collections.Generic;
using System.Linq;
using Battlefield.Entities;
using Battlefield.Entities.Army;

namespace Battlefield
{
	class MainApp
	{
		static void Main( string[] args )
		{
			var battle = Battle.GetInstance();
			battle.StartBattle();

			//TODO: Add a "coin flip to determine which player has first move"

			//BUG: when the quantity was firstly invalid, the next call even if correct doesnt recognize the input
		}

		/// <summary>
		/// Initializes the Calculator class and uses all available methods
		/// </summary>
		private static void Calculator()
		{
			var a = new CalculateDamage();
//			a.CalculateAll();
			Console.WriteLine( "\r\nStatistics for all units have been calculated!\r\n" );
//			a.CalculateFromConstants();
//			a.CalculateWithUserInput();
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
				camp.PurchaseUnit( new Airplane() );
			}

			for ( int i = 0 ; i < 25 ; i++ )
			{
				camp.PurchaseUnit( new Artillery() );
			}

			Console.Write( $"{camp.Army.Count()} units available.\n" );

			Console.WriteLine( "Is the camp attackable currently: {0}", camp.CanTakeDamage() ? "Yes" : "No" );
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
					$"With health: {unit.Health}, defense: {unit.Defense} with attack power of: {unit.AttackPower} and range of: {unit.Range}." );

				Console.WriteLine( new string( '-', 74 ) );
				Console.WriteLine();
			}

			return units;
		}
	}
}