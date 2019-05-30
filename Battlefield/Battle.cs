using Battlefield.Constants;
using Battlefield.Entities;
using Battlefield.Entities.Army;
using System;
using System.Linq;

namespace Battlefield
{
	public class Battle
	{
		#region Variables

		private static Battle instance;

		private string dashes = new string( '-', 74 );

		private int playerChoice;

		private BaseCamp player1;

		private BaseCamp player2;

		private bool gameOver = false;

		#endregion

		private Battle()
		{
			this.player1 = new BaseCamp();
			this.player2 = new BaseCamp();
		}

		public static Battle GetInstance()
		{
			if ( instance == null )
			{
				instance = new Battle();
			}

			return instance;
		}

		public void StartBattle()
		{
			this.WelcomeMessage();
			this.PlayerChoice();
			this.GameMode();
		}

		private void WelcomeMessage()
		{
			Console.WriteLine( this.dashes );
			Console.WriteLine( "\t\t\tWelcome to Battlefield!\t\t\t\r\n" );
			Console.WriteLine( "     To begin please select versus whom to play: (1)Player or (2)PC" );
			Console.WriteLine( this.dashes );
		}

		private void PlayerChoice()
		{
			Console.Write( "Enter your choice here: " );
			var input = int.Parse( Console.ReadKey().KeyChar.ToString() );
			Console.WriteLine();

			if ( input != 1 && input != 2 )
			{
				Console.WriteLine( "Invalid choice! Please select one of the options." );
				this.PlayerChoice();
			}

			this.playerChoice = input;
		}

		private void GameMode()
		{
			if ( this.playerChoice == 1 )
			{
				this.PVP();
			}

			if ( this.playerChoice == 2 )
			{
				this.PVE();
			}
		}

		//TODO: Add PVE methods
		private void PVE()
		{
			Console.WriteLine( $"The Player can access the shop now! You currently have {this.player1.Resources} bfc." );
			this.Shop( this.player1 );
			this.GeneratePVEArmy();

			while ( !this.gameOver )
			{
				this.Attack( this.player1, this.player2 );
			}
		}

		//TODO: Add PVP methods:
		private void PVP()
		{
		}

		private void Attack( BaseCamp p1, BaseCamp p2, string attacker = "AI" )
		{
			var ready = this.Ready( p1 );
			var aim = this.Aim( p2, attacker );
			this.Fire( p1, p2, ready, aim );
		}

		private void IsGameOver()
		{
			if ( this.player1.Health <= 0 )
			{
				this.gameOver = true;
			}
			else if ( this.player2.Health <= 0 )
			{
				this.gameOver = true;
			}
		}

		/// <summary>
		/// Attack the selected enemy unit.
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="unit"></param>
		/// <param name="attackedUnit"></param>
		private void Fire( BaseCamp p1, BaseCamp p2, ArmyUnit unit, ArmyUnit attackedUnit )
		{
			var attackedUnitHealth = attackedUnit.Health;
			var damageDealt = unit.Attack( attackedUnit );
			int remainingDamage = 0;

			if ( attackedUnitHealth - damageDealt < 0 )
			{
				remainingDamage = Math.Abs( attackedUnitHealth - damageDealt );
			}

			Console.Write(
				$"{unit.GetType().Name}#{unit.Id} did {damageDealt} damage to {attackedUnit.GetType().Name}#{attackedUnit.Id}" );

			if ( attackedUnit.IsAlive() )
			{
				Console.WriteLine( $" which has {attackedUnit.Health} health left after the attack." );
			}
			else
			{
				p1.RemoveFromArmy( attackedUnit );
				Console.WriteLine( " and killed it." );
			}

			if ( p2.CanTakeDamage() )
			{
				Console.WriteLine( $"The enemy's army numbers are dwindeling! His Base took {remainingDamage} damage!" );
				p2.TakeDamage( remainingDamage );
			}

			this.IsGameOver();
		}

		/// <summary>
		/// Return the target enemy unit by ID
		/// </summary>
		/// <param name="p2"></param>
		/// <param name="attacker"></param>
		/// <returns></returns>
		private ArmyUnit Aim( BaseCamp p2, string attacker )
		{
			var airplanes = p2.Army.Where( a => a.GetType() == typeof( Airplane ) ).ToList().Count;
			var artillery = p2.Army.Where( a => a.GetType() == typeof( Artillery ) ).ToList().Count;
			var infantry = p2.Army.Where( a => a.GetType() == typeof( Infantry ) ).ToList().Count;
			var tanks = p2.Army.Where( a => a.GetType() == typeof( Tank ) ).ToList().Count;
			ArmyUnit selectedUnit = null;

			Console.WriteLine(
				$"{attacker} has {airplanes} Airplanes, {artillery} Artilleries, {infantry} Infantries and {tanks} Tanks" );

			Console.WriteLine(
				$"Show more details about which unit devision: (1){nameof( Airplane )} (2){nameof( Artillery )} (3){nameof( Infantry )} (4){nameof( Tank )}" );

			var choice = int.Parse( Console.ReadKey().KeyChar.ToString() );
			Console.WriteLine();

			switch ( choice )
			{
				case 1 :

					selectedUnit = this.GetAttackedUnit( p2, typeof( Airplane ) );

					break;

				case 2 :

					selectedUnit = this.GetAttackedUnit( p2, typeof( Artillery ) );

					break;

				case 3 :

					selectedUnit = this.GetAttackedUnit( p2, typeof( Infantry ) );

					break;

				case 4 :

					selectedUnit = this.GetAttackedUnit( p2, typeof( Tank ) );

					break;

				default :
					Console.WriteLine( "Please select one of the provided options!" );
					this.Aim( p2, attacker );

					break;
			}

			return selectedUnit;
		}

		/// <summary>
		/// Return the selected unit with which the player wants attack
		/// </summary>
		/// <param name="p1"></param>
		/// <returns></returns>
		private ArmyUnit Ready( BaseCamp p1 )
		{
			Console.WriteLine(
				$"Select a unit: (1){nameof( Airplane )}, (2){nameof( Artillery )}, (3){nameof( Infantry )}, (4){nameof( Tank )} " );

			var choice = int.Parse( Console.ReadKey().KeyChar.ToString() );
			Console.WriteLine();

			ArmyUnit selectedUnit = null;
			int input;

			switch ( choice )
			{
				case 1 :
					selectedUnit = this.GetSelectedUnit( p1, typeof( Airplane ) );

					break;

				case 2 :

					selectedUnit = this.GetSelectedUnit( p1, typeof( Artillery ) );

					break;

				case 3 :

					selectedUnit = this.GetSelectedUnit( p1, typeof( Infantry ) );

					break;

				case 4 :

					selectedUnit = this.GetSelectedUnit( p1, typeof( Tank ) );

					break;

				default :
					Console.WriteLine( "Please select one of the provided options!" );
					this.Ready( p1 );

					break;
			}

			return selectedUnit;
		}

		/// <summary>
		/// Iterates over the players army by given type, returns the attacked unit by ID
		/// </summary>
		/// <param name="p2"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		private ArmyUnit GetAttackedUnit( BaseCamp p2, Type type )
		{
			ArmyUnit selectedUnit;
			var units = p2.Army.Where( u => u.GetType() == type ).ToList();

			foreach ( var unit in units )
			{
				Console.WriteLine( $"Unit #{unit.Id} has {unit.Health} health, {unit.Defense} defense and {unit.Range} range" );
			}

			Console.Write( "Choose a unit: " );
			var unitId = int.Parse( Console.ReadLine() );
			Console.WriteLine();

			selectedUnit = units.FirstOrDefault( u => u.Id == unitId );

			return selectedUnit;
		}

		/// <summary>
		/// Iterates over the players army by given type, returns the selected unit by ID
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		private ArmyUnit GetSelectedUnit( BaseCamp p1, Type type )
		{
			ArmyUnit selectedUnit;
			var units = p1.Army.Where( u => u.GetType() == type ).ToList();

			foreach ( var unit in units )
			{
				Console.WriteLine(
					$"Unit #{unit.Id} has {unit.Health} health, {unit.AttackPower} attack power and {unit.Range} range" );
			}

			Console.Write( "Choose a unit: " );
			var unitId = int.Parse( Console.ReadLine() );
			Console.WriteLine();

			selectedUnit = units.FirstOrDefault( u => u.Id == unitId );

			return selectedUnit;
		}

		/// <summary>
		/// Generate the AI's army
		/// </summary>
		private void GeneratePVEArmy()
		{
			for ( int i = 0 ; i < 4 ; i++ )
			{
				this.player2.PurchaseUnit( new Airplane() );
			}

			for ( int i = 0 ; i < 4 ; i++ )
			{
				this.player2.PurchaseUnit( new Artillery() );
			}

			for ( int i = 0 ; i < 8 ; i++ )
			{
				this.player2.PurchaseUnit( new Infantry() );
			}

			for ( int i = 0 ; i < 3 ; i++ )
			{
				this.player2.PurchaseUnit( new Tank() );
			}
		}

		/// <summary>
		/// Display the shop, presenting the available units to purchase and probides the option to buy them.
		/// </summary>
		/// <param name="camp"></param>
		private void Shop( BaseCamp camp )
		{
			Console.WriteLine(
				$"Please select which units do you wish to have in your army: \r\n(1){nameof( Airplane )}, (2){nameof( Artillery )}, (3){nameof( Infantry )}, (4){nameof( Tank )}" );

			var unitChoice = int.Parse( Console.ReadKey().KeyChar.ToString() );
			int continuePurchase;
			Console.WriteLine();
			Console.Write( "You have selected " );

			switch ( unitChoice )
			{
				#region case 1

				case 1 :
					Console.WriteLine( nameof( Airplane ) + "." );
					Console.WriteLine( $"\t{nameof( Airplane )} has the following statistics:" );
					Console.WriteLine( $"\t  Health: {AirplaneConstants.minHealth}-{AirplaneConstants.maxHealth} pts" );
					Console.WriteLine( $"\t  Defense: {AirplaneConstants.minDefense}-{AirplaneConstants.maxDefense} pts" );
					Console.WriteLine( $"\t  Attack: {AirplaneConstants.minAttackPower}-{AirplaneConstants.maxAttackPower} pts" );
					Console.WriteLine( $"\t  Range: {AirplaneConstants.minAttackRange}-{AirplaneConstants.maxAttackRange} pts" );
					Console.WriteLine( $"\t  Cost: {AirplaneConstants.Cost} bfc" );
					Console.WriteLine( "Would you like to purchase this unit? (1)Yes, (2)No" );
					continuePurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
					Console.WriteLine();

					if ( continuePurchase == 1 )
					{
						Console.WriteLine( "How many would you want? " );
						var quantity = int.Parse( Console.ReadLine() );
						var sum = quantity * AirplaneConstants.Cost;

						if ( sum <= camp.Resources )
						{
							Console.WriteLine( "Confirm purchase:  (1)Yes (2)No" );
							var confirmPurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
							Console.WriteLine();

							if ( confirmPurchase == 1 )
							{
								this.Buy( camp, quantity, typeof( Airplane ) );
							}
							else
							{
								this.Shop( camp );
							}
						}
						else
						{
							Console.WriteLine( "Invalid funds!" );
							this.Shop( camp );
						}
					}
					else
					{
						this.Shop( camp );
					}

					break;

				#endregion

				#region case 2

				case 2 :
					Console.WriteLine( nameof( Artillery ) + "." );
					Console.WriteLine( $"\t{nameof( Artillery )} has the following statistics:" );
					Console.WriteLine( $"\t  Health: {ArtilleryConstants.minHealth}-{ArtilleryConstants.maxHealth} pts" );
					Console.WriteLine( $"\t  Defense: {ArtilleryConstants.minDefense}-{ArtilleryConstants.maxDefense} pts" );
					Console.WriteLine( $"\t  Attack: {ArtilleryConstants.minAttackPower}-{ArtilleryConstants.maxAttackPower} pts" );
					Console.WriteLine( $"\t  Range: {ArtilleryConstants.minAttackRange}-{ArtilleryConstants.maxAttackRange} pts" );
					Console.WriteLine( $"\t  Cost: {ArtilleryConstants.Cost} bfc" );
					Console.WriteLine( "Would you like to purchase this unit? (1)Yes, (2)No" );
					continuePurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
					Console.WriteLine();

					if ( continuePurchase == 1 )
					{
						Console.WriteLine( "How many would you want? " );
						var quantity = int.Parse( Console.ReadLine() );
						var sum = quantity * ArtilleryConstants.Cost;

						if ( sum <= camp.Resources )
						{
							Console.WriteLine( "Confirm purchase:  (1)Yes (2)No" );
							var confirmPurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
							Console.WriteLine();

							if ( confirmPurchase == 1 )
							{
								this.Buy( camp, quantity, typeof( Artillery ) );
							}
							else
							{
								this.Shop( camp );
							}
						}
						else
						{
							Console.WriteLine( "Invalid funds!" );
							this.Shop( camp );
						}
					}
					else
					{
						this.Shop( camp );
					}

					break;

				#endregion

				#region case 3

				case 3 :
					Console.WriteLine( nameof( Infantry ) + "." );
					Console.WriteLine( $"\t{nameof( Infantry )} has the following statistics:" );
					Console.WriteLine( $"\t  Health: {InfantryConstants.minHealth}-{InfantryConstants.maxHealth} pts" );
					Console.WriteLine( $"\t  Defense: {InfantryConstants.minDefense}-{InfantryConstants.maxDefense} pts" );
					Console.WriteLine( $"\t  Attack: {InfantryConstants.minAttackPower}-{InfantryConstants.maxAttackPower} pts" );
					Console.WriteLine( $"\t  Range: {InfantryConstants.minAttackRange}-{InfantryConstants.maxAttackRange} pts" );
					Console.WriteLine( $"\t  Cost: {InfantryConstants.Cost} bfc" );
					Console.WriteLine( "Would you like to purchase this unit? (1)Yes, (2)No" );
					continuePurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
					Console.WriteLine();

					if ( continuePurchase == 1 )
					{
						Console.WriteLine( "How many would you want? " );
						var quantity = int.Parse( Console.ReadLine() );
						var sum = quantity * InfantryConstants.Cost;

						if ( sum <= camp.Resources )
						{
							Console.WriteLine( "Confirm purchase:  (1)Yes (2)No" );
							var confirmPurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
							Console.WriteLine();

							if ( confirmPurchase == 1 )
							{
								this.Buy( camp, quantity, typeof( Infantry ) );
							}
							else
							{
								this.Shop( camp );
							}
						}
						else
						{
							Console.WriteLine( "Invalid funds!" );
							this.Shop( camp );
						}
					}
					else
					{
						this.Shop( camp );
					}

					break;

				#endregion

				#region case 4

				case 4 :
					Console.WriteLine( nameof( Tank ) + "." );
					Console.WriteLine( $"\t{nameof( Tank )} has the following statistics:" );
					Console.WriteLine( $"\t  Health: {TankConstants.minHealth}-{TankConstants.maxHealth} pts" );
					Console.WriteLine( $"\t  Defense: {TankConstants.minDefense}-{TankConstants.maxDefense} pts" );
					Console.WriteLine( $"\t  Attack: {TankConstants.minAttackPower}-{TankConstants.maxAttackPower} pts" );
					Console.WriteLine( $"\t  Range: {TankConstants.minAttackRange}-{TankConstants.maxAttackRange} pts" );
					Console.WriteLine( $"\t  Cost: {TankConstants.Cost} bfc" );
					Console.WriteLine( "Would you like to purchase this unit? (1)Yes, (2)No" );
					continuePurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
					Console.WriteLine();

					if ( continuePurchase == 1 )
					{
						Console.WriteLine( "How many would you want? " );
						var quantity = int.Parse( Console.ReadLine() );
						var sum = quantity * TankConstants.Cost;

						if ( sum <= camp.Resources )
						{
							Console.WriteLine( "Confirm purchase:  (1)Yes (2)No" );
							var confirmPurchase = int.Parse( Console.ReadKey().KeyChar.ToString() );
							Console.WriteLine();

							if ( confirmPurchase == 1 )
							{
								this.Buy( camp, quantity, typeof( Tank ) );
							}
							else
							{
								this.Shop( camp );
							}
						}
						else
						{
							Console.WriteLine( "Invalid funds!" );
							this.Shop( camp );
						}
					}
					else
					{
						this.Shop( camp );
					}

					break;

				#endregion
			}

			Console.WriteLine( "Would you like to add more units? (1)Yes  (2)No" );
			var continueShopping = int.Parse( Console.ReadKey().KeyChar.ToString() );
			Console.WriteLine();

			if ( continueShopping == 1 )
			{
				this.Shop( camp );
			}
			else
			{
				Console.WriteLine( "Let the battle begin!" );
			}
		}

		/// <summary>
		/// Purchases the specified quantity of the chosen unit and adds it to the player's army.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="quantity"></param>
		/// <param name="className"></param>
		private void Buy( BaseCamp player, int quantity, Type className )
		{
			for ( int i = 0 ; i < quantity ; i++ )
			{
				var a = Activator.CreateInstance( className );
				player.PurchaseUnit( ( ArmyUnit ) a );
			}

			Console.WriteLine( $"{quantity} {className.Name} units successfully purchased!" );
		}
	}
}