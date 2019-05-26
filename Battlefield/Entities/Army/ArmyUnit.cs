using System;
using System.Runtime.CompilerServices;
using Battlefield.Interfaces;

namespace Battlefield.Entities.Army
{
	public abstract class ArmyUnit : IAttackable
	{
		private readonly int defense;

		private readonly int attackPower;

		private readonly int attackRange;

		private readonly Random random = new Random();

		protected ArmyUnit(
			int minHealth, int maxHealth,
			int minDefense, int maxDefense,
			int minAttackPower, int maxAttackPower,
			int minAttackRange, int maxAttackRange )
		{
			this.Health = this.random.Next( minHealth, maxHealth );
			this.defense = this.random.Next( minDefense, maxDefense );
			this.attackPower = this.random.Next( minAttackPower, maxAttackPower );
			this.attackRange = this.random.Next( minAttackRange, maxAttackRange );
		}

		public int Health { get; private set; }

		public int GetDefense => this.defense;

		public int GetAttackPower => this.attackPower;

		public int GetAttackRange => this.attackRange;

		//TODO: Pottential inssue -> unit can attack itself
		///  <summary>
		///  <para>Perform an attack on the selected target. The damage is equal to the unit's attack subtracting the targets defense
		///  and subtracting the range differance (in persents) from the units attack power if higher than 0, or add it if less than 0
		/// </para>
		///  <para>
		///  Example:
		///  126 - 69 - (126 * 0.31) =  18</para>
		///  <para>unit's attack  - target's defense -/+ (unit's attack * +/- (double)(unit's range - target's range) / 100 )  = Math.Round(17.94)</para>
		///  </summary>
		/// <param name="unit"></param>
		/// <returns>Returns the remaining health of the attacked unit</returns>
		public void Attack( ArmyUnit unit )
		{
			double rangeDifferense = ( this.GetAttackRange - unit.GetAttackRange ) / 100;

			if ( rangeDifferense > 1 )
			{
				rangeDifferense -= 1;
			}

			if ( rangeDifferense > 0 )
			{
				var damage = ( int ) Math.Round( this.GetAttackPower - unit.GetDefense -
				                                 ( double ) ( this.GetAttackPower * rangeDifferense ) );

				unit.Health -= damage;
			}
			else
			{
				var damage = ( int ) Math.Round( this.GetAttackPower - unit.GetDefense +
				                                 ( double ) ( this.GetAttackPower * rangeDifferense ) );
				unit.Health -= damage;
			}
		}
	}
}