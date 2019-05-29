using System;
using System.Collections.Generic;
using Battlefield.Constants;
using Battlefield.Entities;
using Battlefield.Entities.Army;

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
		}

		//TODO: Add PVP methods:
		private void PVP()
		{
		}

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
			var continueShopping = int.Parse(Console.ReadKey().KeyChar.ToString());
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

		private void Buy( BaseCamp camp, int quantity, Type className )
		{
			for ( int i = 0 ; i < quantity ; i++ )
			{
				var a = Activator.CreateInstance( className );
				camp.PurchaseUnit( ( ArmyUnit ) a );
			}

			Console.WriteLine( $"{quantity} {className.Name} units successfully purchased!" );
		}
	}
}