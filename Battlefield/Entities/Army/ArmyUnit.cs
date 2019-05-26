using System;
using Battlefield.Interfaces;

namespace Battlefield.Entities.Army
{
	public abstract class ArmyUnit : IAttackable, IUnit
	{
		#region Variables

		private int defense;

		private int attackPower;

		private int attackRange;

		private int health;

		private int cost;

		private static int id = 1;

		private int myId;

		private readonly Random random = new Random();

		#endregion

		#region Constructors

		protected ArmyUnit(
			int minHealth, int maxHealth,
			int minDefense, int maxDefense,
			int minAttackPower, int maxAttackPower,
			int minAttackRange, int maxAttackRange,
			int cost )
		{
			this.myId = id++;
			this.health = this.random.Next( minHealth, maxHealth );
			this.defense = this.random.Next( minDefense, maxDefense );
			this.attackPower = this.random.Next( minAttackPower, maxAttackPower );
			this.attackRange = this.random.Next( minAttackRange, maxAttackRange );
			this.cost = cost;
		}

		#endregion

		#region Getters and Setters

		public int Health { get; private set; }

		public int Defense { get; protected set; }

		public int AttackPower { get; protected set; }

		public int Range
		{
			get { return this.attackRange; }
			protected set { this.attackRange = value; }
		}

		public int Id => this.myId;

		#endregion

		#region Methods

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
			double rangeDifferense = ( this.Range - unit.Range ) / 100;

			if ( rangeDifferense > 1 )
			{
				rangeDifferense -= 1;
			}

			if ( rangeDifferense > 0 )
			{
				var damage = ( int ) Math.Round( this.AttackPower - unit.Defense -
				                                 ( double ) ( this.AttackPower * rangeDifferense ) );

				unit.Health -= damage;
			}
			else
			{
				var damage = ( int ) Math.Round( this.AttackPower - unit.Defense +
				                                 ( double ) ( this.AttackPower * rangeDifferense ) );

				unit.Health -= damage;
			}
		}

		public bool IsAlive()
		{
			if ( this.Health < 0 )
			{
				return false;
			}

			return true;
		}

		public abstract void SpecialAbility();

		#endregion
	}
}