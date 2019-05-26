using System;
using System.IO;
using System.Text;
using Battlefield.Constants;

namespace Battlefield
{
	public class CalculateDamage
	{
		#region Variables

		private int minHealth;

		private int maxHealth;

		private int minDefense;

		private int maxDefense;

		private int minAttack;

		private int maxAttack;

		private int minRange;

		private int maxRange;

		private int winPercent;

		private int attackedMinDefense;

		private int attackedMaxDefense;

		private int attackedMinRange;

		private int attackedMaxRange;

		private int attackedMinHealth;

		private int attackedMaxHealth;

		private StringBuilder sb = new StringBuilder();

		private string unit;

		private string attackedUnit;

		private string dashes = new string( '-', 120 );

		private double mrmor;

		private double MRmor;

		private double mrMOR;

		private double MRMOR;

		private int attackedMinAttack;

		private int attackedMaxAttack;

		#endregion

		/// <summary>
		/// Calculate the possible damage between two units with user given stats
		/// </summary>
		public void CalculateWithUserInput()
		{
			this.ReadUnitsNames();

			this.sb.AppendLine( this.dashes );

			this.ReadFirstUnitStatsFromUserInput();

			Console.WriteLine();

			this.ReadSecondUnitStatsFromUserInput();

			this.AddUnitsStatsToStringBuilder();

			#region Abbreviations

			// Min Attack = ma, Min Defense = md, Min Range = mr, Min Opponent Range = mor
			// Max Attack = MA, Max Defense = MD, Max Range = MR, Max Opponent Range = MOR
			// unit's attack  - target's defense -/+ (unit's attack * +/- (double)(unit's range - target's range) / 100) 

			#endregion

			this.CalculateRangeDifferense();

			this.winPercent = this.CalculatePossibleDamage();

			this.CalculateWinRation();

			this.SaveToFile();
		}

		/// <summary>
		/// Calculates the possible damage between two units using the defaults
		/// </summary>
		public void CalculateFromConstants()
		{
			this.ReadUnitsNames();

			this.UnitToCompare();

			this.UnitToComareWith();

			this.sb.AppendLine( this.dashes );

			this.AddUnitsStatsToStringBuilder();

			this.CalculateRangeDifferense();

			this.winPercent = this.CalculatePossibleDamage();

			this.CalculateWinRation();

			this.SaveToFile();
		}

		private void CalculateWinRation()
		{
			this.sb.AppendLine();

			this.sb.AppendLine(
				$"\t{this.unit} has {( ( double ) this.winPercent / 16 ) * 100}% win ration agains {this.attackedUnit}." );

			this.sb.AppendLine( this.dashes );
		}

		private void UnitToComareWith()
		{
			switch ( this.attackedUnit )
			{
				case "Artillery" :
					this.attackedMinAttack = ArtilleryContstants.minAttackPower;
					this.attackedMaxAttack = ArtilleryContstants.maxAttackPower;
					this.attackedMinDefense = ArtilleryContstants.minDefense;
					this.attackedMaxDefense = ArtilleryContstants.maxDefense;
					this.attackedMinRange = ArtilleryContstants.minAttackRange;
					this.attackedMaxRange = ArtilleryContstants.maxAttackRange;
					this.attackedMinHealth = ArtilleryContstants.minHealth;
					this.attackedMaxHealth = ArtilleryContstants.maxHealth;

					break;

				case "Airplane" :
					this.attackedMinAttack = AirplaneConstants.minAttackPower;
					this.attackedMaxAttack = AirplaneConstants.maxAttackPower;
					this.attackedMinDefense = AirplaneConstants.minDefense;
					this.attackedMaxDefense = AirplaneConstants.maxDefense;
					this.attackedMinRange = AirplaneConstants.minAttackRange;
					this.attackedMaxRange = AirplaneConstants.maxAttackRange;
					this.attackedMinHealth = AirplaneConstants.minHealth;
					this.attackedMaxHealth = AirplaneConstants.maxHealth;

					break;

				case "Infantry" :
					this.attackedMinAttack = InfantryConstants.minAttackPower;
					this.attackedMaxAttack = InfantryConstants.maxAttackPower;
					this.attackedMinDefense = InfantryConstants.minDefense;
					this.attackedMaxDefense = InfantryConstants.maxDefense;
					this.attackedMinRange = InfantryConstants.minAttackRange;
					this.attackedMaxRange = InfantryConstants.maxAttackRange;
					this.attackedMinHealth = InfantryConstants.minHealth;
					this.attackedMaxHealth = InfantryConstants.maxHealth;

					break;

				case "Tank" :
					this.attackedMinAttack = TankConstants.minAttackPower;
					this.attackedMaxAttack = TankConstants.maxAttackPower;
					this.attackedMinDefense = TankConstants.minDefense;
					this.attackedMaxDefense = TankConstants.maxDefense;
					this.attackedMinRange = TankConstants.minAttackRange;
					this.attackedMaxRange = TankConstants.maxAttackRange;
					this.attackedMinHealth = TankConstants.minHealth;
					this.attackedMaxHealth = TankConstants.maxHealth;

					break;
			}
		}

		private void UnitToCompare()
		{
			switch ( this.unit )
			{
				case "Artillery" :
					this.minAttack = ArtilleryContstants.minAttackPower;
					this.maxAttack = ArtilleryContstants.maxAttackPower;
					this.minDefense = ArtilleryContstants.minDefense;
					this.maxDefense = ArtilleryContstants.maxDefense;
					this.minRange = ArtilleryContstants.minAttackRange;
					this.maxRange = ArtilleryContstants.maxAttackRange;
					this.minHealth = ArtilleryContstants.minHealth;
					this.maxHealth = ArtilleryContstants.maxHealth;

					break;

				case "Airplane" :
					this.minAttack = AirplaneConstants.minAttackPower;
					this.maxAttack = AirplaneConstants.maxAttackPower;
					this.minDefense = AirplaneConstants.minDefense;
					this.maxDefense = AirplaneConstants.maxDefense;
					this.minRange = AirplaneConstants.minAttackRange;
					this.maxRange = AirplaneConstants.maxAttackRange;
					this.minHealth = ArtilleryContstants.minHealth;
					this.maxHealth = ArtilleryContstants.maxHealth;

					break;

				case "Infantry" :
					this.minAttack = InfantryConstants.minAttackPower;
					this.maxAttack = InfantryConstants.maxAttackPower;
					this.minDefense = InfantryConstants.minDefense;
					this.maxDefense = InfantryConstants.maxDefense;
					this.minRange = InfantryConstants.minAttackRange;
					this.maxRange = InfantryConstants.maxAttackRange;
					this.minHealth = ArtilleryContstants.minHealth;
					this.maxHealth = ArtilleryContstants.maxHealth;

					break;

				case "Tank" :
					this.minAttack = TankConstants.minAttackPower;
					this.maxAttack = TankConstants.maxAttackPower;
					this.minDefense = TankConstants.minDefense;
					this.maxDefense = TankConstants.maxDefense;
					this.minRange = TankConstants.minAttackRange;
					this.maxRange = TankConstants.maxAttackRange;
					this.minHealth = ArtilleryContstants.minHealth;
					this.maxHealth = ArtilleryContstants.maxHealth;

					break;
			}
		}

		private void AddUnitsStatsToStringBuilder()
		{
			this.sb.AppendLine(
				$"\t{this.unit} has the following stats: {this.minHealth} - {this.maxHealth} health, {this.minDefense} - {this.maxDefense} defense, " +
				$"{this.minRange} - {this.maxRange} range, {this.minAttack} - {this.maxAttack} attack power" );

			this.sb.AppendLine(
				$"\t{this.attackedUnit} has the following stats: {this.attackedMinHealth} - {this.attackedMaxHealth} health, {this.attackedMinDefense} - {this.attackedMaxDefense} defense, " +
				$"{this.attackedMinRange} - {this.attackedMaxRange} range, {this.attackedMinAttack} - {this.attackedMaxAttack} attack power" );
		}

		private void SaveToFile()
		{
			File.WriteAllText( "..\\..\\..\\" + "\\statistics.txt", this.sb.ToString() );
		}

		private void ReadUnitsNames()
		{
			Console.Write( "Enter which unit you wish to calculate the attack power of and the unit its attacking: " );
			var input = Console.ReadLine();

			var data = input.Split( new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries );
			this.unit = data[ 0 ];
			this.attackedUnit = data[ 1 ];
		}

		private void ReadFirstUnitStatsFromUserInput()
		{
			Console.WriteLine();
			Console.WriteLine( $"Enter {this.unit}'s statistics: " );
			Console.Write( "\tHealth Min and Max values: " );
			var unitHealth = Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );
			this.minHealth = int.Parse( unitHealth[ 0 ] );
			this.maxHealth = int.Parse( unitHealth[ 1 ] );
			Console.Write( "\tDefense Min and Max values: " );
			var unitDefense = Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );
			this.minDefense = int.Parse( unitDefense[ 0 ] );
			this.maxDefense = int.Parse( unitDefense[ 1 ] );
			Console.Write( "\tAttack Power Min and Max values: " );
			var unitAttack = Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );
			this.minAttack = int.Parse( unitAttack[ 0 ] );
			this.maxAttack = int.Parse( unitAttack[ 1 ] );
			Console.Write( "\tRange Min and Max values: " );
			var unitRange = Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );
			this.minRange = int.Parse( unitRange[ 0 ] );
			this.maxRange = int.Parse( unitRange[ 1 ] );
		}

		private void ReadSecondUnitStatsFromUserInput()
		{
			Console.WriteLine( $"Enter {this.attackedUnit}'s statistics: " );
			Console.Write( "\tHealth Min and Max values: " );

			var attackedUnitHealth =
				Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );

			this.attackedMinHealth = int.Parse( attackedUnitHealth[ 0 ] );
			this.attackedMaxHealth = int.Parse( attackedUnitHealth[ 1 ] );

			Console.Write( "\tDefense Min and Max values: " );

			var attackedUnitDefense =
				Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );

			this.attackedMinDefense = int.Parse( attackedUnitDefense[ 0 ] );
			this.attackedMaxDefense = int.Parse( attackedUnitDefense[ 1 ] );
			Console.Write( "\tAttack Power Min and Max values: " );

			var attackedUnitAttack =
				Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );

			this.attackedMinAttack = int.Parse( attackedUnitAttack[ 0 ] );
			this.attackedMaxAttack = int.Parse( attackedUnitAttack[ 1 ] );

			Console.Write( "\tRange Min and Max values: " );
			var attackedUnitRange = Console.ReadLine().Split( new[] { " ", ", ", "-" }, StringSplitOptions.RemoveEmptyEntries );
			this.attackedMinRange = int.Parse( attackedUnitRange[ 0 ] );
			this.attackedMaxRange = int.Parse( attackedUnitRange[ 1 ] );
		}

		private void CalculateRangeDifferense()
		{
			this.mrmor = ( double ) ( this.minRange - this.attackedMinRange ) / 100;
			this.MRmor = ( double ) ( this.maxRange - this.attackedMinRange ) / 100;
			this.mrMOR = ( double ) ( this.minRange - this.attackedMaxRange ) / 100;
			this.MRMOR = ( double ) ( this.maxRange - this.attackedMaxRange ) / 100;
		}

		private int CalculatePossibleDamage()
		{
			var mamdmrmor = Convert.ToInt32( this.mrmor > 0
				? Math.Round( this.minAttack - this.attackedMinDefense - ( this.minAttack * this.mrmor ) )
				: Math.Round( this.minAttack - this.attackedMinDefense + ( this.minAttack * this.mrmor ) ) );

			this.winPercent += mamdmrmor > 0 ? 1 : 0;

			this.sb.AppendLine();

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and min range, {this.attackedUnit} having  min range and min defense deals   {mamdmrmor} damage." );

			var MAmdmrmor = Convert.ToInt32( this.mrmor > 0
				? Math.Round( this.maxAttack - this.attackedMinDefense - ( this.maxAttack * this.mrmor ) )
				: Math.Round( this.maxAttack - this.attackedMinDefense + ( this.maxAttack * this.mrmor ) ) );

			this.winPercent += MAmdmrmor > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and min range, {this.attackedUnit} having  min range and min defense deals   {MAmdmrmor} damage." );

			var maMDmrmor = Convert.ToInt32( this.mrmor > 0
				? Math.Round( this.minAttack - this.attackedMaxDefense - ( this.minAttack * this.mrmor ) )
				: Math.Round( this.minAttack - this.attackedMaxDefense + ( this.minAttack * this.mrmor ) ) );

			this.winPercent += maMDmrmor > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and min range, {this.attackedUnit} having  min range and MAX defense deals   {maMDmrmor} damage." );

			var mamdMRmor = Convert.ToInt32( this.MRmor > 0
				? Math.Round( this.minAttack - this.attackedMinDefense - ( this.minAttack * this.MRmor ) )
				: Math.Round( this.minAttack - this.attackedMinDefense + ( this.minAttack * this.MRmor ) ) );

			this.winPercent += mamdMRmor > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and MAX range, {this.attackedUnit} having  min range and MAX defense deals   {mamdMRmor} damage." );

			var mamdmrMOR = Convert.ToInt32( this.mrMOR > 0
				? Math.Round( this.minAttack - this.attackedMinDefense - ( this.minAttack * this.mrMOR ) )
				: Math.Round( this.minAttack - this.attackedMinDefense + ( this.minAttack * this.mrMOR ) ) );

			this.winPercent += mamdmrMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and min range, {this.attackedUnit} having  MAX range and min defense deals   {mamdmrMOR} damage." );

			var MAMDmrmor = Convert.ToInt32( this.mrmor > 0
				? Math.Round( this.maxAttack - this.attackedMaxDefense - ( this.maxAttack * this.mrmor ) )
				: Math.Round( this.maxAttack - this.attackedMaxDefense + ( this.maxAttack * this.mrmor ) ) );

			this.winPercent += MAMDmrmor > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and min range, {this.attackedUnit} having  min range and MAX defense deals   {MAMDmrmor} damage." );

			var MAmdMRmor = Convert.ToInt32( this.MRmor > 0
				? Math.Round( this.maxAttack - this.attackedMinDefense - ( this.maxAttack * this.MRmor ) )
				: Math.Round( this.maxAttack - this.attackedMinDefense + ( this.maxAttack * this.MRmor ) ) );

			this.winPercent += MAmdMRmor > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and MAX range, {this.attackedUnit} having  min range and min defense deals   {MAmdMRmor} damage." );

			var MAmdmrMOR = Convert.ToInt32( this.mrMOR > 0
				? Math.Round( this.maxAttack - this.attackedMinDefense - ( this.maxAttack * this.mrMOR ) )
				: Math.Round( this.maxAttack - this.attackedMinDefense + ( this.maxAttack * this.mrMOR ) ) );

			this.winPercent += MAmdmrMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and min range, {this.attackedUnit} having  MAX range and min defense deals   {MAmdmrMOR} damage." );

			var maMDMRmor = Convert.ToInt32( this.MRmor > 0
				? Math.Round( this.minAttack - this.attackedMaxDefense - ( this.minAttack * this.MRmor ) )
				: Math.Round( this.minAttack - this.attackedMaxDefense + ( this.minAttack * this.MRmor ) ) );

			this.winPercent += maMDMRmor > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and MAX range, {this.attackedUnit} having  min range and MAX defense deals   {maMDMRmor} damage." );

			var maMDmrMOR = Convert.ToInt32( this.mrMOR > 0
				? Math.Round( this.minAttack - this.attackedMaxDefense - ( this.minAttack * this.mrMOR ) )
				: Math.Round( this.minAttack - this.attackedMaxDefense + ( this.minAttack * this.mrMOR ) ) );

			this.winPercent += maMDmrMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and min range, {this.attackedUnit} having  MAX range and MAX defense deals   {maMDmrMOR} damage." );

			var mamdMRMOR = Convert.ToInt32( this.MRMOR > 0
				? Math.Round( this.minAttack - this.attackedMinDefense - ( this.minAttack * this.MRMOR ) )
				: Math.Round( this.minAttack - this.attackedMinDefense + ( this.minAttack * this.MRMOR ) ) );

			this.winPercent += mamdMRMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and MAX range, {this.attackedUnit} having  MAX range and min defense deals   {mamdMRMOR} damage." );

			var MAMDMRmor = Convert.ToInt32( this.MRmor > 0
				? Math.Round( this.maxAttack - this.attackedMaxDefense - ( this.maxAttack * this.MRmor ) )
				: Math.Round( this.maxAttack - this.attackedMaxDefense + ( this.maxAttack * this.MRmor ) ) );

			this.winPercent += MAMDMRmor > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and MAX range, {this.attackedUnit} having  min range and MAX defense deals   {MAMDMRmor} damage." );

			var MAMDmrMOR = Convert.ToInt32( this.mrMOR > 0
				? Math.Round( this.maxAttack - this.attackedMaxDefense - ( this.maxAttack * this.mrMOR ) )
				: Math.Round( this.maxAttack - this.attackedMaxDefense + ( this.maxAttack * this.mrMOR ) ) );

			this.winPercent += MAMDmrMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and min range, {this.attackedUnit} having  MAX range and MAX defense deals   {MAMDmrMOR} damage." );

			var MAmdMRMOR = Convert.ToInt32( this.MRMOR > 0
				? Math.Round( this.maxAttack - this.attackedMinDefense - ( this.maxAttack * this.MRMOR ) )
				: Math.Round( this.maxAttack - this.attackedMinDefense + ( this.maxAttack * this.MRMOR ) ) );

			this.winPercent += MAmdMRMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and MAX range, {this.attackedUnit} having  MAX range and min defense deals   {MAmdMRMOR} damage." );

			var maMDMRMOR = Convert.ToInt32( this.MRMOR > 0
				? Math.Round( this.minAttack - this.attackedMaxDefense - ( this.minAttack * this.MRMOR ) )
				: Math.Round( this.minAttack - this.attackedMaxDefense + ( this.minAttack * this.MRMOR ) ) );

			this.winPercent += maMDMRMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with min attack power and MAX range, {this.attackedUnit} having  MAX range and MAX defense deals   {maMDMRMOR} damage." );

			var MAMDMRMOR = Convert.ToInt32( this.MRMOR > 0
				? Math.Round( this.maxAttack - this.attackedMaxDefense - ( this.maxAttack * this.MRMOR ) )
				: Math.Round( this.maxAttack - this.attackedMaxDefense + ( this.maxAttack * this.MRMOR ) ) );

			this.winPercent += MAMDMRMOR > 0 ? 1 : 0;

			this.sb.AppendLine(
				$"\t\tAttacking with MAX attack power and MAX range, {this.attackedUnit} having  MAX range and MAX defense deals   {MAMDMRMOR} damage." );

			return this.winPercent;
		}
	}
}