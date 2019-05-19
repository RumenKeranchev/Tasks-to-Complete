using System;
using System.Runtime.CompilerServices;

namespace Battlefield.Entities.Army
{
	public abstract class ArmyUnit
	{
		private int health;

		private readonly int defense;

		private readonly int attackPower;

		private readonly int attackRange;

		private readonly Random random = new Random();

		protected ArmyUnit( 
			int minHealth, int maxHealth, 
			int minDefense, int maxDefense, 
			int minAttackPower,int maxAttackPower,
			int minAttackRange, int maxAttackRange)
		{
			this.health = this.random.Next( minHealth, maxHealth );
			this.defense = this.random.Next( minDefense, maxDefense );
			this.attackPower = this.random.Next( minAttackPower, maxAttackPower );
			this.attackRange = this.random.Next( minAttackRange, maxAttackRange );
		}

		public int GetHealth => this.health;

		public int GetDefense => this.defense;

		public int GetAttackPower => this.attackPower;

		public int GetAttackRange => this.attackRange;
	}
}